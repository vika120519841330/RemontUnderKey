using System.Collections.Generic;
using RemontUnderKey.Infrastructure.Models;

namespace RemontUnderKey.Infrastructure.Interfaces
{
    public interface IUpload_Repository
    {
        IEnumerable<Upload_Infra> GetAllUpload(); // получение всех объектов
        Upload_Infra GetUpload(int? id); // получение одного объекта по id
        int? CreateUpload(Upload_Infra item); // создание объекта - возвращает Id вновь созданного Файла
        void UpdateUpload(Upload_Infra item); // обновление объекта
        void DeleteUpload(int? id); // удаление объекта по id
    }
}
