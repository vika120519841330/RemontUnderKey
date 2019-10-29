using System.Collections.Generic;
using RemontUnderKey.Domain.Models;

namespace RemontUnderKey.Domain.Interfaces
{
    public interface IUpload
    {
        IEnumerable<Upload_Domain> GetAllUpload(); // получение всех объектов
        Upload_Domain GetUpload(int? id); // получение одного объекта по id
        int? CreateUpload(Upload_Domain item); // создание объекта - возвращает Id вновь созданного Файла
        void UpdateUpload(Upload_Domain item); // обновление объекта
        void DeleteUpload(int? id); // удаление объекта по id
    }
}
