using System.Collections.Generic;
using System.Linq;
using RemontUnderKey.Infrastructure.Interfaces;
using RemontUnderKey.Infrastructure.Models;
using RemontUnderKey.InfrastructureServices.Context;

namespace RemontUnderKey.InfrastructureServices.Repositories
{
    public class Object_Repository : IObject_Repository
    {
        private readonly MyContext context;
        public Object_Repository(MyContext _context)
        {
            this.context = _context;
        }

        //Вспомогательный метод - возвращает коллекцию всех обьектов, относящихся к определенному типу обьекта ремонта (TypeOfObject)
        public IEnumerable<Repareobject_Infra> AllRepareobjectByIdOfType(int id)
        {
            var objectsOfType = context.Repareobjects
                .Where(_ => _.TypeOfObject_InfraId == id)
                .ToList()
                ;
            return objectsOfType;
        }

        public IEnumerable<Repareobject_Infra> GetAllRepareobject()
        {
            var repObjects = context.Repareobjects
                .ToList()
                ;
            return repObjects;
        }

        public Repareobject_Infra GetRepareobject(int? id)
        {
            var repObject = context.Repareobjects
                .FirstOrDefault(_ => _.Id == id)
                ;
            return repObject;
        }

        public void CreateRepareobject(Repareobject_Infra inst)
        {
            context.Repareobjects.Add(inst);
            context.SaveChanges();
        }

        public void UpdateRepareobject(Repareobject_Infra inst)
        {
            var tempInst = context.Repareobjects.FirstOrDefault(_ => _.Id == inst.Id);
            tempInst.Id = inst.Id;
            tempInst.AddressOfRepareobject = inst.AddressOfRepareobject;
            tempInst.TypeOfObject_InfraId = inst.TypeOfObject_InfraId;
            context.SaveChanges();
        }
        public void DeleteRepareobject(int id)
        {
            var tmp = context.Repareobjects.Find(id);
            context.Repareobjects.Remove(tmp);
            context.SaveChanges();
        }
    }
}
