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
        private readonly IJob jservice;

        public KindController(IKind _service, IJob _jservice)
        {
            this.service = _service;
            this.jservice = _jservice;
        }

        [HttpGet]
        [Route("Kind/GetAllKinds")]
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

        //Список всех Kinds, которые существуют в БД, для передачи в представление в виде выпадающего списка
        [Authorize(Roles = "admin")]
        public SelectList GetSelectList_Kinds()
        {
            List<KindOfJob_View> ListKinds = service.GetAllKinds()
                                             .Select(_ => _.KindOfJobFromDomainToView())
                                             .ToList()
                                             ;
            SelectList SelectListKinds = new SelectList(ListKinds, "TitleOfKindOfJob", "TitleOfKindOfJob");
            return SelectListKinds;
        }

        [HttpGet]
        [Route("Kind/DeleteKind_Admin")]
        public PartialViewResult DeleteKind_Admin()
        {
            ViewBag.TODO = "УДАЛЕНИЕ РАЗНОВИДНОСТИ РСР";
            ViewBag.Kinds = GetSelectList_Kinds();
            return PartialView("DeleteKind_Admin");
        }

        [HttpPost]
        [Route("Kind/DeleteKind_Admin")]
        public ActionResult DeleteKind_Admin(string title)
        {
            string result =  $"РАЗНОВИДНОСТЬ РСР <<{title}>> И ВХОДЯЩИЕ В ЕЕ СОСТАВ ПОДВИДЫ РСР УСПЕШНО УДАЛЕНЫ !";
            int id = service.GetAllKinds()
                    .First(_ => _.TitleOfKindOfJob == title)
                    .Id
                    ;
            //перед удалением главной сущности, удалить зависимые сущности
            List<Job_View> jobs = jservice.AllJobsByIdOfkind(id)
                                          .Select(_ => _.JobFromDomainToView())
                                          .ToList()
                                          ;
            foreach(Job_View job in jobs)
            {
                jservice.DeleteJob(job.Id);
            }
            //удалить главную сущность
            service.DeleteKind(id);
            return RedirectToRoute(new { controller = "Job", action = "JobsKinds_Admin", res = result });
        }

        [HttpGet]
        [Route("Kind/DeleteKind_Admin")]
        public PartialViewResult AddKind_Admin()
        {
            ViewBag.TODO = "ДОБАВЛЕНИЕ РАЗНОВИДНОСТИ РСР";
            return PartialView("AddKind_Admin");
        }


        [HttpPost]
        [Route("Kind/AddKind_Admin")]
        public ActionResult AddKind_Admin([System.Web.Http.FromBody]KindOfJob_View kind)
        {
            string result;
            if (kind == null)
            {
                result = $"РАЗНОВИДНОСТЬ РСР ДОЛЖНА СОДЕРЖАТЬ ЗАПОЛНЕННЫЕ ПОЛЯ ДЛЯ ДОБАВЛЕНИЯ В БАЗУ !";
                return RedirectToRoute(new { controller = "Job", action = "JobsKinds_Admin", res = result });
            }
            else
            {
                result = $"РАЗНОВИДНОСТЬ РСР <<{kind.TitleOfKindOfJob}>> УСПЕШНО ДОБАВЛЕНА В БАЗУ !";
                service.CreateKind(kind.KindOfJobFromViewToDomain());
                return RedirectToRoute(new { controller = "Job", action = "JobsKinds_Admin", res = result });
            }
        }
    }
}