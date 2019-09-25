using System.Web.Mvc;
using RemontUnderKey.Web.Mappers;
using RemontUnderKey.Web.Models;
using RemontUnderKey.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace RemontUnderKey.Web.Controllers
{
    public class KindController : Controller
    {
        private readonly IKind service;
        public KindController(IKind _service)
        {
            this.service = _service;
        }
        public ActionResult GetAllKinds()
        {
            ViewBag.Title = "СТОИМОСТЬ РЕМОНТА ПОД КЛЮЧ";
            ViewBag.Header = "ЦЕНЫ НА ОТДЕЛОЧНЫЕ РАБОТЫ, НЕОБХОДИМЫЕ ДЛЯ КОМПЛЕКСНОГО РЕМОНТА КВАРТИРЫ ПОД КЛЮЧ";
            IEnumerable<KindOfJob_View> kinds = service.GetAllKinds()
                .Select(_ => _.KindOfJobFromDomainToView())
                .ToList()
                ;
            return View(kinds);
        }
    }
}