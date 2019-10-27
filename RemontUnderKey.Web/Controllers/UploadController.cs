using RemontUnderKey.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RemontUnderKey.Web.Controllers
{
    public class UploadController : Controller
    {
        [HttpPost]
        public ActionResult AddFile(Upload model, List<HttpPostedFileBase> templateFile)
        {
            ViewBag.Title = "ЗАГРУЗКА ФАЙЛА / ИЗОБРАЖЕНИЯ";
            if (templateFile == null && templateFile.Count > 0)
            {
                foreach (HttpPostedFileBase file in templateFile)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        // получить имя файла
                        var fileName = Path.GetFileName(file.FileName);
                        // сохранить файл в папку Files в проекте
                        file.SaveAs(Server.MapPath("~/Files/" + fileName));
                        // считать содержимое загружаемого файла в байтовый массив
                        using (MemoryStream ms = new MemoryStream())
                        {
                            file.InputStream.CopyTo(ms);
                            byte[] array = ms.GetBuffer();
                            model.File.Add(array);
                        }
                    }
                }
                ViewBag.Result = "Загрузка прошла успешно!";
                return RedirectToAction("CreateComment", "Comment");
            }
            else
            {
                ViewBag.Result = "Файлы загружены!";
                return RedirectToAction("CreateComment", "Comment");
            }
        }
    }
}