using System.Collections.Generic;
using RemontUnderKey.Infrastructure.Models;

namespace RemontUnderKey.Infrastructure.Interfaces
{
    public interface IKind_Repository
    {
        IEnumerable<KindOfJob_Infra> GetAllKinds(); // получение всех объектов
        KindOfJob_Infra GetKind(int id); // получение одного объекта по id
        void CreateKind(KindOfJob_Infra item); // создание объекта
        void UpdateKind(KindOfJob_Infra item); // обновление объекта
        void DeleteKind(int id); // удаление объекта по id
    }
}
