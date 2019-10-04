using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RemontUnderKey.Domain.Interfaces;
using RemontUnderKey.Web.Mappers;
using RemontUnderKey.Web.Models;


namespace RemontUnderKey.Web.Controllers
{
    public class TypeController : Controller
    {
        private readonly IType service;
        public TypeController(IType _service)
        {
            this.service = _service;
        }
        //Метод выводит в частичное представление наименования всех типов ремонтных работ
        [HttpGet]
        public PartialViewResult GetAllTitleOfTypes()
        {
            ViewBag.Salute = "ПОД КЛЮЧ В МИНСКЕ И МИНСКОЙ ОБЛАСТИ";
            IEnumerable<TypeOfObject_View> types = service.GetAllTypes()
                .Select(_ => _.TypeOfObjectFromDomainToView())
                .ToList()
                ;
            return PartialView(types);
        }

        //Метод выводит в частичное представление описание определенного типа ремонтных работ
        [HttpGet]
        public PartialViewResult GetAllDiscrOfTypes(int id)
        {
            TypeOfObject_View type = service.GetTypeOfObject(id)
                .TypeOfObjectFromDomainToView()
                ;
            return PartialView(type);
        }

    }
}