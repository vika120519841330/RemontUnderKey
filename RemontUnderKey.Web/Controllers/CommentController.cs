using RemontUnderKey.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RemontUnderKey.Web.Mappers;
using RemontUnderKey.Web.Models;
using System.Threading.Tasks;
using Telegram.Bot;

namespace RemontUnderKey.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly IComment service;
        private HookController hc;
        private static TelegramBotClient tg_client;
        private string redirectMessage;

        public CommentController(IComment _service)
        {
            this.service = _service;
        }
        [HttpGet]
        [Route("Comment/GetAllComments")]
        public ActionResult GetAllComments()
        {
            IEnumerable<Comment_View> comments = service.GetAllComments()
                .Select(_ => _.CommentFromDomainToView())
                .OrderBy(t => t.Id)
                .ToList()
                ;
            return View(comments);
        }
        //вспомогательный метод - возвращает текст комментария пользователя
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
            string name = comment.UserName.UserName;
            return name;
        }

        //Опубликовать отзыв на сайте вправе только зарегистрированный пользователь
        [Authorize(Roles = "admin, user")]
        [HttpGet]
        [Route("Comment/CreateComment")]
        public void CreateComment()
        {
            ViewBag.Title = $"ОСТАВЬТЕ СВОЙ ОТЗЫВ:";
            ViewBag.Warning = $"ДЛЯ ПУБЛИКАЦИИ ОТЗЫВА, ПРОЙДИТЕ РЕГИСТРАЦИЮ НА САЙТЕ!";
            if (!( User.IsInRole("admin") || User.IsInRole("user") ) )
            {
                RedirectToRoute("Login", "Account");
            }
            else RedirectToRoute("CreateComment", "Comment");
        }

        [HttpPost]
        [Route("Comment/CreateComment")]
        public async Task<ViewResult> CreateComment(Comment_View inst)
        {
            ViewBag.Title = $"ОСТАВЬТЕ СВОЙ ОТЗЫВ:";
            if (inst == null)
            {
                ModelState.AddModelError("CreateCommentNull", "Оставьте свой отзыв!!!");
                ViewBag.Message = "Оставьте свой отзыв!!!";
                return View("CreateComment");
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("CreateCallMeeNotVal", "Указанные данные для отправки отзыва не валидны!!!");
                ViewBag.Message = "Валидация НЕ пройдена! Проверьте введенные сведения на достоверность!";
                return View("CreateComment");
            }
            else
            {
                service.CreateComment(inst.CommentFromViewToDomain());
                ViewBag.Result = "Thank you! Your feedback is accepted and sent for moderation!";
                // Сформировать текстовое сообщение для перенаправления в telegram-группу
                redirectMessage = (DateTime.Now.ToString() + inst.UserName + " " + " ОТЗЫВ: " + inst.MessageFromUser + ";").ToString();
                //Инициализировать массив синхронных задач
                Task[] taskList = new Task[2]
                {
                    // Вызвать метод, инициализирующий viber-bot
                    new Task(() => RedirectToViber(redirectMessage)),
                    // Вызвать метод, инициализирующий telegram-bot
                    new Task(() => RedirectToTelegram(redirectMessage))
                };
                foreach(var t in taskList)
                {
                    t.Start();
                }
                //Ожидаем завершения всех задач из массива задач
                Task.WaitAll(taskList);
                return View("CreateComment_Success");
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
            var tempmessage =  hc.Post(vmsg);
            return;
        }
    }
}