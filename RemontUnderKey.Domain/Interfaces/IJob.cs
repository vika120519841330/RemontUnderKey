using System.Collections.Generic;
using RemontUnderKey.Domain.Models;

namespace RemontUnderKey.Domain.Interfaces
{
    public interface IJob
    {
        IEnumerable<Job_Domain> AllJobsByIdOfkind(int id); // получение коллекции всех подвидов ремонтных работ по id вида работ (KindOfJob)
        IEnumerable<Job_Domain> GetAllJobs(); // получение всех объектов
        Job_Domain GetJob(int id); // получение одного объекта по id
        void CreateJob(Job_Domain item); // создание объекта
        void UpdateJob(Job_Domain item); // обновление объекта
        void DeleteJob(int id); // удаление объекта по id
    }
}
