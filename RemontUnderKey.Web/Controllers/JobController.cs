using RemontUnderKey.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RemontUnderKey.Web.Mappers;
using RemontUnderKey.Web.Models;

namespace RemontUnderKey.Web.Controllers
{
    public class JobController : Controller
    {
        private readonly IJob service;
        private readonly IKind kservice;
        private readonly IUnit uservice;

        public JobController(IJob _service, IKind _kservice, IUnit _uservice)
        {
            this.service = _service;
            this.kservice = _kservice;
            this.uservice = _uservice;
        }
        //Вспомогательный метод - возвращает коллекцию всех подвидов ремонтных работ, относящихся к определенному виду работ (KindOfJob)
        public PartialViewResult AllJobsByIdOfkind(int id)
        {
            var jobsOfKind = service.AllJobsByIdOfkind(id)
                .Select(_ => _.JobFromDomainToView())
                .Where(_ => _.KindOfJob_ViewId == id)
                .ToList()
                ;
            return PartialView(jobsOfKind);
        }
       
        [HttpGet]
        public ActionResult GetAllJobs()
        {
            IEnumerable<Job_View> jobsOfKind = service.GetAllJobs()
                .Select(_ => _.JobFromDomainToView())
                .OrderBy(t => t.KindOfJob_ViewId)
                .ToList()
                ;
            return View(jobsOfKind);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("Job/JobsKinds_Admin")]
        public ActionResult JobsKinds_Admin(string res)
        {
            if (res == null)
            {
                res = " ";
            }
            ViewBag.Result = res;
            ViewBag.Num = 0;
            ViewBag.TODO = "РАСЦЕНКИ НА РЕМОНТНО-СТРОИТЕЛЬНЫЕ РАБОТЫ";
            Dictionary<string, List<Job_View>> kindsJobs = new Dictionary<string, List<Job_View>>();
            List<Job_View> listJobsByIdOfKind = new List<Job_View>();
            //список всех разновидностей ремонтных работ
            List<KindOfJob_View> listKinds = kservice.GetAllKinds()
                .Select(_ => _.KindOfJobFromDomainToView())
                .ToList()
                ;
            foreach (KindOfJob_View kind in listKinds)
            {
                //получить наименование разновидности ремонтных работ по id
                string titleOfKind = kservice.GetKind(kind.Id).TitleOfKindOfJob;
                listJobsByIdOfKind = service.AllJobsByIdOfkind(kind.Id)
                                            .Select(_ => _.JobFromDomainToView())
                                            .ToList()
                                            ;
                kindsJobs.Add(titleOfKind, listJobsByIdOfKind);
            }
            return View("JobsKinds_Admin", kindsJobs);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("Job/JobsKinds_Admin")]
        public ActionResult JobsKinds_Admin([System.Web.Http.FromBody]Job_View kindsJobs)
        {
            string result = " ";
            if (kindsJobs == null || kindsJobs.PriceOfUnitOfJob <= 0)
            {
                result = "РАСЦЕНКА ДОЛЖНА БЫТЬ БОЛЬШЕ НУЛЯ !";
                return RedirectToRoute(new { controller = "Job", action = "JobsKinds_Admin", res = result });
            }
            if (kindsJobs.TitleOfJob.Length == 0)
            {
                result = "НАИМЕНОВАНИЕ ВИДА РЕМОНТНО-СТРОИТЕЛЬНЫХ РАБОТ ДОЛЖНО БЫТЬ ЗАПОЛНЕНО !";
                return RedirectToRoute(new { controller = "Job", action = "JobsKinds_Admin", res = result });
            }
            service.UpdateJob(kindsJobs.JobFromViewToDomain());
            result = "ОБНОВЛЕНИЕ РАСЦЕНКИ УСПЕШНО ПРОИЗВЕДЕНО !";
            return RedirectToRoute(new { controller = "Job", action = "JobsKinds_Admin", res = result });
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("Job/DeleteJobs_Admin")]
        public ActionResult DeleteJobs_Admin(int id)
        {
            string result = " ";
            service.DeleteJob(id);
            result = $"УДАЛЕНИЕ РАСЦЕНКИ С ID №{id} УСПЕШНО ПРОИЗВЕДЕНО !";
            return RedirectToRoute(new { controller = "Job", action = "JobsKinds_Admin", res = result });
        }

