using System.Collections.Generic;
using RemontUnderKey.Domain.Models;

namespace RemontUnderKey.Domain.Interfaces
{
    public interface IComment
    {
        IEnumerable<Comment_Domain> AllCommentsByIdOfUser(string id); // получение коллекции всех комментариев определенного пользователя по его id
        IEnumerable<Comment_Domain> GetAllComments(); // получение всех объектов
        Comment_Domain GetComment(int id); // получение одного объекта по id
        void CreateComment(Comment_Domain item); // создание объекта
        void UpdateComment(Comment_Domain item); // обновление объекта
        void DeleteComment(int id); // удаление объекта по id
    }
}
