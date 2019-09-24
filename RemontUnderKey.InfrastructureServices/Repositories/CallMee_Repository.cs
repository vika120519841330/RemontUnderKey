using System.Collections.Generic;
using System.Linq;
using RemontUnderKey.Infrastructure.Interfaces;
using RemontUnderKey.Infrastructure.Models;
using RemontUnderKey.InfrastructureServices.Context;

namespace RemontUnderKey.InfrastructureServices.Repositories
{
    public class CallMee_Repository : ICallMee_Repository
    {
        private readonly MyContext context;
        public CallMee_Repository(MyContext _context)
        {
            this.context = _context;
        }

        public IEnumerable<CallMee_Infra> GetAllCallMee()
        {
            var calls = context.Calls
                .ToList()
                ;
            return calls;
        }

        public CallMee_Infra GetCallMee(int id)
        {
            var call = context.Calls
                .FirstOrDefault(_ => _.Id == id)
                ;
            return call;
        }

        public void CreateCallMee(CallMee_Infra inst)
        {
            context.Calls.Add(inst);
            context.SaveChanges();
        }

        public void UpdateCallMee(CallMee_Infra inst)
        {
            var tempInst = context.Calls.FirstOrDefault(_ => _.Id == inst.Id);
            tempInst.Id = inst.Id;
            tempInst.Name = inst.Name;
            tempInst.Telephone = inst.Telephone;
            tempInst.DateStamp = inst.DateStamp;
            tempInst.Comments = inst.Comments;
            tempInst.CallIsDone = inst.CallIsDone;
            context.SaveChanges();
        }
        public void DeleteCallMee(int id)
        {
            var tmp = context.Calls.Find(id);
            context.Calls.Remove(tmp);
            context.SaveChanges();
        }
    }
}
