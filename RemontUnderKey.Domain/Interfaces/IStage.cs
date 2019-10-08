using System.Collections.Generic;
using RemontUnderKey.Domain.Models;

namespace RemontUnderKey.Domain.Interfaces
{
    public interface IStage
    {
        IEnumerable<Stage_Domain> GetAllStages(); // получение всех объектов
        Stage_Domain GetStage(int id); // получение одного объекта по id
        void CreateStage(Stage_Domain item); // создание объекта
        void UpdateStage(Stage_Domain item); // обновление объекта
        void DeleteStage(int id); // удаление объекта по id

    }
}
