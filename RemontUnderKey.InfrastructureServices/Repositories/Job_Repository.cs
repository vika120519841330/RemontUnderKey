using System.Collections.Generic;
using System.Linq;
using RemontUnderKey.Infrastructure.Interfaces;
using RemontUnderKey.Infrastructure.Models;
using RemontUnderKey.InfrastructureServices.Context;

namespace RemontUnderKey.InfrastructureServices.Repositories
{
    public class Job_Repository : IJob_Repository
    {
        private readonly MyContext context;
        public Job_Repository(MyContext _context)
        {
            this.context = _context;
        }

        //Вспомогательный метод - возвращает коллекцию всех подвидов ремонтных работ, относящихся к определенному виду работ (KindOfJob)
        public IEnumerable<Job_Infra> AllJobsByIdOfkind(int id)
        {
            var jobsOfKind = context.Jobs
                .Where(_ => _.KindOfJob_InfraId == id)
                .ToList()
                ;
            return jobsOfKind;
        }

        public IEnumerable<Job_Infra> GetAllJobs()
        {
            var jobs = context.Jobs
                .ToList()
                ;
            return jobs;
        }

        public Job_Infra GetJob(int id)
        {
            var job = context.Jobs
                .FirstOrDefault(_ => _.Id == id)
                ;
            return job;
        }

        public void CreateJob(Job_Infra inst)
        {
            context.Jobs.Add(inst);
            context.SaveChanges();
        }

        public void UpdateJob(Job_Infra inst)
        {
            var tempInst = context.Jobs.FirstOrDefault(_ => _.Id == inst.Id);
            tempInst.Id = inst.Id;
            tempInst.TitleOfJob = inst.TitleOfJob;
            tempInst.PriceOfUnitOfJob = inst.PriceOfUnitOfJob;
            tempInst.KindOfJob_InfraId = inst.KindOfJob_InfraId;
            tempInst.UnitOfJob_InfraId = inst.UnitOfJob_InfraId;
            context.SaveChanges();
        }
        public void DeleteJob(int id)
        {
            var tmp = context.Jobs.Find(id);
            context.Jobs.Remove(tmp);
            context.SaveChanges();
        }
    }
}
