using System.Collections.Generic;
using System.Linq;
using RemontUnderKey.Domain.Interfaces;
using RemontUnderKey.Infrastructure.Interfaces;
using RemontUnderKey.Domain.Models;
using RemontUnderKey.DomainServices.Mappers;

namespace RemontUnderKey.DomainServices.Services
{
    public class Photo_Service : IPhoto
    {
        private readonly IPhoto_Repository repository;
        public Photo_Service(IPhoto_Repository _repository)
        {
            this.repository = _repository;
        }

        //Вспомогательный метод - возвращает коллекцию всех фото, относящихся к определенному обьекту ремонта (Repareobject)
        public IEnumerable<Photo_Domain> AllPhotosByIdOfObject(int id)
        {
            var photosOfObject = repository.AllPhotosByIdOfObject(id)
                .Select(_ => _.PhotoFromInfraToDomain())
                .Where(_ => _.Repareobject_DomainId == id)
                .ToList()
                ;
            return photosOfObject;
        }

        public IEnumerable<Photo_Domain> GetAllPhotos()
        {
            var photos = repository.GetAllPhotos()
                .Select(_ => _.PhotoFromInfraToDomain())
                .ToList()
                ;
            return photos;
        }

        public Photo_Domain GetPhoto(int id)
        {
            var photo = repository.GetPhoto(id)
                .PhotoFromInfraToDomain()
                ;
            return photo;
        }

        public void CreatePhoto(Photo_Domain inst)
        {
            repository.CreatePhoto(inst.PhotoFromDomainToInfra());
        }

        public void UpdatePhoto(Photo_Domain inst)
        {
            repository.UpdatePhoto(inst.PhotoFromDomainToInfra());
        }
        public void DeletePhoto(int id)
        {
            repository.DeletePhoto(id);
        }
    }
}
