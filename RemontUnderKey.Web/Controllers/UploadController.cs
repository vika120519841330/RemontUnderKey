using RemontUnderKey.Domain.Interfaces;
using RemontUnderKey.Web.Models;
using System.IO;
using System.Web;
using System.Web.Mvc;
using RemontUnderKey.Web.Mappers;
using RemontUnderKey.Web.Identity;
using System.Collections.Generic;
using System;
using System.Collections;
using System.Linq;

namespace RemontUnderKey.Web.Controllers
{
    public class UploadController : Controller
    {
        private readonly IUpload service;
        private readonly IComment comservice;
        private ApplicationUserManager userManager;
        private Comment_View comment;
        private Upload_View upload;
        private List<Upload_View> listUploads;

        public UploadController(IUpload _service, IComment _comservice, ApplicationUserManager _userManager)
        {
            this.service = _service;
            this.comservice = _comservice;
            this.userManager = _userManager;
        }

        [HttpGet]
        [Route("upload/getfile/id")]
        public PartialViewResult GetFile(int id)
        {
            upload = service.GetUpload(id).UploadFromDomainToView();
            return PartialView(upload);
        }

        [HttpGet]
        [Route("Upload/AddFile/id")]
        public ActionResult AddFile(int id)
        {
            ViewBag.Salute = "Выберите файл для загрузки:";
            ViewBag.Title = "ЗАГРУЗКА ИЗОБРАЖЕНИЯ ИЛИ ФОТО";
            TempData["IdOfComment"] = id;
            return View("AddFile");
        }

        [HttpPost]
        public RedirectToRouteResult AddFile(Upload_View ins, HttpPostedFileBase fileupload)
        {
            upload = ins;
            string resultUpload = "";
            if (fileupload == null)
            {
                resultUpload = "Что-то пошло не так! Файл не удалось загрузить!";
                return RedirectToRoute(new { controller = "Comment", action = "CreateCommentRedirect", id = upload.Comment_ViewId, res = resultUpload });
            }
            else if (fileupload.ContentLength <= 0)
            {
                resultUpload = "Что-то пошло не так! Файл не удалось загрузить!";
                return RedirectToRoute(new { controller = "Comment", action = "CreateCommentRedirect", id = upload.Comment_ViewId, res = resultUpload });
            }
            else if (fileupload.ContentLength > 1 * 1024 * 1024)
            {
                resultUpload = "Файл не удалось загрузить! Размер загружаемого файла не должен превышать 1 МБайт!";
                return RedirectToRoute(new { controller = "Comment", action = "CreateCommentRedirect", id = upload.Comment_ViewId, res = resultUpload });

            }
            //MIME-типы Image Types, допустимые для загрузки пользователем
            #region
            else if (!(fileupload.ContentType == "image/jpeg"
                    || fileupload.ContentType == "image/gif"
                    || fileupload.ContentType == "image/x-png"
                    || fileupload.ContentType == "image/rgb"
                    || fileupload.ContentType == "image/x-rgb"
                    ))
            #endregion
            {
                resultUpload = "Файл не удалось загрузить! Загружаемый тип файла должен относиться к типу image!";
                return RedirectToRoute(new { controller = "Comment", action = "CreateCommentRedirect", id = upload.Comment_ViewId, res = resultUpload });
            }
            else
            {
                byte[] array;
                // получить имя файла
                upload.FileName = Path.GetFileName(fileupload.FileName);
                upload.FileType = fileupload.ContentType;
                // сохранить файл в папку Files в проекте
                //fileupload.SaveAs(Server.MapPath("~/Files/" + inst.FileName));    //закомментированно, т.к. при deploy on azure will fail
                // считать содержимое загружаемого файла в байтовый массив
                using (MemoryStream ms = new MemoryStream())
                {
                    fileupload.InputStream.CopyTo(ms);
                    array = ms.GetBuffer();
                }
                resultUpload = string.Format($"{upload.FileName} был успешно загружен!");
                ViewBag.Title = "РЕЗУЛЬТАТ ЗАГРУЗКИ ФОТО ИЛИ ИЗОБРАЖЕНИЯ";
                upload.File = array;
                int? tempIdOfUpload = service.CreateUpload(upload.UploadFromViewToDomain());
                upload = service.GetUpload(tempIdOfUpload).UploadFromDomainToView();
                comment = comservice.GetComment(upload.Comment_ViewId).CommentFromDomainToView();
                //удалить произведенные раннее загрузки пользователя, если общее кол-во загруженных файлов текущего пользователя достигло 9шт.
                DeleteFirstFile(comment.Id);
                //(int, string) cort = (comment.Id, resultUpload);
                return RedirectToRoute(new { controller = "Comment", action = "CreateCommentRedirect", id = comment.Id, res = resultUpload });
            }
        }

        //Вспомогательный метод - по id комментария удаляет самые ранние по времени загрузки файлы - если кол-во превыешает 8 шт.
        public void DeleteFirstFile(int id)
        {
            listUploads = service.GetAllUpload()
                    .Where(_ => _.Comment_DomainId == id)
                    .Select(_ => _.UploadFromDomainToView())
                    .ToList()
                    ;
            if(listUploads != null && listUploads.Count() > 8)
            {
                while (listUploads.Count() > 8)
                {
                    var firstupload = listUploads.First();
                    service.DeleteUpload(firstupload.Id);
                    listUploads = service.GetAllUpload()
                                         .Where(_ => _.Comment_DomainId == id)
                                         .Select(_ => _.UploadFromDomainToView())
                                         .ToList()
                                         ;
                }
            }
        }
        [HttpGet]
        [Route("upload/getfile_admin/id")]
        public PartialViewResult GetFile_Admin(int id)
        {
            upload = service.GetUpload(id).UploadFromDomainToView();
            return PartialView(upload);
        }
    }
}