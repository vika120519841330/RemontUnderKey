using System.Collections.Generic;
using RemontUnderKey.Domain.Models;

namespace RemontUnderKey.Domain.Interfaces
{
    public interface ICallMee
    {
        IEnumerable<CallMee_Domain> GetAllCallMee(); // получение всех объектов
        CallMee_Domain GetCallMee(int id); // получение одного объекта по id
        void CreateCallMee(CallMee_Domain item); // создание объекта
        void UpdateCallMee(CallMee_Domain item); // обновление объекта
        void DeleteCallMee(int id); // удаление объекта по id
    }
}
