using System.Collections.Generic;
using RemontUnderKey.Domain.Models;

namespace RemontUnderKey.Domain.Interfaces
{
    public interface IPhoto
    {
        IEnumerable<Photo_Domain> AllPhotosByIdOfObject(int id); // получение коллекции всех фото по id обьекта ремонта (Repareobject)
        IEnumerable<Photo_Domain> GetAllPhotos(); // получение всех объектов
        Photo_Domain GetPhoto(int id); // получение одного объекта по id
        void CreatePhoto(Photo_Domain item); // создание объекта
        void UpdatePhoto(Photo_Domain item); // обновление объекта
        void DeletePhoto(int id); // удаление объекта по id
    }
}
