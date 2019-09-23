using System.Collections.Generic;
using RemontUnderKey.Infrastructure.Models;

namespace RemontUnderKey.Infrastructure.Interfaces
{
    public interface IUnit_Repository
    {
        IEnumerable<UnitOfJob_Infra> GetAllUnits(); // получение всех объектов
        UnitOfJob_Infra GetUnit(int id); // получение одного объекта по id
        void CreateUnit(UnitOfJob_Infra item); // создание объекта
        void UpdateUnit(UnitOfJob_Infra item); // обновление объекта
        void DeleteUnit(int id); // удаление объекта по id
    }
}
