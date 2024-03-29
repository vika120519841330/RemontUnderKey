﻿using RemontUnderKey.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RemontUnderKey.Web.Mappers;
using RemontUnderKey.Web.Models;
using System.Threading.Tasks;
using Telegram.Bot;
using RemontUnderKey.Web.Identity;
using System.Web.Routing;
using System.Collections;

namespace RemontUnderKey.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly IComment service;
        private readonly IUpload upservice;
        private HookController hc;
        private static TelegramBotClient tg_client;
        private string redirectMessage;
        private readonly ApplicationUserManager userManager;
        private Comment_View comment;
        private Upload_View upload;
        private List<Comment_View> listComments = new List<Comment_View>();
        private List<Upload_View> listUplosds = new List<Upload_View>();

        public CommentController(IComment _service, IUpload _upservice, ApplicationUserManager _userManager)
        {
            this.service = _service;
            this.upservice = _upservice;
            this.userManager = _userManager;
        }
        [HttpGet]
        [Route("Comment/GetAllComments")]
        public ActionResult GetAllComments()
        {
            ViewBag.Title = "ПРОСМОТР ОТЗЫВОВ ЗАРЕГИСТРИРОВАННЫХ ПОЛЬЗОВАТЕЛЕЙ";
            listComments = service.GetAllComments()
                .Where(_ => _.ApprovalForPublishing == true)
                .Select(_ => _.CommentFromDomainToView())
                .OrderBy(_ => _.Id)
                .ToList()
                ;
            if (listComments.Count > 0)
            {
                TempData["FirstComment"] = listComments.First();
            }
            return View(listComments);
        }

        [HttpGet]
        [Route("Comment/GetAllCommentsWithoutFilter")]
        public ActionResult GetAllCommentsWithoutFilter()
        {
            IEnumerable<Comment_View> comments = service.GetAllComments()
                .Select(_ => _.CommentFromDomainToView())
                .OrderBy(t => t.Id)
                .ToList()
                ;
            return View(comments);
        }

        [HttpGet]
        [Route("Comment/GetComment/id")]
        public ActionResult GetComment(int id)
        {
            ViewBag.Title = "ПРОСМОТР ОТЗЫВА";
            Comment_View comment = service.GetComment(id)
                .CommentFromDomainToView()
                ;
            return View(comment);
        }

        //Опубликовать отзыв на сайте вправе только зарегистрированный пользователь
        [Authorize(Roles = "admin, user")]
        [HttpGet]
        [Route("Comment/CreateComment")]
        public ActionResult CreateComment()
        {
            ViewBag.Title = $"ДОБАВЛЕНИЕ ОТЗЫВА ЗАРЕГИСТРИРОВАННЫМ ПОЛЬЗОВАТЕЛЕМ";
            if (!(User.IsInRole("admin") || User.IsInRole("user")))
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                //проверяем, есть ли у текущего пользователя ранее оставленные комментарии по его логину
                string UserName = GetDataAboutUser().ElementAt(1).ToString();
                string UserId = GetDataAboutUser().ElementAt(0).ToString();
                listComments = service.AllCommentsByNameOfUser(UserName)
                                                                        .Select(_ => _.CommentFromDomainToView())
                                                                        .ToList()
                                                                        ;
                //если сохраненных отзывов нет - создаем новые
                string lengthOfAllCommentsOfUser = "";
                foreach (Comment_View tempcomment in listComments)
                {
                    lengthOfAllCommentsOfUser = String.Concat(lengthOfAllCommentsOfUser, tempcomment.MessageFromUser);
                }
                if (listComments.Count() == 0)
                {
                    ViewBag.Salute = $"ПОЛЬЗОВАТЕЛЬ {UserName} ОСТАВЬТЕ, ПОЖАЛУЙСТА, СВОЙ ПЕРВЫЙ ОТЗЫВ НА САЙТЕ!";
                    comment = new Comment_View();
                    comment.UserId = UserId;
                    comment.UserName = UserName;
                    int? tempIdOfComment = service.CreateComment(comment.CommentFromViewToDomain());
                    comment = service.GetComment(tempIdOfComment).CommentFromDomainToView();
                    return View("CreateComment", comment);
                }
                else
                {
                    //если сохраненные отзывовы есть - редактируем последний(заменяем старый на новый), дабы пользователь не мог оставить более одного отзыва на сайте
                    ViewBag.Salute = $"ПОЛЬЗОВАТЕЛЬ {UserName} МОЖЕТЕ ОСТАВИТЬ ЕЩЕ ОДИН ОТЗЫВ НА НАШЕМ САЙТЕ!";
                    // Получение последного оставленного текущим пользователем отзыва
                    comment = listComments.Last();                                            
                    return View("CreateComment", comment);
                }
            }
        }

        [HttpGet]
        [Route("Comment/CreateCommentRedirect/{id:int}/{res:string}")]
        public ViewResult CreateCommentRedirect(int id, string res)
        {
            int commentId = id;
            string resultUpload = res;
            comment = service.GetComment(commentId).CommentFromDomainToView();
            int idofComment = comment.Id;
            ViewBag.ResultFromUpload = resultUpload;
            return View("CreateComment", comment);
        }

        [HttpPost]
        [Route("Comment/CreateComment/")]
        public async Task<ViewResult> CreateComment([System.Web.Http.FromBody]Comment_View inst)
        {
            ViewBag.Title = $"ДОБАВЛЕНИЕ ОТЗЫВА ЗАРЕГИСТРИРОВАННЫМ ПОЛЬЗОВАТЕЛЕМ {inst.UserName}";
            ViewBag.Salute = $"{inst.UserName} МЫ БУДЕМ РАДЫ ВАШЕМУ ОТЗЫВУ!";
            if (inst.MessageFromUser.Length == 0)
            {
                ModelState.AddModelError("CreateCommentNull", "Вы не добавили свой отзыв!!!");
                ViewBag.Message = "Оставьте свой отзыв!!!";
                return View("CreateComment", inst);
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("CreateCommentNotVal", "Указанные данные для отправки отзыва не валидны!!!");
                ViewBag.Message = "Валидация НЕ пройдена! Проверьте введенные сведения на достоверность!";
                return View("CreateComment", inst);
            }
            else
            {
                service.UpdateComment(inst.CommentFromViewToDomain());
                ViewBag.Result = "Thank you! Your feedback is accepted and sent for moderation!";
                // Сформировать текстовое сообщение для перенаправления в telegram и viber
                redirectMessage = (DateTime.Now.ToString() + " " + inst.UserName + " " + " ОТЗЫВ: " + inst.MessageFromUser + ";").ToString();
                //Инициализировать массив синхронных задач
                var taskList = new Task[2]
                {
                    // Вызвать метод, инициализирующий telegram-bot
                    RedirectToTelegram(redirectMessage),
                    // Вызвать метод, инициализирующий viber-bot
                    RedirectToViber(redirectMessage)
                };
                await Task.WhenAll(taskList);
                //Ожидаем завершения всех задач из массива задач
                Task.WaitAll(taskList);
                // удаляем все пустые и сохранененные отзывы текущего пользователя из БД
                var AllCommentsByUser = service.AllCommentsByNameOfUser(User.Identity.Name)
                                                                        .Select(_ => _.CommentFromDomainToView())
                                                                        .ToList()
                                                                        ;
                foreach (var comment in AllCommentsByUser)
                {
                    listUplosds = upservice.GetAllUploadByIdOfComment(comment.Id)
                                                                        .Select(_ => _.UploadFromDomainToView())
                                                                        .ToList()
                                                                        ;
                    if ((comment.MessageFromUser.Length == 0) && (listUplosds.Count == 0))
                    {
                        service.DeleteComment(comment.Id);
                    }
                }
                return View("CreateCommentSuccess");
            }
        }

        // Вспомогательный метод - пересылает строковое сообщение с помощью телеграмм-бота в telegram-channel
        private async Task RedirectToTelegram(string tmsg)
        {
            // Username telegram-канала, !!! the bot must be an administrator in the channel!!!
            string usr = "@REMONT_CANAL";
            //Инициализация экзумпляра telegram-бота
            tg_client = await Bot_Telegram.Get();
            await tg_client.SendTextMessageAsync
                (
                chatId: usr,
                text: tmsg
                );
            return;
        }
        // Вспомогательный метод - пересылает строковое сообщение с помощью телеграмм-бота в viber-public-аккаунт
        private async Task RedirectToViber(string vmsg)
        {
            //установить webhook
            hc = new HookController();
            var accinfo = hc.RegisterWebhook();
            var tempmessage = hc.Post(vmsg);
            return;
        }

        //вспомогательный метод - возвращает идентификац.номер и имя зарегистрированного пользователя
        public List<string> GetDataAboutUser()
        {
            string userid;
            string username;
            List<string> ListOfUsersIdName;
            username = User.Identity.Name;
            ApplicationUser user = userManager.Users.FirstOrDefault(_ => _.UserName == username);
            userid = user.Id;
            ListOfUsersIdName = new List<string>() { userid, username };
            return ListOfUsersIdName;
        }

        //вспомогательный метод - возвращает идентификац.номер комментария для дальнейшей передачи в представление 
        public RedirectToRouteResult AddFileRedirect(int id)
        {
            comment = service.GetComment(id).CommentFromDomainToView();
            ViewBag.Title = $"ДОБАВЛЕНИЕ ОТЗЫВА ЗАРЕГИСТРИРОВАННЫМ ПОЛЬЗОВАТЕЛЕМ {comment.UserName}";
            ViewBag.Salute = $"{comment.UserName} МЫ БУДЕМ РАДЫ ВАШЕМУ ОТЗЫВУ!";
            int temp = id;
            return RedirectToAction("AddFile", "Upload", new { id = temp });
        }

        //вспомогательный метод - возвращает текст отзыва пользователя
        public string GetCommentText(int id)
        {
            comment = service.GetComment(id)
                .CommentFromDomainToView()
                ;
            string text = comment.MessageFromUser;
            return text;
        }

        //вспомогательный метод - возвращает имя пользователя по id комментария
        [HttpGet]
        [Route("Comment/GetCommentUserName")]
        public string GetCommentUserName(int id)
        {
            comment = service.GetComment(id)
                .CommentFromDomainToView()
                ;
            string name = comment.UserName;
            return name;
        }

        // Вспомогательный метод - возвращает коллекцию всех загруженных файлов определенного пользователя по его логину
        public PartialViewResult AllUploadsByNameOfUser()
        {
            string UserName = GetDataAboutUser().ElementAt(1).ToString();
            var temp = upservice.AllUploadsByNameOfUser(UserName);
            if ((temp != null) && (temp.Count() > 0))
            {
                listUplosds = upservice.AllUploadsByNameOfUser(UserName)
                                                 .Select(_ => _.UploadFromDomainToView())
                                                 .ToList();
                ViewBag.Mess = $"ИЗОБРАЖЕНИЯ ИЛИ ФОТО, ЗАГРУЖЕННЫЕ ПОЛЬЗОВАТЕЛЕМ: {UserName}";
                return PartialView("AllUploadsByNameOfUser", listUplosds);
            }
            #region
            // 2-ой способ 
            //закомментированно, т.к. при deploy on azure will fail
            //{ 
            //    listUplosds = upservice.AllUploadsByNameOfUser(UserName)
            //                                     .Select(_ => _.UploadFromDomainToView())
            //                                     .ToList();
            //    List<string> ListFileStringPath = new List<string>();
            //    foreach (Upload_View tempUpl in listUplosds)
            //    {
            //        ListFileStringPath.Add(tempUpl.FileName);
            //    }
            //    ViewBag.Result = $"РАНЕЕ ЗАГРУЖЕННЫЕ ЗАРЕГИСТРИРОВАННЫМ ПОЛЬЗОВАТЕЛЕМ {UserName} ИЗОБРАЖЕНИЯ ИЛИ ФОТО:";
            //    return PartialView("AllFilePathesByUser", ListFileStringPath);
            //}
            #endregion
            else
            {
                ViewBag.Mess = $"ПОЛЬЗОВАТЕЛЬ {UserName} ПОКА НЕ ЗАГРУЗИЛ НИ ОДНОГО ИЗОБРАЖЕНИЯ ИЛИ ФОТО";
                return PartialView("AllFilesByNameOfUserWithoutPhoto");
            }
        }

        // Вспомогательный метод - возвращает коллекцию всех загруженных пользователем файлов по id комментария
        public PartialViewResult AllUploadsByIdOfComment(int id)
        {
            comment = service.GetComment(id).CommentFromDomainToView();
            var temp = upservice.GetAllUploadByIdOfComment(id);
            listUplosds = upservice.GetAllUploadByIdOfComment(id)
                                                 .Select(_ => _.UploadFromDomainToView())
                                                 .ToList();
                ViewBag.Result = $"ИЗОБРАЖЕНИЯ ИЛИ ФОТО, ЗАГРУЖЕННЫЕ ПОЛЬЗОВАТЕЛЕМ {comment.UserName}";
                return PartialView("AllUploadsByIdOfComment", listUplosds);
        }

        // Вспомогательный метод - возвращает коллекцию всех загруженных файлов по id пользователя
        public PartialViewResult FirstOrDefaultUploadByIdOfUser(string id)
        {
            if (id == null)
            {
                return PartialView("DefaultImgSrc");
            }
            listComments = service.GetAllComments()
                        .Where(_ => _.UserId == id)
                        .Select(_ => _.CommentFromDomainToView())
                        .ToList();
            if ((listComments != null) && (listComments.Count() > 0))
            {
                foreach(Comment_View comment in listComments)
                {
                    listUplosds.AddRange(upservice.GetAllUploadByIdOfComment(comment.Id)
                                                        .Select(_ => _.UploadFromDomainToView())
                                                        .ToList()
                                                        );
                }
                if (listUplosds != null && listUplosds.Count() > 0)
                {
                    upload = listUplosds.FirstOrDefault();
                    return PartialView("FirstOrDefaultUploadByIdOfUser", upload);
                }
                else
                {
                    return PartialView("DefaultImgSrc");
                }
            }
            else
            {
                return PartialView("DefaultImgSrc");
            }
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("Comment/AllComments_Admin")]
        public ActionResult AllComments_Admin(string cont=" ")
        {
            ViewBag.Num = 0;
            ViewBag.Content = cont;
            ViewBag.TODO = "ПРОСМОТР ОТЗЫВОВ ЗАРЕГИСТРИРОВАННЫХ ПОЛЬЗОВАТЕЛЕЙ";
            //все отзывы, НЕ одобренные админом для публикации на сайте
            List<Comment_View> NotPublished_Comments = service.GetAllComments()
                                                    .Where(_ => _.ApprovalForPublishing == false)
                                                    .Select(_ => _.CommentFromDomainToView())
                                                    .ToList()
                                                    ;
            ViewBag.Name1 = "ОТЗЫВЫ, ПОКА НЕ ПОЛУЧИВШИЕ ОДОБРЕНИЕ НА ПУБЛИКАЦИЮ :";
            //по окончании всех итераций - готовая коллекция комментариев в связке с загруженными файлами(пока не опубликованных)
            Dictionary<Comment_View, List<Upload_View>> listNotPublished = new Dictionary<Comment_View, List<Upload_View>>();
            foreach (Comment_View  tempComm in NotPublished_Comments)
            {

                listNotPublished.Add(tempComm, upservice.GetAllUploadByIdOfComment(tempComm.Id).Select(_ => _.UploadFromDomainToView()).ToList());
            }
            //все отзывы, одобренные админом для публикации на сайте
            List<Comment_View> Published_Comments = service.GetAllComments()
                                                    .Where(_ => _.ApprovalForPublishing == true)
                                                    .Select(_ => _.CommentFromDomainToView())
                                                    .ToList()
                                                    ;
            ViewBag.Name2 = "ОТЗЫВЫ, ПОЛУЧИВШИЕ ОДОБРЕНИЕ НА ПУБЛИКАЦИЮ :";
            //по окончании всех итераций - готовая коллекция комментариев в связке с загруженными файлами(опубликованные)
            Dictionary<Comment_View, List<Upload_View>> listPublished = new Dictionary<Comment_View, List<Upload_View>>();
            foreach (Comment_View tempComm in Published_Comments)
            {
                listPublished.Add(tempComm, upservice.GetAllUploadByIdOfComment(tempComm.Id).Select(_ => _.UploadFromDomainToView()).ToList());
            }
            //добавить во вьюмодель для передачи в представление
            CommentPublishNotPublish_View allComments = new CommentPublishNotPublish_View
            {
                NotPublished = listNotPublished,
                Published = listPublished
            };
            return View(allComments);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("Comment/UpdateComment_Admin")]
        public ActionResult UpdateComment_Admin(int id)
        {
            comment = service.GetComment(id).CommentFromDomainToView();
            ViewBag.TODO = $"РЕДАКТИРОВАНИЕ ОТЗЫВА ЗАРЕГИСТРИРОВАННОГО ПОЛЬЗОВАТЕЛЯ {comment.UserName}";
            return View(comment);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("Comment/UpdateComment_Admin")]
        public ActionResult UpdateComment_Admin(Comment_View comm)
        {
            comment = comm as Comment_View;
            ViewBag.TODO = $"РЕДАКТИРОВАНИЕ ОТЗЫВА ЗАРЕГИСТРИРОВАННОГО ПОЛЬЗОВАТЕЛЯ {comment.UserName}:";
            service.UpdateComment(comment.CommentFromViewToDomain());
            string result = "ОТРЕДАКТИРОВАННЫЙ ОТЗЫВ СОХРАНЕН!";
            return RedirectToAction("AllComments_Admin", "Comment", new { cont = result});
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("Comment/PublishComment_Admin")]
        public ActionResult PublishComment_Admin(int id)
        {
            comment = service.GetComment(id).CommentFromDomainToView();
            comment.ApprovalForPublishing = true;
            service.UpdateComment(comment.CommentFromViewToDomain());
            ViewBag.TODO = $"ПРЕДОСТАВЛЕНИЕ ОДОБРЕНИЯ НА ПУБЛИКАЦИЮ ОТЗЫВА ЗАРЕГИСТРИРОВАННОГО ПОЛЬЗОВАТЕЛЯ {comment.UserName}";
            string result = $"ПУБЛИКАЦИЯ ОТЗЫВА ЗАРЕГИСТРИРОВАННОГО ПОЛЬЗОВАТЕЛЯ {comment.UserName} ОДОБРЕНА !";
            return RedirectToAction("AllComments_Admin", "Comment", new { cont = result });
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("Comment/DeleteComment_Admin")]
        public ActionResult DeleteComment_Admin(int id)
        {
            //до удаления комментария сохранить имя пользователя в промежуточную переменную 
            string userName = service.GetComment(id).UserName;
            ViewBag.TODO = $"УДАЛЕНИЕ ОТЗЫВА ЗАРЕГИСТРИРОВАННОГО ПОЛЬЗОВАТЕЛЯ {userName}";
            //перед удалением главной сущности, удалить все зависимые сущности
            listUplosds = upservice.GetAllUploadByIdOfComment(id)
                                                                 .Select(_ => _.UploadFromDomainToView())
                                                                 .ToList()
                                                                 ;
            foreach(Upload_View upl in listUplosds)
            {
                upservice.DeleteUpload(upl.Id);
            }
            string result = "";
            //предотвратить удаление самого первого комментария, оставленного админом, дабы хотя бы один отзыв отображался на странице
            if (id == 1)
            {
                result = $"УДАЛЕНИЕ ОТЗЫВА ЗАРЕГИСТРИРОВАННОГО ПОЛЬЗОВАТЕЛЯ {userName} НЕВОЗМОЖНО !" +
                    $"\nЭТО ОТЗЫВ, ОСТАВЛЕННЫЙ АДМИНИСТРАТОРОМ САЙТА !";
            }
            else
            {
                //удалить главную сущность
                service.DeleteComment(id);
                result = $"УДАЛЕНИЕ ОТЗЫВА ЗАРЕГИСТРИРОВАННОГО ПОЛЬЗОВАТЕЛЯ {userName} ПРОШЛО УСПЕШНО !";
            }
            return RedirectToAction("AllComments_Admin", "Comment", new { cont = result });
        }
    }
}