using System.Collections.Generic;
using RemontUnderKey.Infrastructure.Models;

namespace RemontUnderKey.Infrastructure.Interfaces
{
    public interface IPhoto_Repository
    {
        IEnumerable<Photo_Infra> AllPhotosByIdOfRepareobject(int id); // получение коллекции всех фото по id обьекта ремонта (Repareobject)
        IEnumerable<Photo_Infra> GetAllPhotos(); // получение всех объектов
        Photo_Infra GetPhoto(int id); // получение одного объекта по id
        void CreatePhoto(Photo_Infra item); // создание объекта
        void UpdatePhoto(Photo_Infra item); // обновление объекта
        void DeletePhoto(int id); // удаление объекта по id
    }
}
