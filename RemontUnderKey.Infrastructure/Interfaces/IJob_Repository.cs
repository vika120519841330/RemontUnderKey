using System.Collections.Generic;
using RemontUnderKey.Infrastructure.Models;

namespace RemontUnderKey.Infrastructure.Interfaces
{
    public interface IJob_Repository
    {
        IEnumerable<Job_Infra> AllJobsByIdOfkind(int id); // получение коллекции всех подвидов ремонтных работ по id вида работ (KindOfJob)
        IEnumerable<Job_Infra> GetAllJobs(); // получение всех объектов
        Job_Infra GetJob(int id); // получение одного объекта по id
        void CreateJob(Job_Infra item); // создание объекта
        void UpdateJob(Job_Infra item); // обновление объекта
        void DeleteJob(int id); // удаление объекта по id
    }
}
