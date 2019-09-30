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

        //Вспомогательный метод -  получение наименования обьекта ремонта (Repareobject) к которому относится фото
        public string GetTitleOfRepareObject(int id)
        {
            string titleRepareObject = service.GetRepareObjectById(id).AddressOfRepareobject;
            return titleRepareObject;
        }

        public ActionResult PhotoGalery()
        {
            ViewBag.Title = "НАША ФОТОГАЛЕРЕЯ ОБЬЕКТОВ РЕМОНТА";
            ViewBag.Message = "ПРИЯТНОГО ПРОСМОТРА!";
            List<PhotoGalery_View> PhotoGalery = new List<PhotoGalery_View>();
            IEnumerable <Photo_View> Photos = service.GetAllPhotos()
                .Select(_ => _.PhotoFromDomainToView())
                .ToList()
               ;
            foreach (Photo_View photo in Photos)
            {
                PhotoGalery.Add(
                    new PhotoGalery_View{Id = photo.Id,
                                        ImgSrc = photo.ImgSrc,
                                        ImgSrcMini = photo.ImgSrcMini,
                                        Repareobject_ViewId = photo.Repareobject_ViewId,
                                        TitleOfRepareObject = service.GetRepareObjectById(photo.Repareobject_ViewId).AddressOfRepareobject});
            }
            return View(PhotoGalery);
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