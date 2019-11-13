using System.Collections.Generic;
using RemontUnderKey.Domain.Models;

namespace RemontUnderKey.Domain.Interfaces
{
    public interface IUploadPhoto
    {
        IEnumerable<UploadPhoto_Domain> AllUploadPhotosByIdOfObject(int? id); // получение коллекции всех фото по id обьекта ремонта (Repareobject)
        IEnumerable<UploadPhoto_Domain> GetAllUploadPhotos(); // получение всех объектов
        UploadPhoto_Domain GetUploadPhoto(int? id); // получение одного объекта по id
        int? CreateUploadPhoto(UploadPhoto_Domain item); // создание объекта - возвращает id созданного обьекта
        void UpdateUploadPhoto(UploadPhoto_Domain item); // обновление объекта
        void DeleteUploadPhoto(int? id); // удаление объекта по id
    }
}
