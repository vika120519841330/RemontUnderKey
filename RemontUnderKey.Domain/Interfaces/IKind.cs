using System.Collections.Generic;
using RemontUnderKey.Domain.Models;

namespace RemontUnderKey.Domain.Interfaces
{
    public interface IKind
    {
        IEnumerable<KindOfJob_Domain> GetAllKinds(); // получение всех объектов
        KindOfJob_Domain GetKind(int id); // получение одного объекта по id
        void CreateKind(KindOfJob_Domain item); // создание объекта
        void UpdateKind(KindOfJob_Domain item); // обновление объекта
        void DeleteKind(int id); // удаление объекта по id
    }
}
