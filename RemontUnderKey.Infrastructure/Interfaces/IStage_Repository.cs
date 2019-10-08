using System.Collections.Generic;
using RemontUnderKey.Infrastructure.Models;

namespace RemontUnderKey.Infrastructure.Interfaces
{
    public interface IStage_Repository
    {
        IEnumerable<Stage_Infra> GetAllStages(); // получение всех объектов
        Stage_Infra GetStage(int id); // получение одного объекта по id
        void CreateStage(Stage_Infra item); // создание объекта
        void UpdateStage(Stage_Infra item); // обновление объекта
        void DeleteStage(int id); // удаление объекта по id
    }
}
