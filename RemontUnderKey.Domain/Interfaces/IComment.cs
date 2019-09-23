using System.Collections.Generic;
using RemontUnderKey.Domain.Models;

namespace RemontUnderKey.Infrastructure.Interfaces
{
    public interface IComment_Repository
    {
        IEnumerable<Comment_Infra> AllCommentsByIdOfUser(int id); // получение коллекции всех комментариев определенного пользователя по его id
        IEnumerable<Comment_Infra> GetAllComments(); // получение всех объектов
        Comment_Infra GetComment(int id); // получение одного объекта по id
        void CreateComment(Comment_Infra item); // создание объекта
        void UpdateComment(Comment_Infra item); // обновление объекта
        void DeleteComment(int id); // удаление объекта по id
    }
}
