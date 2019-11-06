using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RemontUnderKey.Web.Identity;
using RemontUnderKey.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RemontUnderKey.Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class RoleController : Controller
    {
        private ApplicationUserManager userManager;
        private RoleManager<IdentityRole> roleManager;

        public RoleController(ApplicationUserManager userManager,
                            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        [Route("Role/AllRoles")]
        [Authorize(Roles = "admin")]
        public ActionResult AllRoles()
        {
            // Коллекция ролей в сопоставлении с пользователями, которые находятся в этих ролях
            Dictionary<string, List<string>> rolesANDusers = new Dictionary<string, List<string>>();
            // Коллекция id пользоватлей
            List<string> allUsersId = new List<string>();
            // Коллекция всех зарегистрированных пользователей
            List<ApplicationUser> allUsers = userManager.Users.ToList();
            foreach (var user in allUsers)
            {
                // Коллекция всех ролей текущего пользователя
                List<string> allRoles = userManager.GetRoles(user.Id).ToList();
                List<string> allRolesOfUser = new List<string>();

                foreach (string role in allRoles)
                {
                    if (!rolesANDusers.ContainsKey(user.UserName))
                    {
                        allRolesOfUser.Add(role);
                        rolesANDusers.Add(user.UserName, allRolesOfUser);
                    }
                    else
                    {
                        rolesANDusers[user.UserName].Add(", ");
                        rolesANDusers[user.UserName].Add(role);
                    }
                }
                allUsersId.Add(user.Id);
            }
            ViewBag.Num = 0;
            ViewBag.ListUserId = allUsersId;
            ViewBag.Header = "СПИСОК ВСЕХ ЗАРЕГИСТРИРОВАННЫХ ПОЛЬЗОВАТЕЛЕЙ И ИХ РОЛЕЙ:";
            return View("AllRoles", rolesANDusers);
        }

        //Добавление для пользователя новой роли - по логину пользователя
        [HttpGet]
        [Route("Role/AddNewRole")]
        [Authorize(Roles = "admin")]
        public ActionResult AddNewRole(string id)
        {
            ViewBag.TODO = "ДОБАВЛЕНИЕ НОВОЙ РОЛИ ДЛЯ ЗАРЕГИСТРИРОВАННОГО ПОЛЬЗОВАТЕЛЯ";
            ApplicationUser foundUser = userManager.FindById(id);
            TempData["NameOfUser"] = foundUser.UserName;
            return View("AddNewRole");
        }

        [HttpPost]
        [Route("Role/AddNewRole")]
        [Authorize(Roles = "admin")]
        public ActionResult AddNewRole_Post(string name, string role)
        {
            ViewBag.TODO = "ДОБАВЛЕНИЕ НОВОЙ РОЛИ ДЛЯ ЗАРЕГИСТРИРОВАННОГО ПОЛЬЗОВАТЕЛЯ";
            ApplicationUser foundUser = userManager.FindByName(name);
            if (foundUser == null)
            {
                ViewBag.Result = "Пользователь с таким логином не зарегистрирован!!";
                return View("AddNewRole_Post");
            }
            // проверить - возможно у запрашиваемого пользователя уже есть эта роль
            if (userManager.IsInRole(foundUser.Id, role))
            {
                ViewBag.Result = "Пользователь уже наделен правами запрашиваемой роли!!";
                return View("AddNewRole_Post");
            }
            var foundRole = roleManager.FindByName(role);
            if (foundRole == null)
            {
                ViewBag.Result = "Роль с таким наименованием не зарегистрирована!!";
                return View("AddNewRole_Post");
            }
            else
            {
                const int num = 0;
                ViewBag.Num = num;
                //Присвоение текущему пользователю выбранной роли
                userManager.AddToRole(foundUser.Id, role);
                // Коллекция всех идентификационных номеров ролей
                IList<IdentityUserRole> listOfIdOfRolesOfUser = foundUser.Roles.ToList();
                // Коллекция всех наименований ролей
                IList<string> listOfNameOfRolesOfUser = new List<string>();
                // По окончании выполнения цикла - готовая коллекция наименований всех ролей пользователя
                foreach (var t in listOfIdOfRolesOfUser)
                {
                    string tempRoleId = t.RoleId;
                    var tempRoleName = roleManager.Roles.FirstOrDefault(_ => _.Id == tempRoleId).Name;
                    listOfNameOfRolesOfUser.Add(tempRoleName);
                }

                ViewBag.listofrolesofuser = listOfNameOfRolesOfUser;
                ViewBag.Result = $"Пользователь с именем: {foundUser.UserName}\0\0 обладает следующими ролями:";
                return View("AddNewRole_Success");
            }
        }
    }
}