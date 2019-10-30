using System.Collections.Generic;
using System.Linq;
using RemontUnderKey.Domain.Interfaces;
using RemontUnderKey.Infrastructure.Interfaces;
using RemontUnderKey.Domain.Models;
using RemontUnderKey.DomainServices.Mappers;

namespace RemontUnderKey.DomainServices.Services
{
    public class Comment_Service : IComment
    {
        private readonly IComment_Repository repository;
        public Comment_Service(IComment_Repository _repository)
        {
            this.repository = _repository;
        }

        //Вспомогательный метод - возвращает коллекцию всех комментариев, относящихся к определенному пользователю
        public IEnumerable<Comment_Domain> AllCommentsByNameOfUser(string UserName)
        {
            var commentsOfUser = repository.AllCommentsByNameOfUser(UserName)
                .Select(_ => _.CommentFromInfraToDomain())
                .Where(_ => _.UserName == UserName)
                .ToList()
                ;
            if (commentsOfUser != null)
            {
                return commentsOfUser;
            }
            return null;
        }

        public IEnumerable<Comment_Domain> GetAllComments()
        {
            var comments = repository.GetAllComments()
                .Select(_ => _.CommentFromInfraToDomain())
                .ToList()
                ;
            return comments;
        }

        public Comment_Domain GetComment(int? id)
        {
            var comment = repository.GetComment(id)
                .CommentFromInfraToDomain()
                ;
            return comment;
        }

        //Метод возвращает Id вновь созданного Отзыва
        public int? CreateComment(Comment_Domain inst)
        {
            return repository.CreateComment(inst.CommentFromDomainToInfra());
        }

        public void UpdateComment(Comment_Domain inst)
        {
            repository.UpdateComment(inst.CommentFromDomainToInfra());
        }
        public void DeleteComment(int? id)
        {
            repository.DeleteComment(id);
        }
    }
}
