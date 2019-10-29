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
        private CommentController comcontr;
        ApplicationUserManager userManager;
        private Upload_View upload;
        private Comment_View comment;


        public UploadController(IUpload _service, IComment _comservice, ApplicationUserManager _userManager)
        {
            this.service = _service;
            this.comservice = _comservice;
            this.userManager = _userManager;
            this.comcontr = new CommentController(this.comservice, this.userManager);

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

        [HttpPost]
        public ActionResult AddFile(Upload_View inst, HttpPostedFileBase fileupload)
        {
            ViewBag.Title = "ЗАГРУЗКА ФАЙЛА / ИЗОБРАЖЕНИЯ";
            //Comment_View comment = comcontr.GetComment(upload.Comment_ViewId);
            if (fileupload != null && fileupload.ContentLength > 0 && fileupload.ContentLength < 200000)
            {
                byte[] array;
                // получить имя файла
                var fileName = Path.GetFileName(fileupload.FileName);
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
                int? tempIdOfUpload = service.CreateUpload(inst.UploadFromViewToDomain());
                inst = service.GetUpload(tempIdOfUpload).UploadFromDomainToView();
                comment = comservice.GetComment(inst.Comment_ViewId).CommentFromDomainToView();
                return RedirectToAction("../Comment/CreateCommentRedirect", comment);
            }
            else
            {
                ViewBag.Result = "Файл не удалось загрузить! Размер загружаемого файла не должен превышать 2 МБайт!";
                int? tempIdOfUpload = service.CreateUpload(inst.UploadFromViewToDomain());
                inst = service.GetUpload(tempIdOfUpload).UploadFromDomainToView();
                comment = comservice.GetComment(inst.Comment_ViewId).CommentFromDomainToView();
                return RedirectToAction("../Comment/CreateCommentRedirect", comment);
            }
        }
    }
}