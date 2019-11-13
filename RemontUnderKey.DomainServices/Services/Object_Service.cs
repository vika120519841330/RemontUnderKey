using System.Collections.Generic;
using System.Linq;
using RemontUnderKey.Domain.Interfaces;
using RemontUnderKey.Infrastructure.Interfaces;
using RemontUnderKey.Domain.Models;
using RemontUnderKey.DomainServices.Mappers;

namespace RemontUnderKey.DomainServices.Services
{
    public class Object_Service : IObject
    {
        private readonly IObject_Repository repository;
        public Object_Service(IObject_Repository _repository)
        {
            this.repository = _repository;
        }

        //Вспомогательный метод - возвращает коллекцию всех обьектов, относящихся к определенному типу обьекта ремонта (TypeOfObject)
        public IEnumerable<Repareobject_Domain> AllRepareobjectByIdOfType(int id)
        {
            var objectsOfType = repository.AllRepareobjectByIdOfType(id)
                .Select(_ => _.RepareobjectFromInfraToDomain())
                .Where(_ => _.TypeOfObject_DomainId == id)
                .ToList()
                ;
            return objectsOfType;
        }

        //Вспомогательный метод - получение наименования обьекта ремонта (Repareobject) по его ID
        public string GetTitleOfObjectById(int? id)
        {
            string upload = repository.GetRepareobject(id).AddressOfRepareobject;
            return upload;
        }

        public IEnumerable<Repareobject_Domain> GetAllRepareobject()
        {
            var repObjects = repository.GetAllRepareobject()
                .Select(_ => _.RepareobjectFromInfraToDomain())
                .ToList()
                ;
            return repObjects;
        }

        public Repareobject_Domain GetRepareobject(int id)
        {
            var repObject = repository.GetRepareobject(id)
                .RepareobjectFromInfraToDomain()
                ;
            return repObject;
        }

        public void CreateRepareobject(Repareobject_Domain inst)
        {
            repository.CreateRepareobject(inst.RepareobjectFromDomainToInfra());
        }

        public void UpdateRepareobject(Repareobject_Domain inst)
        {
            repository.UpdateRepareobject(inst.RepareobjectFromDomainToInfra());
        }
        public void DeleteRepareobject(int id)
        {
            repository.DeleteRepareobject(id);
        }
    }
}
