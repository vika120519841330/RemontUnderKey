using System.Collections.Generic;
using RemontUnderKey.Infrastructure.Models;

namespace RemontUnderKey.Infrastructure.Interfaces
{
    public interface IObject_Repository
    {
        IEnumerable<Repareobject_Infra> AllRepareobjectByIdOfType(int id); // получение коллекции всех обьектов по id типа обьекта ремонта (TypeOfObject)
        IEnumerable<Repareobject_Infra> GetAllRepareobject(); // получение всех объектов
        Repareobject_Infra GetRepareobject(int id); // получение одного объекта по id
        void CreateRepareobject(Repareobject_Infra item); // создание объекта
        void UpdateRepareobject(Repareobject_Infra item); // обновление объекта
        void DeleteRepareobject(int id); // удаление объекта по id
    }
}
