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
            var comments = context.Comments
                .ToList()
                ;
            return comments;
        }

        public Comment_Infra GetComment(int id)
        {
            var comment = context.Comments
                .FirstOrDefault(_ => _.Id == id)
                ;
            return comment;
        }

        public void CreateComment(Comment_Infra inst)
        {
            context.Comments.Add(inst);
            context.SaveChanges();
        }

        public void UpdateComment(Comment_Infra inst)
        {
            var tempInst = context.Comments.FirstOrDefault(_ => _.Id == inst.Id);
            tempInst.Id = inst.Id;
            tempInst.UserName = inst.UserName;
            tempInst.UserId = inst.UserId;
            tempInst.MessageFromUser = inst.MessageFromUser;
            tempInst.ApprovalForPublishing = inst.ApprovalForPublishing;
            context.SaveChanges();
        }
        public void DeleteComment(int id)
        {
            var tmp = context.Comments.Find(id);
            context.Comments.Remove(tmp);
            context.SaveChanges();
        }
    }
}
