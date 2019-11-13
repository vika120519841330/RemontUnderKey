using System.Collections.Generic;
using System.Linq;
using RemontUnderKey.Domain.Interfaces;
using RemontUnderKey.Infrastructure.Interfaces;
using RemontUnderKey.Domain.Models;
using RemontUnderKey.DomainServices.Mappers;

namespace RemontUnderKey.DomainServices.Services
{
    public class UploadPhoto_Service : IUploadPhoto
    {
        private readonly IUploadPhoto_Repository repository;

        public UploadPhoto_Service(IUploadPhoto_Repository _repository)
        {
            this.repository = _repository;
        }
        public IEnumerable<UploadPhoto_Domain> GetAllUploadPhotos()
        {
            var uploads = repository.GetAllUploadPhotos()
                .Select(_ => _.UploadPhotoFromInfraToDomain())
                .ToList()
                ;
            return uploads;
        }

        public UploadPhoto_Domain GetUploadPhoto(int? id)
        {
            var upload = repository.GetUploadPhoto(id)
                .UploadPhotoFromInfraToDomain()
                ;
            return upload;
        }

        //Вспомогательный метод - получение коллекции всех фото по id обьекта ремонта (Repareobject)
        public IEnumerable<UploadPhoto_Domain> AllUploadPhotosByIdOfObject(int? id)
        {
            var upload = repository.AllUploadPhotosByIdOfObject(id)
                .Select(_ => _.UploadPhotoFromInfraToDomain())
                .ToList()
                ;
            return upload;
        }

        //Метод возвращает Id вновь созданного Файла
        public int? CreateUploadPhoto(UploadPhoto_Domain inst)
        {
            int? tempId = repository.CreateUploadPhoto(inst.UploadPhotoFromDomainToInfra());
            return tempId;
        }

        public void UpdateUploadPhoto(UploadPhoto_Domain inst)
        {
            repository.UpdateUploadPhoto(inst.UploadPhotoFromDomainToInfra());
        }
        public void DeleteUploadPhoto(int? id)
        {
            repository.DeleteUploadPhoto(id);
        }

    }
}
