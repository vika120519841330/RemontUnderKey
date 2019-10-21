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
    public class CallMeeController : Controller
    {
        HookController hc;

        //при поступлении заявки на обратный телефонный звонок - происходит пересылка текстового сообщения в telegram-channel
        private static TelegramBotClient tg_client;

        //перенаправляемое в мессенджеры сообщение
        private string redirectMessage;

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
        //[Route("CallMee/CreateCallMee")]
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
                redirectMessage = (inst.DateStamp.ToString() + "   " + inst.Name + " " + inst.Telephone + ";").ToString();

                // Вызвать метод, инициализирующий telegram-bot
                await Task.Run(() => RedirectToTelegram(redirectMessage));
                //установить webhook
                hc = new HookController();
                var accinfo = hc.RegisterWebhook();
                // Вызвать метод, инициализирующий viber-bot
                await Task.Run(() => RedirectToViber(redirectMessage));

                return View("CreateCallMee_Success");
            }
        }
        // Вспомогательный метод - пересылает строковое сообщение с помощью телеграмм-бота в telegram-channel
        private async void RedirectToTelegram(string tmsg)
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
        }
        // Вспомогательный метод - пересылает строковое сообщение с помощью телеграмм-бота в viber-public-аккаунт
        private async Task RedirectToViber(string vmsg)
        {
            var tempmessage =  hc.Post(vmsg);
        }
    }
}