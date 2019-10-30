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
            ViewBag.Title = "ЗАГРУЗКА ФАЙЛА / ИЗОБРАЖЕНИЯ";
            TempData["IdOfComment"] = id;
            return View("AddFile");
        }
        // вспомогательный метод
        private ActionResult RedirectToCreateComment(Upload_View inst)
        {
            int? tempIdOfUpload = service.CreateUpload(inst.UploadFromViewToDomain());
            inst = service.GetUpload(tempIdOfUpload).UploadFromDomainToView();
            comment = comservice.GetComment(inst.Comment_ViewId).CommentFromDomainToView();
            return RedirectToAction("../Comment/CreateCommentRedirect", comment);
        }
        [HttpPost]
        public ActionResult AddFile(Upload_View inst, HttpPostedFileBase fileupload)
        {
            ViewBag.Title = "ЗАГРУЗКА ФАЙЛА / ИЗОБРАЖЕНИЯ";
            if (fileupload == null)
            {
                ViewBag.Result = "Передумали загружать фото?";
                return RedirectToCreateComment(inst);
            }
            else if(fileupload.ContentLength <= 0)
            {
                ViewBag.Result = "Что-то пошло не так! Файл не удалось загрузить!";
                return RedirectToCreateComment(inst);
            }
            else if (fileupload.ContentLength > 200000)
            {
                ViewBag.Result = "Файл не удалось загрузить! Размер загружаемого файла не должен превышать 2 МБайт!";
                return RedirectToCreateComment(inst);
            }

            else if (fileupload.ContentType != "image/jpeg")
            {
                ViewBag.Result = "Файл не удалось загрузить! Загружаемое фото должно быть в формате JPEG!";
                return RedirectToCreateComment(inst);
            }
            else
            {
                byte[] array;
                // получить имя файла
                var fileName = Path.GetFileName(fileupload.FileName);
                inst.FileName = fileName.ToString();
                // сохранить файл в папку Files в проекте
                fileupload.SaveAs(Server.MapPath("~/Files/" + fileName));
                // считать содержимое загружаемого файла в байтовый массив
                using (MemoryStream ms = new MemoryStream())
                {
                    fileupload.InputStream.CopyTo(ms);
                    array = ms.GetBuffer();
                }
                inst.File = array;
                ViewBag.ResultFromUpload = "Загрузка прошла успешно!";
                return RedirectToCreateComment(inst);
            }
        }
    }
}