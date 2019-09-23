using System.Collections.Generic;
using System.Linq;
using RemontUnderKey.Infrastructure.Interfaces;
using RemontUnderKey.Infrastructure.Models;
using RemontUnderKey.InfrastructureServices.Context;

namespace RemontUnderKey.InfrastructureServices.Repositories
{
    public class Photo_Repository : IPhoto_Repository
    {
        private readonly MyContext context;
        public Photo_Repository(MyContext _context)
        {
            this.context = _context;
        }

        //Вспомогательный метод - возвращает коллекцию всех фото, относящихся к определенному обьекту ремонта (Repareobject)
        public IEnumerable<Photo_Infra> AllPhotosByIdOfObject(int id)
        {
            var photosOfObject = context.Photos
                .Where(_ => _.Repareobject_InfraId == id)
                .ToList()
                ;
            return photosOfObject;
        }

        public IEnumerable<Photo_Infra> GetAllPhotos()
        {
            var photos = context.Photos
                .ToList()
                ;
            return photos;
        }

        public Photo_Infra GetPhoto(int id)
        {
            var photo = context.Photos
                .FirstOrDefault(_ => _.Id == id)
                ;
            return photo;
        }

        public void CreatePhoto(Photo_Infra inst)
        {
            context.Photos.Add(inst);
            context.SaveChanges();
        }

        public void UpdatePhoto(Photo_Infra inst)
        {
            var tempInst = context.Photos.FirstOrDefault(_ => _.Id == inst.Id);
            tempInst.Id = inst.Id;
            tempInst.ImgSrc = inst.ImgSrc;
            tempInst.Repareobject_InfraId = inst.Repareobject_InfraId;
            context.SaveChanges();
        }
        public void DeletePhoto(int id)
        {
            var tmp = context.Photos.Find(id);
            context.Photos.Remove(tmp);
            context.SaveChanges();
        }
    }
}
