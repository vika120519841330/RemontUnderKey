using System.Collections.Generic;
using RemontUnderKey.Infrastructure.Models;

namespace RemontUnderKey.Infrastructure.Interfaces
{
    public interface ICallMee_Repository
    {
        IEnumerable<CallMee_Infra> GetAllCallMee(); // получение всех объектов
        Job_Infra GetCallMee(int id); // получение одного объекта по id
        void CreateCallMee(CallMee_Infra item); // создание объекта
        void UpdateCallMee(CallMee_Infra item); // обновление объекта
        void DeleteJob(int id); // удаление объекта по id
    }
}
