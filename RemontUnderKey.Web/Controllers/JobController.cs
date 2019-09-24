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
        public JobController(IJob _service)
        {
            this.service = _service;
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
    }
}