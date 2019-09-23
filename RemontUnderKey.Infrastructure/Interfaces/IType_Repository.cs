using System.Collections.Generic;
using RemontUnderKey.Infrastructure.Models;

namespace RemontUnderKey.Infrastructure.Interfaces
{
    public interface IType_Repository
    {
        IEnumerable<TypeOfObject_Infra> GetAllTypes(); // получение всех объектов
        TypeOfObject_Infra GetTypeOfObject(int id); // получение одного объекта по id
        void CreateTypeOfObject(TypeOfObject_Infra item); // создание объекта
        void UpdateTypeOfObject(TypeOfObject_Infra item); // обновление объекта
        void DeleteTypeOfObject(int id); // удаление объекта по id
    }
}
