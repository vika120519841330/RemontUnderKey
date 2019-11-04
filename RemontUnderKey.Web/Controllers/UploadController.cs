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

namespace RemontUnderKey.Web.Controllers
{
    public class UploadController : Controller
    {
        private readonly IUpload service;
        private readonly IComment comservice;
        ApplicationUserManager userManager;
        public Comment_View comment;

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
            Upload_View upload = service.GetUpload(id).UploadFromDomainToView();
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
            Upload_View inst = ins;
            string resultUpload = "";
            if (fileupload == null)
            {
                resultUpload = "Что-то пошло не так! Файл не удалось загрузить!";
                return RedirectToRoute(new { controller = "Comment", action = "CreateCommentRedirect", id = inst.Comment_ViewId, res = resultUpload });
            }
            else if(fileupload.ContentLength <= 0)
            {
                resultUpload = "Что-то пошло не так! Файл не удалось загрузить!";
                return RedirectToRoute(new { controller = "Comment", action = "CreateCommentRedirect", id = inst.Comment_ViewId, res = resultUpload });
            }
            else if (fileupload.ContentLength > 2 * 1024 * 1024)
            {
                resultUpload = "Файл не удалось загрузить! Размер загружаемого файла не должен превышать 2 МБайт!";
                return RedirectToRoute(new { controller = "Comment", action = "CreateCommentRedirect", id = inst.Comment_ViewId, res = resultUpload });

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
                return RedirectToRoute(new { controller = "Comment", action = "CreateCommentRedirect", id = inst.Comment_ViewId, res = resultUpload });
            }
            else
            {
                byte[] array;
                // получить имя файла
                inst.FileName = Path.GetFileName(fileupload.FileName);
                inst.FileType = fileupload.ContentType;
                // сохранить файл в папку Files в проекте
                //fileupload.SaveAs(Server.MapPath("~/Files/" + inst.FileName));    //закомментированно, т.к. при deploy on azure will fail
                // считать содержимое загружаемого файла в байтовый массив
                using (MemoryStream ms = new MemoryStream())
                {
                    fileupload.InputStream.CopyTo(ms);
                    array = ms.GetBuffer();
                }
                inst.File = array;
                resultUpload = string.Format($"{inst.FileName} был успешно загружен!");
                ViewBag.LengthOfFile = inst.File.Length;
                ViewBag.Title = "РЕЗУЛЬТАТ ЗАГРУЗКИ ФОТО ИЛИ ИЗОБРАЖЕНИЯ";
                int? tempIdOfUpload = service.CreateUpload(inst.UploadFromViewToDomain());
                Upload_View upload = service.GetUpload(tempIdOfUpload).UploadFromDomainToView();
                comment = comservice.GetComment(upload.Comment_ViewId).CommentFromDomainToView();
                int IdOfComment = comment.Id;
                //(int, string) cort = (comment.Id, resultUpload);
                return RedirectToRoute(new { controller = "Comment", action = "CreateCommentRedirect", id = IdOfComment, res = resultUpload });
            }
        }
    }
}