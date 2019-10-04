using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RemontUnderKey.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "ДОМАШНЯЯ СТРАНИЦА";
            ViewBag.Salute = "ПОД КЛЮЧ В МИНСКЕ И МИНСКОЙ ОБЛАСТИ";
            ViewBag.TD1 = "Бесплатный выезд специалиста и смета на в течение одной недели";
            ViewBag.TD2 = "Фиксированная стоимость, согласно условиям договора";
            ViewBag.TD3 = "Средняя стоимость ремонта 250 бел. руб за м2";
            return View();
        }

    }
}