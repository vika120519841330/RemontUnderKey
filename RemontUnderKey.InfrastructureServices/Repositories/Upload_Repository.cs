using System.Collections.Generic;
using System.Linq;
using RemontUnderKey.Infrastructure.Interfaces;
using RemontUnderKey.Infrastructure.Models;
using RemontUnderKey.InfrastructureServices.Context;

namespace RemontUnderKey.InfrastructureServices.Repositories
{
    public class Upload_Repository : IUpload_Repository
    {
        private readonly MyContext context;
        public Upload_Repository(MyContext _context)
        {
            this.context = _context;
        }

        public IEnumerable<Upload_Infra> GetAllUpload()
        {
            var uploads = context.Uploads
                .ToList()
                ;
            return uploads;
        }

        public Upload_Infra GetUpload(int? id)
        {
            var upload = context.Uploads
                .FirstOrDefault(_ => _.Id == id)
                ;
            return upload;
        }

        //Вспомогательный метод - возвращает файл, относящийся к определенному комментарию(по id комментария)
        public IEnumerable<Upload_Infra> GetAllUploadByIdOfComment(int? id)
        {
            List<Upload_Infra> upload = context.Uploads
                .Where(_ => _.Comment_InfraId == id)
                .ToList()
                ;
            if (upload != null)
            {
                return upload;
            }
            else
            {
                List<Upload_Infra> templist = new List<Upload_Infra>();
                Upload_Infra temp = new Upload_Infra{ };
                templist.Add(temp);
                return templist;
            }
        }

        //Метод возвращает Id вновь созданного Файла
        public int? CreateUpload(Upload_Infra inst)
        {
            Upload_Infra temp = inst;
            temp.File = inst.File;
            temp.Id = null;
            temp.Comment_InfraId = inst.Comment_InfraId;
            context.Uploads.Add(temp);
            context.SaveChanges();
            Upload_Infra tempId = context.Uploads
                .FirstOrDefault(_ => _.Comment_InfraId == temp.Comment_InfraId)
                ;
                return tempId.Id;
        }

        public void UpdateUpload(Upload_Infra inst)
        {
            var tempInst = context.Uploads.FirstOrDefault(_ => _.Id == inst.Id);
            tempInst.Id = inst.Id;
            tempInst.Comment_InfraId = inst.Comment_InfraId;
            tempInst.File = inst.File;
            context.SaveChanges();
        }
        public void DeleteUpload(int? id)
        {
            var tmp = context.Uploads.Find(id);
            context.Uploads.Remove(tmp);
            context.SaveChanges();
        }
    }
}
