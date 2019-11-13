using System.Collections.Generic;
using System.Linq;
using RemontUnderKey.Infrastructure.Interfaces;
using RemontUnderKey.Infrastructure.Models;
using RemontUnderKey.InfrastructureServices.Context;

namespace RemontUnderKey.InfrastructureServices.Repositories
{
    public class UploadPhoto_Repository : IUploadPhoto_Repository
    {
        private readonly MyContext context;
        public UploadPhoto_Repository(MyContext _context)
        {
            this.context = _context;
        }

        public IEnumerable<UploadPhoto_Infra> GetAllUploadPhotos()
        {
            var uploads = context.UploadPhotos
                .ToList()
                ;
            return uploads;
        }

        public UploadPhoto_Infra GetUploadPhoto(int? id)
        {
            var upload = context.UploadPhotos
                .FirstOrDefault(_ => _.Id == id)
                ;
            return upload;
        }

        //Вспомогательный метод - получение коллекции всех фото по id обьекта ремонта (Repareobject)
        public IEnumerable<UploadPhoto_Infra> AllUploadPhotosByIdOfObject(int? id)
        {
            List<UploadPhoto_Infra> upload = context.UploadPhotos
                .Where(_ => _.Repareobject_InfraId == id)
                .ToList()
                ;
            if (upload != null)
            {
                return upload;
            }
            else
            {
                List<UploadPhoto_Infra> templist = new List<UploadPhoto_Infra>();
                UploadPhoto_Infra temp = new UploadPhoto_Infra{ };
                templist.Add(temp);
                return templist;
            }
        }

        //Метод возвращает Id вновь созданного Файла
        public int? CreateUploadPhoto(UploadPhoto_Infra inst)
        {
            UploadPhoto_Infra temp = inst as UploadPhoto_Infra;
            temp.File = inst.File;
            temp.FileName = inst.FileName;
            temp.FileType = inst.FileType;
            temp.Id = null;
            temp.Repareobject_InfraId = inst.Repareobject_InfraId;
            context.UploadPhotos.Add(temp);
            context.SaveChanges();
            UploadPhoto_Infra tempId = context.UploadPhotos
                .Last(_ => _.Repareobject_InfraId == temp.Repareobject_InfraId)
                ;
            return tempId.Id;
        }

        public void UpdateUploadPhoto(UploadPhoto_Infra inst)
        {
            var tempInst = context.UploadPhotos.FirstOrDefault(_ => _.Id == inst.Id);
            tempInst.Id = inst.Id;
            tempInst.Repareobject_InfraId = inst.Repareobject_InfraId;
            tempInst.File = inst.File;
            tempInst.FileName = inst.FileName;
            tempInst.FileType = inst.FileType;
            context.SaveChanges();
        }
        public void DeleteUploadPhoto(int? id)
        {
            var tmp = context.UploadPhotos.Find(id);
            context.UploadPhotos.Remove(tmp);
            context.SaveChanges();
        }
    }
}
