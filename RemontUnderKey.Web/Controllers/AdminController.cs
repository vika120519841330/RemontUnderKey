using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RemontUnderKey.Web.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        [Route("Admin/AdminPanel")]
        [Authorize(Roles = "admin")]
        public ActionResult AdminPanel()
        {
            ViewBag.Title = "АДМИН-ПАНЕЛЬ";
            return View("AdminPanel");
        }
    }
}