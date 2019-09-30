using RemontUnderKey.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RemontUnderKey.Web.Mappers;
using RemontUnderKey.Web.Models;

namespace RemontUnderKey.Web.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IPhoto service;
        public PhotoController(IPhoto _service)
        {
            this.service = _service;
        }

        //Вспомогательный метод - возвращает коллекцию всех фото, относящихся к определенному обьекту ремонта (Repareobject)
        public PartialViewResult AllPhotosByIdOfObject(int id)
        {
            IEnumerable<Photo_View> photosOfObject = service.AllPhotosByIdOfObject(id)
                .Select(_ => _.PhotoFromDomainToView())
                .Where(_ => _.Repareobject_ViewId == id)
                .ToList()
                ;
            return PartialView(photosOfObject);
        }

        public ActionResult GetAllPhotos()
        {
            ViewBag.Title = "НАША ФОТОГАЛЕРЕЯ ОБЬЕКТОВ РЕМОНТА";
            ViewBag.Message = "ПРИЯТНОГО ПРОСМОТРА!";

            IEnumerable <Photo_View> Photos = service.GetAllPhotos()
                .Select(_ => _.PhotoFromDomainToView())
                .ToList()
               ;
            return View("PhotoGalery", Photos);
        }

        public ActionResult GetPhoto(int id)
        {
            Photo_View photo = service.GetPhoto(id)
                .PhotoFromDomainToView()
                ;
            return View(photo);
        }


    }
}