        //Список всех Jobs, которые существуют в БД, для передачи в представление в виде выпадающего списка
        [Authorize(Roles = "admin")]
        public SelectList GetSelectList_Jobs()
        {
            List<Job_View> ListJobs = service.GetAllJobs()
                                             .Select(_ => _.JobFromDomainToView())
                                             .ToList()
                                             ;
            SelectList SelectListJobs = new SelectList(ListJobs, "TitleOfJob", "TitleOfJob");
            return SelectListJobs;
        }

        //Список всех Units, которые существуют в БД, для передачи в представление в виде выпадающего списка
        [Authorize(Roles = "admin")]
        public SelectList GetSelectList_Units()
        {
            List<UnitOfJob_View> ListUnits = uservice.GetAllUnits()
                                             .Select(_ => _.UnitOfJobFromDomainToView())
                                             .ToList()
                                             ;
            SelectList SelectListUnits = new SelectList(ListUnits, "Id", "TitleOfUnit");
            return SelectListUnits;
        }

        //Список всех Kinds, которые существуют в БД, для передачи в представление в виде выпадающего списка
        [Authorize(Roles = "admin")]
        public SelectList GetSelectList_Kinds()
        {
            List<KindOfJob_View> ListKinds = kservice.GetAllKinds()
                                             .Select(_ => _.KindOfJobFromDomainToView())
                                             .ToList()
                                             ;
            SelectList SelectListKinds = new SelectList(ListKinds, "Id", "TitleOfKindOfJob");
            return SelectListKinds;
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("Job/AddJob_Admin")]
        public PartialViewResult AddJob_Admin()
        {
            ViewBag.TODO = "ДОБАВЛЕНИЕ ВИДА РСР";
            SelectList SelectListKinds = GetSelectList_Kinds();
            ViewBag.Kinds = SelectListKinds;
            SelectList SelectListUnits = GetSelectList_Units();
            ViewBag.Units = SelectListUnits;
            return PartialView("AddJob_Admin");
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("Job/AddJob_Admin")]
        public ActionResult AddJob_Admin([System.Web.Http.FromUri][Bind(Exclude = "Id", Include = "TitleOfJob, PriceOfUnitOfJob, KindOfJob_ViewId, UnitOfJob_ViewId")]Job_View job)
        {
            string result = " ";
            if (job== null)
            {
                result = $"ДЛЯ ДОБАВЛЕНИЯ ВИДА РСР Д.Б. ЗАПОЛНЕНЫ ВСЕ ПОЛЯ !";
                return RedirectToRoute(new { controller = "Job", action = "JobsKinds_Admin", res = result });

            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("AddJob_Admin", "Указанные для создания нового вида РСР данные не валидны!!!");
                ViewBag.Message = "Валидация НЕ пройдена! Проверьте введенные сведения на достоверность!";
                result = "Валидация НЕ пройдена! Проверьте введенные сведения на достоверность!";
                return RedirectToRoute(new { controller = "Job", action = "JobsKinds_Admin", res = result });
            }
            else
            {
                service.CreateJob(job.JobFromViewToDomain());
                int jobid = service.GetAllJobs().Where(_ => _.TitleOfJob == job.TitleOfJob).First().Id;
                result = $"ДОБАВЛЕНИЕ ВИДА РСР С ID №{jobid} УСПЕШНО ПРОИЗВЕДЕНО !";
                return RedirectToRoute(new { controller = "Job", action = "JobsKinds_Admin", res = result });
            }
        }
    }
}