using System.Collections.Generic;
using System.Linq;
using RemontUnderKey.Infrastructure.Interfaces;
using RemontUnderKey.Infrastructure.Models;
using RemontUnderKey.InfrastructureServices.Context;

namespace RemontUnderKey.InfrastructureServices.Repositories
{
    public class Type_Repository : IType_Repository
    {
        private readonly MyContext context;
        public Type_Repository(MyContext _context)
        {
            this.context = _context;
        }

        public IEnumerable<TypeOfObject_Infra> GetAllTypes()
        {
            var types = context.Types
                .ToList()
                ;
            return types;
        }

        public TypeOfObject_Infra GetTypeOfObject(int id)
        {
            var typeofobj = context.Types
                .FirstOrDefault(_ => _.Id == id)
                ;
            return typeofobj;
        }

        public void CreateTypeOfObject(TypeOfObject_Infra inst)
        {
            context.Types.Add(inst);
            context.SaveChanges();
        }

        public void UpdateTypeOfObject(TypeOfObject_Infra inst)
        {
            var tempInst = context.Types.FirstOrDefault(_ => _.Id == inst.Id);
            tempInst.Id = inst.Id;
            tempInst.TitleOfTypeOfObject = inst.TitleOfTypeOfObject;
            tempInst.DescriptionOfTypeOfObject = inst.DescriptionOfTypeOfObject;
            context.SaveChanges();
        }
        public void DeleteTypeOfObject(int id)
        {
            var tmp = context.Types.Find(id);
            context.Types.Remove(tmp);
            context.SaveChanges();
        }
    }
}
