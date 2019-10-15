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
            ViewBag.Salute2 = "РЕМОНТ - 6 ШАГОВ И КОМФОРТ НА ДЕСЯТКИ ЛЕТ!";
            return View();
        }
        public ActionResult Certificate()
        {
            ViewBag.Title = "СВИДЕТЕЛЬСТВО О РЕГИСТРАЦИИ";
            ViewBag.Salute = "ВЫПОЛНЯЕМ РЕМОНТ ПО ВЫСОКИМ СТАНДАРТАМ";
            return View();
        }
        public ActionResult Contacts()
        {
            ViewBag.Title = "КОНТАКТНАЯ ИНФОРМАЦИЯ:";
            ViewBag.Salute = "СДЕЛАЙТЕ ВАШ ДОМ УЮТНЕЕ НАШИМИ ПРОФЕССИОНАЛЬНЫМИ РУКАМИ";
            ViewBag.WorkPlace = "РАБОТАЕМ ПО МИНСКУ И МИНСКОЙ ОБЛАСТИ";
            ViewBag.WorkTime = "ВРЕМЯ РАБОТЫ: ПН - ВС 8.00 - 22.00";
            ViewBag.Phone = "+375445634745";
            ViewBag.Email = "remontunderkey@gmail.com";
            ViewBag.Mapjscript = "https://api-maps.yandex.ru/services/constructor/1.0/js/?um=constructor%3Aa9045ea1b314d6145c21a3865ad9cc83b12f29e9b70e27e26c927c540605b166&amp;width=700&amp;height=500&amp;lang=ru_RU&amp;scroll=true";
            return View();
        }

    }
}