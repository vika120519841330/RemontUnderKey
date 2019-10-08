using System.Collections.Generic;
using System.Linq;
using RemontUnderKey.Infrastructure.Interfaces;
using RemontUnderKey.Infrastructure.Models;
using RemontUnderKey.InfrastructureServices.Context;

namespace RemontUnderKey.InfrastructureServices.Repositories
{
    public class Stage_Repository : IStage_Repository
    {
        private readonly MyContext context;
        public Stage_Repository(MyContext _context)
        {
            this.context = _context;
        }

        public IEnumerable<Stage_Infra> GetAllStages()
        {
            var stages = context.Stages
                .ToList()
                ;
            return stages;
        }

        public Stage_Infra GetStage(int id)
        {
            var stage = context.Stages
                .FirstOrDefault(_ => _.Id == id)
                ;
            return stage;
        }

        public void CreateStage(Stage_Infra inst)
        {
            context.Stages.Add(inst);
            context.SaveChanges();
        }

        public void UpdateStage(Stage_Infra inst)
        {
            var tempInst = context.Stages.FirstOrDefault(_ => _.Id == inst.Id);
            tempInst.Id = inst.Id;
            tempInst.ImgSrc = inst.ImgSrc;
            tempInst.DescriptionOfStage = inst.DescriptionOfStage;
            context.SaveChanges();
        }
        public void DeleteStage(int id)
        {
            var tmp = context.Stages.Find(id);
            context.Stages.Remove(tmp);
            context.SaveChanges();
        }
    }
}
