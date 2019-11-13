using System.Collections.Generic;
using RemontUnderKey.Infrastructure.Models;

namespace RemontUnderKey.Infrastructure.Interfaces
{
    public interface IUploadPhoto_Repository
    {
        IEnumerable<UploadPhoto_Infra> AllUploadPhotosByIdOfObject(int? id); // получение коллекции всех фото по id обьекта ремонта (Repareobject)
        IEnumerable<UploadPhoto_Infra> GetAllUploadPhotos(); // получение всех объектов
        UploadPhoto_Infra GetUploadPhoto(int? id); // получение одного объекта по id
        int? CreateUploadPhoto(UploadPhoto_Infra item); // создание объекта - возвращает id созданного обьекта
        void UpdateUploadPhoto(UploadPhoto_Infra item); // обновление объекта
        void DeleteUploadPhoto(int? id); // удаление объекта по id
    }
}
