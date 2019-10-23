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
        private HookController hc;

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
        [HttpGet]
        public ActionResult CreateCallMeeContacts()
        {
            ViewBag.Title = "ЗАЯВКА НА ОБРАТНЫЙ ЗВОНОК";
            return PartialView();
        }

        [HttpGet]
        public ActionResult CreateCallMeeIndex()
        {
            ViewBag.Title = "ПРИГЛАСИТЬ МЕНЯ НА ОБЬЕКТ ДЛЯ РАСЧЕТА СМЕТЫ";
            ViewBag.Title2 = "Пригласите мастера к себе на объект для составления сметы";
            return PartialView();
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
                
                //Последовательный запуск задач
                // Вызвать метод, инициализирующий viber-bot
                //await Task.Run(() => RedirectToViber(redirectMessage));
                // Вызвать метод, инициализирующий telegram-bot
                //await Task.Run(() => RedirectToTelegram(redirectMessage));

                return View("CreateCallMee_Success");
            }
        }

        [HttpPost]
        //[Route("CallMee/CreateCallMeeContacts")]
        public async Task<ViewResult> CreateCallMeeContacts(CallMee_View inst)
        {
            inst.DateStamp = DateTime.Now;
            inst.Comments = "Комментарий";
            ViewBag.Title = $"ЗАЯВКА НА ОБРАТНЫЙ ЗВОНОК";
            if (inst == null)
            {
                ModelState.AddModelError("CreateCallMeeNull", "Укажите имя и контактный телефон для обратного звонка!!!");
                ViewBag.Message = "Укажите имя и контактный телефон для обратного звонка!!!";
                return View("CreateCallMeeContacts");
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("CreateCallMeeNotVal", "Указанные для запроса обратного звонка данные не валидны!!!");
                ViewBag.Message = "Валидация НЕ пройдена! Проверьте введенные сведения на достоверность!";
                return View("CreateCallMeeContacts");
            }
            else
            {
                service.CreateCallMee(inst.CallMeeFromViewToDomain());
                ViewBag.Result = "Zajavka na zvonok prinjata!";
                // Сформировать текстовое сообщение для перенаправления в telegram-группу
                redirectMessage = (inst.DateStamp.ToString() + "   " + inst.Name + " " + inst.Telephone + ";").ToString();
                //Инициализировать массив синхронных задач
                Task[] taskList = new Task[2]
                {
                    // Вызвать метод, инициализирующий viber-bot
                    new Task(() => RedirectToViber(redirectMessage)),
                    // Вызвать метод, инициализирующий telegram-bot
                    new Task(() => RedirectToTelegram(redirectMessage))
                };
                foreach (var t in taskList)
                {
                    t.Start();
                }
                //Ожидаем завершения всех задач из массива задач
                Task.WaitAll(taskList);
                return View("CreateCallMee_Success");
            }
        }
        public async Task<ViewResult> CreateCallMeeIndex(CallMee_View inst)
        {
            inst.DateStamp = DateTime.Now;
            ViewBag.Title = "ПРИГЛАСИТЬ МЕНЯ НА ОБЬЕКТ ДЛЯ РАСЧЕТА СМЕТЫ";
            if (inst == null)
            {
                ModelState.AddModelError("CreateCallMeeNull", "Укажите имя и контактный телефон для обратного звонка!!!");
                ViewBag.Message = "Укажите имя и контактный телефон для обратного звонка!!!";
                return View("CreateCallMeeIndex");
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("CreateCallMeeNotVal", "Указанные для запроса обратного звонка данные не валидны!!!");
                ViewBag.Message = "Валидация НЕ пройдена! Проверьте введенные сведения на достоверность!";
                return View("CreateCallMeeIndex");
            }
            else
            {
                ViewBag.Result = "Zajavka prinjata!";
                service.CreateCallMee(inst.CallMeeFromViewToDomain());
                // Сформировать текстовое сообщение для перенаправления в telegram-группу
                redirectMessage = (inst.DateStamp.ToString() + ", " + inst.Name + ", " + inst.Telephone + ", " + inst.Comments + ";").ToString();

                //Инициализировать массив синхронных задач
                var taskList = new Task[2]
                {
                    // Вызвать метод, инициализирующий telegram-bot
                    RedirectToTelegram(redirectMessage),
                    // Вызвать метод, инициализирующий viber-bot
                    RedirectToViber(redirectMessage)
                };

                await Task.WhenAll(taskList);

                return View("CreateCallMee_Success");
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