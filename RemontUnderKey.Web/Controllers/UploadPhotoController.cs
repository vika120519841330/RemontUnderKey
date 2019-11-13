using RemontUnderKey.Domain.Interfaces;
using RemontUnderKey.Web.Mappers;
using RemontUnderKey.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RemontUnderKey.Web.Controllers
{
    public class UploadPhotoController : Controller
    {
        private readonly IUploadPhoto service;
        private readonly IObject objservice;
        private UploadPhoto_View upload;
        private List<UploadPhoto_View> listUploads;

        public UploadPhotoController(IUploadPhoto _service, IObject _objservice)
        {
            this.service = _service;
            this.objservice = _objservice;
        }

        [HttpGet]
        [Route("uploadphoto/ObjectAndUploadPhoto")]
        public ActionResult ObjectAndUploadPhoto()
        {
            List <Repareobject_View> obj = objservice.GetAllRepareobject()
                                              .Select(_ => _.RepareobjectFromDomainToView())
                                              .ToList()
                                              ;
            return View(obj);
        }
        //метод возвращает коллекцию фото, относящуюся к опр-му обьекту РСР по его id
        [HttpGet]
        [Route("uploadphoto/UploadPhotosByIdOfObject/objId/res")]
        public ActionResult UploadPhotosByIdOfObject(int objId, string res)
        {
            if(res == null)
            {
                res = " ";
            }
            ViewBag.Result = res;
            listUploads = service.GetAllUploadPhotos()
                            .Where(_ => _.Repareobject_DomainId == objId)
                            .Select(_ => _.UploadPhotoFromDomainToView())
                            .ToList()
                            ;
            if(listUploads != null && listUploads.Count() > 0)
            {
                return PartialView("UploadPhotosByIdOfObject", upload);
            }
            else
            {
                return PartialView("UploadPhotosByIdOfObject_withoutUploads");
            }
        }

        [HttpGet]
        [Route("uploadphoto/getfile/id")]
        public PartialViewResult GetFile(int id)
        {
            upload = service.GetUploadPhoto(id).UploadPhotoFromDomainToView();
            return PartialView(upload);
        }

        [HttpGet]
        [Route("uploadphoto/CreateUploadPhoto")]
        public PartialViewResult CreateUploadPhoto()
        {
            ViewBag.TODO = "ЗАГРУЗКА ФОТО ОБЬЕКТА РЕМОНТА";
            return PartialView("CreateUploadPhoto");
        }

        [HttpPost]
        [Route("uploadphoto/CreateUploadPhoto")]
        public RedirectToRouteResult CreateUploadPhoto(UploadPhoto_View ins, HttpPostedFileBase fileupload)
        {
            upload = ins;
            string resultUpload = "";
            if (fileupload == null)
            {
                resultUpload = "Что-то пошло не так! Файл не удалось загрузить!";
                return RedirectToRoute(new { controller = "UploadPhoto", action = "GetAllUploadPhotos", res = resultUpload });
            }
            else if (fileupload.ContentLength <= 0)
            {
                resultUpload = "Что-то пошло не так! Файл не удалось загрузить!";
                return RedirectToRoute(new { controller = "UploadPhoto", action = "GetAllUploadPhotos", res = resultUpload });
            }
            else if (fileupload.ContentLength > 1 * 1024 * 1024)
            {
                resultUpload = "Файл не удалось загрузить! Размер загружаемого файла не должен превышать 1 МБайт!";
                return RedirectToRoute(new { controller = "UploadPhoto", action = "GetAllUploadPhotos", res = resultUpload });
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
                return RedirectToRoute(new { controller = "UploadPhoto", action = "GetAllUploadPhotos", res = resultUpload });
            }
            else
            {
                byte[] array;
                // получить имя файла
                upload.FileName = Path.GetFileName(fileupload.FileName);
                upload.FileType = fileupload.ContentType;
                using (MemoryStream ms = new MemoryStream())
                {
                    fileupload.InputStream.CopyTo(ms);
                    array = ms.GetBuffer();
                }
                resultUpload = string.Format($"{upload.FileName} был успешно загружен!");
                ViewBag.Title = "РЕЗУЛЬТАТ ЗАГРУЗКИ ФОТО ИЛИ ИЗОБРАЖЕНИЯ";
                upload.File = array;
                int? tempIdOfUpload = service.CreateUploadPhoto(upload.UploadPhotoFromViewToDomain());
                upload = service.GetUploadPhoto(tempIdOfUpload).UploadPhotoFromDomainToView();
                return RedirectToRoute(new { controller = "UploadPhoto", action = "GetAllUploadPhotos", res = resultUpload });
            }
        }
    }
}