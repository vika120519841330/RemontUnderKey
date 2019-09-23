using System.Collections.Generic;
using System.Linq;
using RemontUnderKey.Domain.Interfaces;
using RemontUnderKey.Infrastructure.Interfaces;
using RemontUnderKey.Domain.Models;
using RemontUnderKey.DomainServices.Mappers;

namespace RemontUnderKey.DomainServices.Services
{
    public class Job_Service : IJob
    {
        private readonly IJob_Repository repository;
        public Job_Service(IJob_Repository _repository)
        {
            this.repository = _repository;
        }

        //Вспомогательный метод - возвращает коллекцию всех подвидов ремонтных работ, относящихся к определенному виду работ (KindOfJob)
        public IEnumerable<Job_Domain> AllJobsByIdOfkind(int id)
        {
            var jobsOfKind = repository.AllJobsByIdOfkind(id)
                .Select(_ => _.JobFromInfraToDomain())
                .Where(_ => _.KindOfJob_DomainId == id)
                .ToList()
                ;
            return jobsOfKind;
        }

        public IEnumerable<Job_Domain> GetAllJobs()
        {
            var jobs = repository.GetAllJobs()
                .Select(_ => _.JobFromInfraToDomain())
                .ToList()
                ;
            return jobs;
        }

        public Job_Domain GetJob(int id)
        {
            var job = repository.GetJob(id)
                .JobFromInfraToDomain()
                ;
            return job;
        }

        public void CreateJob(Job_Domain inst)
        {
            repository.CreateJob(inst.JobFromDomainToInfra());
        }

        public void UpdateJob(Job_Domain inst)
        {
            repository.UpdateJob(inst.JobFromDomainToInfra());
        }
        public void DeleteJob(int id)
        {
            repository.DeleteJob(id);
        }
    }
}
