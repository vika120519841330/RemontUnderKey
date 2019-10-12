using RemontUnderKey.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RemontUnderKey.Web.Mappers;
using RemontUnderKey.Web.Models;
using System.Net;
using System.ComponentModel.DataAnnotations;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Threading;

namespace RemontUnderKey.Web.Controllers
{
    public class CallMeeController : Controller
    {
        //при поступлении заявки на обратный телефонный звонок - происходит пересылка текстового сообщения в telegram-аккаунт
        private string redirectToTelegramMessage;
        private readonly ICallMee service;
        public CallMeeController(ICallMee _service)
        {
            this.service = _service;
        }
        [HttpGet]
        public ActionResult GetAllCallMee()
        {
            IEnumerable<CallMee_View> calls = service.GetAllCallMee()
                .Select(_ => _.CallMeeFromDomainToView())
                .OrderBy(t => t.DateStamp)
                .ToList()
                ;
            return View(calls);
        }

        [HttpGet]
        public ActionResult CreateCallMee()
        {
            ViewBag.Title = "ЗАЯВКА НА ОБРАТНЫЙ ЗВОНОК";
            return View();
        }
        [HttpPost]
        public async Task<ViewResult> CreateCallMee(CallMee_View inst)
        {
            inst.DateStamp = DateTime.Now;
            inst.Comments = "Комментарий";
            ViewBag.Title = $"ЗАЯВКА НА ОБРАТНЫЙ ЗВОНОК";
            if (inst == null)
            {
                ModelState.AddModelError("CreateCallMeeNull", "Укажите имя и контактный телефон для обратного звонка!!!");
                ViewBag.Message = "Укажите имя и контактный телефон для обратного звонка!!!";
                return View("CreateCallMee");
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("CreateCallMeeNotVal", "Указанные для запроса обратного звонка данные не валидны!!!");
                ViewBag.Message = "Валидация НЕ пройдена! Проверьте введенные сведения на достоверность!";
                return View("CreateCallMee");
            }
            else
            {
                service.CreateCallMee(inst.CallMeeFromViewToDomain());
                ViewBag.Result = "Zajavka na zvonok prinjata!";

                // Сформировать текстовое сообщение для перенаправления в telegram-группу
                redirectToTelegramMessage = (inst.DateStamp.ToString() + " " + inst.Name + " " + inst.Telephone + ";").ToString();
                // Вызвать метод, инициализирующий telegram-bot
                await Task.Run(() => RedirectToTelegram(redirectToTelegramMessage));
                Thread.Sleep(8000);
                return View("CreateCallMee_Success");
            }
        }
        // Вспомогательный метод - пересылает строковое сообщение с помощью телеграмм-бота заданному получателю(тому, кто обрабатывает заявки на телеф.звонки)
       private async void RedirectToTelegram (string msg)
        {
            // Создание экземпляра бота
            TelegramBotClient client = await Bot.Get();
            string usr = "@VikaStrigo";
            await client.SendTextMessageAsync
                (
                chatId: new ChatId(username: usr),
                text: msg
                );
        }
    }
}