using RemontUnderKey.Domain.Interfaces;
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

namespace RemontUnderKey.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly IComment service;
        private readonly IUpload upservice;
        private HookController hc;
        private static TelegramBotClient tg_client;
        private string redirectMessage;
        private ApplicationUserManager userManager;

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
            IEnumerable<Comment_View> comments = service.GetAllComments()
                .Where(_ => _.ApprovalForPublishing == true)
                .Select(_ => _.CommentFromDomainToView())
                .OrderBy(t => t.Id)
                .ToList()
                ;
            return View(comments);
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
        [Route("Comment/GetComment")]
        public Comment_View GetComment(int id)
        {
            Comment_View comment = service.GetComment(id)
                .CommentFromDomainToView()
                ;
            return comment;
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
                IEnumerable<Comment_View> ListOfCommentsOfCurrentUser = service.AllCommentsByNameOfUser(UserName)
                                                                        .Select(_ => _.CommentFromDomainToView())
                                                                        .ToList()
                                                                        ;
                //если сохраненных отзывов нет - создаем новые
                string lengthOfAllCommentsOfUser = "";
                foreach (Comment_View tempComment in ListOfCommentsOfCurrentUser)
                {
                    lengthOfAllCommentsOfUser = String.Concat(lengthOfAllCommentsOfUser, tempComment.MessageFromUser);
                }
                if (lengthOfAllCommentsOfUser.Length == 0)
                {
                    ViewBag.Salute = $"ПОЛЬЗОВАТЕЛЬ {UserName} ОСТАВЬТЕ, ПОЖАЛУЙСТА, СВОЙ ПЕРВЫЙ ОТЗЫВ НА САЙТЕ!";
                    Comment_View inst = new Comment_View();
                    inst.UserId = UserId;
                    inst.UserName = UserName;
                    int? tempIdOfComment = service.CreateComment(inst.CommentFromViewToDomain());
                    inst = service.GetComment(tempIdOfComment).CommentFromDomainToView();
                    return View("CreateComment", inst);
                }
                else
                {
                    //если сохраненные отзывовы есть - редактируем последний(заменяем старый на новый), дабы пользователь не мог оставить более одного отзыва на сайте
                    ViewBag.Salute = $"ПОЛЬЗОВАТЕЛЬ {UserName} МОЖЕТЕ ОСТАВИТЬ ЕЩЕ ОДИН ОТЗЫВ НА НАШЕМ САЙТЕ!";
                    // Получение последного оставленного текущим пользователем отзыва
                    Comment_View inst = ListOfCommentsOfCurrentUser.Last();
                    // Рендеринг одного или другого уведомления в зависимости от того, загружал текущий пользователь фото или нет
                    List<Upload_View> tempUpload = upservice.AllUploadsByNameOfUser(UserName)
                                            .Select(_ => _.UploadFromDomainToView())
                                            .ToList()
                                            ;
                    return View("CreateComment", inst);
                }
            }
        }

        [HttpGet]
        [Route("Comment/CreateCommentRedirect")]
        public ActionResult CreateCommentRedirect([System.Web.Http.FromBody]Comment_View inst, string resultUpload)
        {
            int idofComment = inst.Id;
            List<Upload_View> temp = upservice.GetAllUploadByIdOfComment(idofComment)
                                            .Select(_ => _.UploadFromDomainToView())
                                            .ToList()
                                            ;
            string nameOfLastUpload = temp.Last().FileName;
            ViewBag.ResultFromUpload = resultUpload;
            return View("CreateComment", inst);
        }

        [HttpPost]
        [Route("Comment/CreateComment/")]
        public async Task<ViewResult> CreateComment([System.Web.Http.FromBody]Comment_View inst)
        {
            ViewBag.Title = $"ДОБАВЛЕНИЕ ОТЗЫВА ЗАРЕГИСТРИРОВАННЫМ ПОЛЬЗОВАТЕЛЕМ";
            ViewBag.Salute = $"{inst.UserName} НЕ ЗАБУДЬТЕ ОСТАВИТЬ СВОЙ ОТЗЫВ!";
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
                // Сформировать текстовое сообщение для перенаправления в telegram-группу
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
                foreach(var comment in AllCommentsByUser)
                {
                    var AllUploadsByAllCommentsByUser = upservice.GetAllUploadByIdOfComment(comment.Id)
                                                                        .Select(_ => _.UploadFromDomainToView())
                                                                        .ToList()
                                                                        ;
                    if((comment.MessageFromUser.Length == 0) && (AllUploadsByAllCommentsByUser.Count == 0))
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

        //вспомогательный метод - возвращает идентификац.номер текущего пользователя для дальнейшей передачи в представление 
        public RedirectToRouteResult AddFileRedirect(int id)
        {
            int temp = id;
            return RedirectToAction("AddFile", "Upload", new { id = temp });
        }

        //вспомогательный метод - возвращает текст отзыва пользователя
        [HttpGet]
        [Route("Comment/GetCommentText")]
        public string GetCommentText(int id)
        {
            Comment_View comment = service.GetComment(id)
                .CommentFromDomainToView()
                ;
            string text = comment.MessageFromUser;
            return text;
        }

        //вспомогательный метод - возвращает имя пользователя
        [HttpGet]
        [Route("Comment/GetCommentUserName")]
        public string GetCommentUserName(int id)
        {
            Comment_View comment = service.GetComment(id)
                .CommentFromDomainToView()
                ;
            string name = comment.UserName;
            return name;
        }

        // Вспомогательный метод - возвращает коллекцию всех загруженных файлов определенного пользователя по его логину
        public PartialViewResult AllUploadsByNameOfUser()
        {
            string UserName = GetDataAboutUser().ElementAt(1).ToString();
            List<Upload_View> listOfAllUploadsOfUser = new List<Upload_View>();
            var temp = upservice.AllUploadsByNameOfUser(UserName);
            if ((temp != null) && (temp.Count() > 0))
            {
                listOfAllUploadsOfUser = upservice.AllUploadsByNameOfUser(UserName)
                                                 .Select(_ => _.UploadFromDomainToView())
                                                 .ToList();
                ViewBag.Result = $"РАНЕЕ ЗАГРУЖЕННЫЕ ЗАРЕГИСТРИРОВАННЫМ ПОЛЬЗОВАТЕЛЕМ {UserName} ИЗОБРАЖЕНИЯ ИЛИ ФОТО:";
                return PartialView("AllUploadsByNameOfUser", listOfAllUploadsOfUser);
            }
            // 2-ой способ
            //{ 
            //    listOfAllUploadsOfUser = upservice.AllUploadsByNameOfUser(UserName)
            //                                     .Select(_ => _.UploadFromDomainToView())
            //                                     .ToList();
            //    List<string> ListFileStringPath = new List<string>();
            //    foreach (Upload_View tempUpl in listOfAllUploadsOfUser)
            //    {
            //        ListFileStringPath.Add(tempUpl.FileName);
            //    }
            //    ViewBag.Result = $"РАНЕЕ ЗАГРУЖЕННЫЕ ЗАРЕГИСТРИРОВАННЫМ ПОЛЬЗОВАТЕЛЕМ {UserName} ИЗОБРАЖЕНИЯ ИЛИ ФОТО:";
            //    return PartialView("AllFilePathesByUser", ListFileStringPath);
            //}
            else
            {
                ViewBag.Result = $"ПОЛЬЗОВАТЕЛЬ {UserName} ПОКА НЕ ЗАГРУЗИЛ НИ ОДНОГО ИЗОБРАЖЕНИЯ ИЛИ ФОТО:";
                return PartialView("AllFilesByNameOfUserWithoutPhoto");
            }
        }        
    }
}