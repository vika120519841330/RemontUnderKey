using RemontUnderKey.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RemontUnderKey.Web.Mappers;
using RemontUnderKey.Web.Models;

namespace RemontUnderKey.Web.Controllers
{
    public class UnitController : Controller
    {
        private readonly IUnit service;
        public UnitController(IUnit _service)
        {
            this.service = _service;
        }
        public ActionResult GetAllUnits()
        {
            var units = service.GetAllUnits()
                .Select(_ => _.UnitOfJobFromDomainToView())
                .ToList()
                ;
            return View(units);
        }

        //Возвращает единицу измерения по её id
        public PartialViewResult GetUnit(int id)
        {
            var unit = service.GetUnit(id)
                .UnitOfJobFromDomainToView()
                ;
            return PartialView(unit);
        }

        //Возвращает единицу измерения по её id
        public string GetTitleOfUnit(int id)
        {
            string unit = service.GetUnit(id)
                .UnitOfJobFromDomainToView()
                .TitleOfUnit
                ;
            return unit;
        }


        public void CreateUnit(UnitOfJob_View inst)
        {
            service.CreateUnit(inst.UnitOfJobFromViewToDomain());
        }

        public void UpdateUnit(UnitOfJob_View inst)
        {
            service.UpdateUnit(inst.UnitOfJobFromViewToDomain());
        }
        public void DeleteUnit(int id)
        {
            service.DeleteUnit(id);
        }
    }
}
