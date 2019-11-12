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
        private List<CallMee_View> listCalls;
        private CallMee_View callMee;

        public CallMeeController(ICallMee _service)
        {
            this.service = _service;
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
                return View("~/Views/CallMee/CreateCallMeeIndex_NotPartly.cshtml");
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("CreateCallMeeNotVal", "Указанные для запроса обратного звонка данные не валидны!!!");
                ViewBag.Message = "Валидация НЕ пройдена! Проверьте введенные сведения на достоверность!";
                return View("~/Views/CallMee/CreateCallMeeIndex_NotPartly.cshtml");
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

        [Authorize(Roles = "admin")]
        [HttpGet]
        //[Route("CallMee/CreateCallMeeContacts")]
        public ActionResult AllCallMee_Admin(string res)
        {
            if (res != null)
            {
                ViewBag.Result = res;
            }
            else
            {
                ViewBag.Result = " ";
            }
            ViewBag.TODO = "ПРОСМОТР ВСЕХ ОСТАВЛЕННЫХ ПОЛЬЗОВАТЕЛЯМИ ЗАЯВОК НА ОБРАТНЫЙ ЗВОНОК";
            ViewBag.Num = 0;
            ViewBag.Name2 = "СДЕЛАННЫЕ ОБРАТНЫЕ ЗВОНКИ";
            ViewBag.Name1 = "ПОКА НЕ СДЕЛАННЫЕ ОБРАТНЫЕ ЗВОНКИ";
            //сущность хранит все виды заявок на звонок - уже выполненные и нет 
            CallMeeDoneNotDone_View callsDoneNotDone = new CallMeeDoneNotDone_View();
            listCalls = service.GetAllCallMee()
                .Select(_ => _.CallMeeFromDomainToView())
                .OrderBy(_ => _.DateStamp)
                .ToList()
                ;
            if (listCalls != null && listCalls.Count() > 0)
            {
                List<CallMee_View> isNotDone = listCalls.Where(_ => _.CallIsDone == false).ToList();
                if(isNotDone != null)
                {
                    callsDoneNotDone.NotDoneCallMee = isNotDone;
                }
                List<CallMee_View> isDone = listCalls.Where(_ => _.CallIsDone == true).ToList();
                if (isDone != null)
                {
                    callsDoneNotDone.DoneCallMee = isDone;
                }
            }
            return View(callsDoneNotDone);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult DeleteCallMee_Admin(int id)
        {
            string result;
            if (id != 1)
            {
                service.DeleteCallMee(id);
                result = $"УДАЛЕНИЕ ЗАЯВКИ НА ЗВОНОК С ID № {id} ПРОШЛО УСПЕШНО !";
            }
            else
            {
                result = $"УДАЛЕНИЕ ЗАЯВКИ НА ЗВОНОК С ID № {id} НЕВОЗМОЖНО, \nТ.К. ЭТО ТЕСТОВАЯ ЗАЯВКА НА ЗВОНОК," +
                    $"ОСТАВЛЕННАЯ АДМИНОМ САЙТА !";
            }
            return RedirectToAction("AllCallMee_Admin", "CallMee", new { res = result});
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult EditeCallMee_Admin(int id)
        {
            if (id != 1)
            {
                callMee = service.GetCallMee(id).CallMeeFromDomainToView();
                return View("EditeCallMee_Admin", callMee);
            }
            else
            {
                return RedirectToAction("AllCallMee_Admin", "CallMee", new { res = "РЕДАКТИРОВАНИЕ ЗАЯВКИ, ОСТАВЛЕННОЙ АДМИНОМ САЙТА НЕВОЗМОЖНО !" });
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult EditeCallMee_Admin(CallMee_View call)
        {
            service.UpdateCallMee(call.CallMeeFromViewToDomain());
            return RedirectToAction("AllCallMee_Admin", "CallMee", new { res = $"РЕДАКТИРОВАНИЕ ЗАЯВКИ С ID №{call.Id} ПРОШЛО УСПЕШНО !" });
        }
        
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult MarkDoneCallMee_Admin(int id)
        {
            string result = " ";
            if (id != 1)
            {
                callMee = service.GetCallMee(id).CallMeeFromDomainToView();
                if(callMee.CallIsDone == true)
                {
                    callMee.CallIsDone = false;
                    service.UpdateCallMee(callMee.CallMeeFromViewToDomain());
                    result = "ОТМЕТКА О ТОМ, ЧТО ЗВОНОК СДЕЛАН СНЯТА !";
                }
                else if (callMee.CallIsDone == false)
                {
                    callMee.CallIsDone = true;
                    service.UpdateCallMee(callMee.CallMeeFromViewToDomain());
                    result = "ОТМЕТКА О ТОМ, ЧТО ЗВОНОК СДЕЛАН УСТАНОВЛЕНА !";
                }
                return RedirectToAction("AllCallMee_Admin", "CallMee", new { res = result});
            }
            else
            {
                return RedirectToAction("AllCallMee_Admin", "CallMee", new { res = "РЕДАКТИРОВАНИЕ ЗАЯВКИ, ОСТАВЛЕННОЙ АДМИНОМ САЙТА НЕВОЗМОЖНО !" });
            }
        }
    }
}