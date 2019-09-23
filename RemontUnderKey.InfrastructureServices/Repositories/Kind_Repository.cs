using System.Collections.Generic;
using System.Linq;
using RemontUnderKey.Infrastructure.Interfaces;
using RemontUnderKey.Infrastructure.Models;
using RemontUnderKey.InfrastructureServices.Context;

namespace RemontUnderKey.InfrastructureServices.Repositories
{
    public class Kind_Repository : IKind_Repository
    {
        private readonly MyContext context;
        public Kind_Repository(MyContext _context)
        {
            this.context = _context;
        }

        public IEnumerable<KindOfJob_Infra> GetAllKinds()
        {
            var kinds = context.Kinds
                .ToList()
                ;
            return kinds;
        }

        public KindOfJob_Infra GetKind(int id)
        {
            var kind = context.Kinds
                .FirstOrDefault(_ => _.Id == id)
                ;
            return kind;
        }

        public void CreateKind(KindOfJob_Infra inst)
        {
            context.Kinds.Add(inst);
            context.SaveChanges();
        }

        public void UpdateKind(KindOfJob_Infra inst)
        {
            var tempInst = context.Kinds.FirstOrDefault(_ => _.Id == inst.Id);
            tempInst.Id = inst.Id;
            tempInst.TitleOfKindOfJob = inst.TitleOfKindOfJob;
            tempInst.DescriptionOfKindOfJob = inst.DescriptionOfKindOfJob;
            context.SaveChanges();
        }
        public void DeleteKind(int id)
        {
            var tmp = context.Kinds.Find(id);
            context.Kinds.Remove(tmp);
            context.SaveChanges();
        }
    }
}
