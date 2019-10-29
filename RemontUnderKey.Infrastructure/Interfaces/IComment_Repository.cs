using System.Collections.Generic;
using RemontUnderKey.Infrastructure.Models;

namespace RemontUnderKey.Infrastructure.Interfaces
{
    public interface IComment_Repository
    {
        IEnumerable<Comment_Infra> AllCommentsByIdOfUser(string id); // получение коллекции всех комментариев определенного пользователя по его id
        IEnumerable<Comment_Infra> GetAllComments(); // получение всех объектов
        Comment_Infra GetComment(int? id); // получение одного объекта по id
        int? CreateComment(Comment_Infra item); // возвращает Id вновь созданного отзыва
        void UpdateComment(Comment_Infra item); // обновление объекта
        void DeleteComment(int? id); // удаление объекта по id
    }
}
