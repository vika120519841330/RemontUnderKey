using System.Collections.Generic;
using RemontUnderKey.Domain.Models;

namespace RemontUnderKey.Domain.Interfaces
{
    public interface IType
    {
        IEnumerable<TypeOfObject_Domain> GetAllTypes(); // получение всех объектов
        TypeOfObject_Domain GetTypeOfObject(int id); // получение одного объекта по id
        void CreateTypeOfObject(TypeOfObject_Domain item); // создание объекта
        void UpdateTypeOfObject(TypeOfObject_Domain item); // обновление объекта
        void DeleteTypeOfObject(int id); // удаление объекта по id
    }
}
