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

namespace RemontUnderKey.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly IComment service;
        private HookController hc;
        private static TelegramBotClient tg_client;
        private string redirectMessage;
        private ApplicationUserManager userManager;

        public CommentController(IComment _service, ApplicationUserManager _userManager)
        {
            this.service = _service;
            this.userManager = _userManager;
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

        [HttpGet]
        [Route("Comment/GetComment")]
        public Comment_View GetComment(int id)
        {
            Comment_View comment = service.GetComment(id)
                .CommentFromDomainToView()
                ;
            return comment;
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
            string name = comment.UserName;
            return name;
        }

        //Опубликовать отзыв на сайте вправе только зарегистрированный пользователь
        [Authorize(Roles = "admin, user")]
        [HttpGet]
        [Route("Comment/CreateComment")]
        public ActionResult CreateComment()
        {
            ViewBag.Title = $"ОСТАВЬТЕ СВОЙ ОТЗЫВ:";
            ViewBag.Warning = $"ДЛЯ ПУБЛИКАЦИИ ОТЗЫВА, ПРОЙДИТЕ РЕГИСТРАЦИЮ НА САЙТЕ!";
            if (!(User.IsInRole("admin") || User.IsInRole("user")))
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var tempList = GetDataAboutUser();
                Comment_View inst = new Comment_View();
                inst.UserId = tempList[0];
                inst.UserName = tempList[1];
                int? tempIdOfComment = service.CreateComment(inst.CommentFromViewToDomain());
                inst = service.GetComment(tempIdOfComment).CommentFromDomainToView();
                return View("CreateComment", inst);
            }
        }

        [HttpGet]
        [Route("Comment/CreateCommentRedirect")]
        public ActionResult CreateCommentRedirect([System.Web.Http.FromBody]Comment_View inst)
        {
                return View("CreateComment", inst);
        }

        [HttpPost]
        [Route("Comment/CreateComment/")]
        public async Task<ViewResult> CreateComment([System.Web.Http.FromBody]Comment_View inst)
        {
            ViewBag.Title = $"ДОБАВЛЕНИЕ ОТЗЫВА";
            ViewBag.Salute = $"{inst.UserName} ОСТАВЬТЕ СВОЙ ОТЗЫВ!";
            if (inst == null)
            {
                ModelState.AddModelError("CreateCommentNull", "Оставьте свой отзыв!!!");
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
            var tempmessage =  hc.Post(vmsg);
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

        //вспомогательный метод - возвращает идентификац.номер и имя зарегистрированного 
        public RedirectToRouteResult AddFileRedirect(int id)
        {
            int temp = id;
            return RedirectToAction("AddFile", "Upload", new { id = temp });
        }
    }
}