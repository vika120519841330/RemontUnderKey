using System.Collections.Generic;
using System.Linq;
using RemontUnderKey.Domain.Interfaces;
using RemontUnderKey.Infrastructure.Interfaces;
using RemontUnderKey.Domain.Models;
using RemontUnderKey.DomainServices.Mappers;

namespace RemontUnderKey.DomainServices.Services
{
    public class Upload_Service : IUpload
    {
        private readonly IUpload_Repository repository;
        private readonly IComment_Repository comrepository;
        public Upload_Service(IUpload_Repository _repository, IComment_Repository _comrepository)
        {
            this.repository = _repository;
            this.comrepository = _comrepository;
        }
        // Вспомогательный метод - возвращает коллекцию всех загруженных файлов определенного пользователя по его имени
        public List<Upload_Domain> AllUploadsByNameOfUser(string UserName)
        {
            List<Upload_Domain> listOfAllUploadsOfUser = new List<Upload_Domain>();

            IEnumerable<Comment_Domain> listOfAllCommentsOfUser = new List<Comment_Domain>();
            var temp = comrepository.AllCommentsByNameOfUser(UserName);
            if (temp == null)
            {
                return listOfAllUploadsOfUser;
            }
            else
            {
                listOfAllCommentsOfUser = comrepository.AllCommentsByNameOfUser(UserName)
                    .Select(_ => _.CommentFromInfraToDomain())
                    .ToList()
                    ;
                foreach (Comment_Domain comment in listOfAllCommentsOfUser)
                {
                    var tempList = repository.GetAllUploadByIdOfComment(comment.Id)
                        .Select(_ => _.UploadFromInfraToDomain())
                        .ToList()
                        ;
                    if (tempList != null)
                        listOfAllUploadsOfUser.AddRange(tempList);
                    else return listOfAllUploadsOfUser;
                }
            }
                return listOfAllUploadsOfUser;
        }

        public IEnumerable<Upload_Domain> GetAllUpload()
        {
            var uploads = repository.GetAllUpload()
                .Select(_ => _.UploadFromInfraToDomain())
                .ToList()
                ;
            return uploads;
        }

        public Upload_Domain GetUpload(int? id)
        {
            var comment = repository.GetUpload(id)
                .UploadFromInfraToDomain()
                ;
            return comment;
        }

        //Вспомогательный метод - возвращает файл, относящийся к определенному комментарию(по id комментария)
        public IEnumerable<Upload_Domain> GetAllUploadByIdOfComment(int? id)
        {
            return repository.GetAllUploadByIdOfComment(id)
                .Select(_ => _.UploadFromInfraToDomain())
                .ToList()
                ;
        }

        public int? CreateUpload(Upload_Domain inst)
        {
            return repository.CreateUpload(inst.UploadFromDomainToInfra());
        }

        public void UpdateUpload(Upload_Domain inst)
        {
            repository.UpdateUpload(inst.UploadFromDomainToInfra());
        }
        public void DeleteUpload(int? id)
        {
            repository.DeleteUpload(id);
        }
    }
}
