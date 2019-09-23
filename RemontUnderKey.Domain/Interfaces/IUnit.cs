using System.Collections.Generic;
using RemontUnderKey.Domain.Models;

namespace RemontUnderKey.Domain.Interfaces
{
    public interface IUnit
    {
        IEnumerable<UnitOfJob_Domain> GetAllUnits(); // получение всех объектов
        UnitOfJob_Domain GetUnit(int id); // получение одного объекта по id
        void CreateUnit(UnitOfJob_Domain item); // создание объекта
        void UpdateUnit(UnitOfJob_Domain item); // обновление объекта
        void DeleteUnit(int id); // удаление объекта по id
    }
}
