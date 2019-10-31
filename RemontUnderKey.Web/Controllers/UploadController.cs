using RemontUnderKey.Domain.Interfaces;
using RemontUnderKey.Web.Models;
using System.IO;
using System.Web;
using System.Web.Mvc;
using RemontUnderKey.Web.Mappers;
using RemontUnderKey.Web.Identity;

namespace RemontUnderKey.Web.Controllers
{
    public class UploadController : Controller
    {
        private readonly IUpload service;
        private readonly IComment comservice;
        ApplicationUserManager userManager;
        private Comment_View comment;

        public UploadController(IUpload _service, IComment _comservice, ApplicationUserManager _userManager)
        {
            this.service = _service;
            this.comservice = _comservice;
            this.userManager = _userManager;
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
        // вспомогательный метод
        private ActionResult RedirectToCreateComment(Upload_View inst, string resultUpload)
        {
            ViewBag.Title = "РЕЗУЛЬТАТ ЗАГРУЗКИ ФОТО ИЛИ ИЗОБРАЖЕНИЯ";
            int? tempIdOfUpload = service.CreateUpload(inst.UploadFromViewToDomain());
            inst = service.GetUpload(tempIdOfUpload).UploadFromDomainToView();
            comment = comservice.GetComment(inst.Comment_ViewId).CommentFromDomainToView();
            ViewBag.ResultFromUpload = resultUpload;
            return RedirectToAction("../Comment/CreateCommentRedirect", comment);
        }
        [HttpPost]
        public ActionResult AddFile(Upload_View inst, HttpPostedFileBase fileupload)
        {
            string resultUpload = "";
            if (fileupload == null)
            {
                resultUpload = "Передумали загружать фото?";
                return RedirectToCreateComment(inst, resultUpload);
            }
            else if(fileupload.ContentLength <= 0)
            {
                resultUpload = "Что-то пошло не так! Файл не удалось загрузить!";
                return RedirectToCreateComment(inst, resultUpload);
            }
            else if (fileupload.ContentLength > 200000)
            {
                resultUpload = "Файл не удалось загрузить! Размер загружаемого файла не должен превышать 2 МБайт!";
                return RedirectToCreateComment(inst, resultUpload);
            }
            //MIME-типы Image Types, допустимые для загрузки пользователем
            #region
            else if (!(fileupload.ContentType == "image/jpeg"
                  || fileupload.ContentType == "image/gif"
                  || fileupload.ContentType == "image/x-xbitmap"
                  || fileupload.ContentType == "image/x-xpixmap"
                  || fileupload.ContentType == "image/x-png"
                  || fileupload.ContentType == "image/ief"
                  || fileupload.ContentType == "image/tiff"
                  || fileupload.ContentType == "image/rgb"
                  || fileupload.ContentType == "image/x-rgb"
                  || fileupload.ContentType == "image/g3fax"
                  || fileupload.ContentType == "image/x-xwindowdump"
                  || fileupload.ContentType == "image/x-pict"
                  || fileupload.ContentType == "image/x-portable-pixmap"
                  || fileupload.ContentType == "image/x-portable-graymap"
                  || fileupload.ContentType == "image/x-portable-bitmap"
                  || fileupload.ContentType == "image/x-portable-anymap"
                  || fileupload.ContentType == "image/x-ms-bmp"
                  || fileupload.ContentType == "image/x-cmu-raster"
                  || fileupload.ContentType == "image/x-photo-cd"
                  || fileupload.ContentType == "image/cgm"
                  || fileupload.ContentType == "image/naplps"
                  || fileupload.ContentType == "image/x-cals"
                  || fileupload.ContentType == "image/fif"
                  || fileupload.ContentType == "image/x-mgx-dsf"
                  || fileupload.ContentType == "image/x-cmx"
                  || fileupload.ContentType == "image/wavelet"
                  || fileupload.ContentType == "image/vnd.dwg"
                  || fileupload.ContentType == "image/x-dwg "
                  || fileupload.ContentType == "image/vnd.dxf"
                  || fileupload.ContentType == "image/x-dxf"
                  || fileupload.ContentType == "image/vnd.svf"
                  || fileupload.ContentType == "image/x-svf"
                  || fileupload.ContentType == "image/x-sgi-bw"
                  || fileupload.ContentType == "image/x-sgi-rgba"
                  || fileupload.ContentType == "image/x-eps"
                  || fileupload.ContentType == "image/*"))
                  #endregion
            {
                resultUpload = "Файл не удалось загрузить! Загружаемый тип файла должен относиться к типу image!";
                return RedirectToCreateComment(inst, resultUpload);
            }
            else
            {
                byte[] array;
                // получить имя файла
                inst.FileName = Path.GetFileName(fileupload.FileName);
                inst.FileType = fileupload.ContentType;
                // сохранить файл в папку Files в проекте
                fileupload.SaveAs(Server.MapPath("~/Files/" + inst.FileName));
                // считать содержимое загружаемого файла в байтовый массив
                using (MemoryStream ms = new MemoryStream())
                {
                    fileupload.InputStream.CopyTo(ms);
                    array = ms.GetBuffer();
                }
                inst.File = array;
                resultUpload = string.Format($"{inst.FileName} был успешно загружен!");
                return RedirectToCreateComment(inst, resultUpload);
            }
        }
    }
}