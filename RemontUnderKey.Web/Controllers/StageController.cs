using RemontUnderKey.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RemontUnderKey.Web.Mappers;
using RemontUnderKey.Web.Models;

namespace RemontUnderKey.Web.Controllers
{
    public class StageController : Controller
    {
        private readonly IStage service;
        public StageController(IStage _service)
        {
            this.service = _service;
        }

        //Метод выводит в частичное представление все этапы/шаги ремонта
        [HttpGet]
        public PartialViewResult GetAllStages()
        {
            IEnumerable<Stage_View> stages = service.GetAllStages()
                .Select(_ => _.StageFromDomainToView())
                .ToList()
                ;
            return PartialView(stages);
        }
        //Метод выводит в частичное представление определенный этап ремонта
        [HttpGet]
        public PartialViewResult GetStage(int id)
        {
            Stage_View stage = service.GetStage(id)
                .StageFromDomainToView()
                ;
            return PartialView(stage);
        }
    }
}