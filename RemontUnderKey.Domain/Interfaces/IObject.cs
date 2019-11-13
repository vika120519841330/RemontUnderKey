using System.Collections.Generic;
using RemontUnderKey.Domain.Models;

namespace RemontUnderKey.Domain.Interfaces
{
    public interface IObject
    {
        IEnumerable<Repareobject_Domain> AllRepareobjectByIdOfType(int id); // получение коллекции всех обьектов по id типа обьекта ремонта (TypeOfObject)
        IEnumerable<Repareobject_Domain> GetAllRepareobject(); // получение всех объектов
        Repareobject_Domain GetRepareobject(int id); // получение одного объекта по id
        void CreateRepareobject(Repareobject_Domain item); // создание объекта
        void UpdateRepareobject(Repareobject_Domain item); // обновление объекта
        void DeleteRepareobject(int id); // удаление объекта по id
        string GetTitleOfObjectById(int? id); // вспомогательный метод - получение наименования обьекта ремонта (Repareobject) по его ID

    }
}
