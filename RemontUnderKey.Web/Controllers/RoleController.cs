﻿using Microsoft.AspNet.Identity;
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
        private ApplicationDbContext context;
        private IdentityRole role;
        private string result;
        private List<IdentityRole> ListRoles;

        public RoleController(ApplicationUserManager _userManager,
                            RoleManager<IdentityRole> _roleManager,
                            ApplicationDbContext _context)
        {
            this.userManager = _userManager;
            this.roleManager = _roleManager;
            this.context = _context;
        }

        //Добавить новую роль в БД
        [HttpGet]
        [Route("Role/AddNewRoleInDB_Admin")]
        [Authorize(Roles = "admin")]
        public ActionResult AddNewRoleInDB_Admin()
        {
            ViewBag.ResultPartial = "ДОБАВИТЬ НОВУЮ РОЛЬ В БД";
            return PartialView("AddNewRoleInDB_Admin");
        }

        //Добавить новую роль в БД
        [HttpPost]
        [Route("Role/AddNewRoleInDB_Admin/titleRole")]
        [Authorize(Roles = "admin")]
        public ActionResult AddNewRoleInDB_Admin(string titleRole)
        {
            //проверяем, может подобное наименование роли уже существует в БД
            List<IdentityRole> listRoles = roleManager.Roles.ToList();
            bool exist = false;
            foreach (IdentityRole tempRole in listRoles)
            {
                if (tempRole.Name.CompareTo(titleRole) == 0)
                {
                    exist = true;
                }
            }
            // если новое наименование роли уникальное
            if (!exist)
            {
                // создаем роль
                role = new IdentityRole { Name = titleRole };
                // добавляем роль в бд
                roleManager.Create(role);
                result = $"РОЛЬ {role.Name} УСПЕШНО ДОБАВЛЕНА В БАЗУ ДАННЫХ !";
            }
            else
            {
                result = $"РОЛЬ {titleRole} УЖЕ СУЩЕСТВУЕТ В БАЗЕ ДАННЫХ ! ПОПРОБУЙТЕ ДОБАВИТЬ ДРУГУЮ РОЛЬ !";
            }
            return RedirectToRoute(new { controller = "Role", action = "AllRoles", res = result });

        }

        //Все роли в сопоставлении с пользователями, которые находятся в этих ролях
        [HttpGet]
        [Route("Role/AllRoles/res")]
        [Authorize(Roles = "admin")]
        public ActionResult AllRoles(string res = " ")
        {
            string resRedir = res;
            if (resRedir != null && resRedir.Length > 0)
            {
                TempData["resredir"] = resRedir;
            }
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
            int n = 0;
            int n2 = 0;
            ViewBag.Num = n;
            ViewBag.Num2 = n2;
            ViewBag.ListUserId = allUsersId;
            ViewBag.Header = "СПИСОК ВСЕХ ЗАРЕГИСТРИРОВАННЫХ ПОЛЬЗОВАТЕЛЕЙ И ИХ РОЛЕЙ:";
            return View("AllRoles", rolesANDusers);
        }

        //Возвращает в чатичное представление все роли, которые существуют в БД
        [HttpGet]
        [Route("Role/AllRolesInDBToPartial_Admin")]
        [Authorize(Roles = "admin")]
        public ActionResult AllRolesInDBToPartial_Admin()
        {
            ViewBag.Header = "СПИСОК РОЛЕЙ, СОХРАНЕННЫХ В БАЗУ ДАННЫХ :";
            int num = 0;
            ViewBag.Num = num;
            ListRoles = roleManager.Roles.ToList();
            return PartialView(ListRoles);
        }

        //Вспомогательный метод - возвращает все роли, которые существуют в БД
        [Authorize(Roles = "admin")]
        public List<IdentityRole> AllRolesInDB_Admin()
        {
            ListRoles = roleManager.Roles.ToList();
            return ListRoles;
        }

        //Список всех ролей, которые существуют в БД, для передачи в представление в виде выпадающего списка
        [Authorize(Roles = "admin")]
        public SelectList GetSelectList_Roles()
        {
            ListRoles = AllRolesInDB_Admin();
            SelectList SelectListRoles = new SelectList(ListRoles, "Name", "Name");
            return SelectListRoles;
        }

        //Добавление для пользователя новой роли - по ID пользователя
        [HttpGet]
        [Route("Role/AddNewRole/id")]
        [Authorize(Roles = "admin")]
        public ActionResult AddNewRole(string id)
        {
            ViewBag.TODO = "ДОБАВЛЕНИЕ НОВОЙ РОЛИ ЗАРЕГИСТРИРОВАННОМУ ПОЛЬЗОВАТЕЛЮ";
            ViewBag.Roles = GetSelectList_Roles();
            ApplicationUser foundUser = userManager.FindById(id);
            TempData["NameOfUser"] = foundUser.UserName;
            return View("AddNewRole");
        }

        [HttpPost]
        [Route("Role/AddNewRole/name/role")]
        [Authorize(Roles = "admin")]
        public ActionResult AddNewRole_Post(string name, string role)
        {
            ViewBag.TODO = "РЕЗУЛЬТАТ ДОБАВЛЕНИЯ НОВОЙ РОЛИ ЗАРЕГИСТРИРОВАННОМУ ПОЛЬЗОВАТЕЛЮ";
            ApplicationUser foundUser = userManager.FindByName(name);
            if (foundUser == null)
            {
                ViewBag.Result = "Пользователь с таким логином не зарегистрирован!!";
                ViewBag.Roles = GetSelectList_Roles();
                return View("AddNewRole_Post");
            }
            // проверить - возможно у запрашиваемого пользователя уже есть эта роль
            if (userManager.IsInRole(foundUser.Id, role))
            {
                ViewBag.Result = "Пользователь уже наделен правами запрашиваемой роли!!";
                ViewBag.Roles = GetSelectList_Roles();
                return View("AddNewRole_Post");
            }
            int n = 0;
            int n2 = 0;
            ViewBag.Num = n;
            ViewBag.Num2 = n2;
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
            TempData["IdOfUser"] = foundUser.Id.ToString();
            TempData["NameOfUser"] = foundUser.UserName;
            ViewBag.Result = $"Пользователь с именем: {foundUser.UserName}\0\0 обладает следующими ролями:";
            ViewBag.Result0 = $"Роль\0\0 {role}\0\0 успешно добавлена пользователю {foundUser.UserName} !";
            return View("AddNewRole_Success");
        }

        //Удаление у пользователя роли - по ID пользователя
        [HttpGet]
        [Route("Role/DeleteRole/{id:string}")]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteRole(string id)
        {
            ViewBag.TODO = "УДАЛЕНИЕ РОЛИ У ЗАРЕГИСТРИРОВАННОГО ПОЛЬЗОВАТЕЛЯ";
            ViewBag.Roles = GetSelectList_Roles();
            ApplicationUser foundUser = userManager.FindById(id);
            TempData["NameOfUser"] = foundUser.UserName;
            return View("DeleteRole");
        }

        [HttpPost]
        [Route("Role/DeleteRole/name/role")]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteRole_Post(string name, string role)
        {
            ViewBag.TODO = "РЕЗУЛЬТАТ УДАЛЕНИЯ РОЛИ У ЗАРЕГИСТРИРОВАННОГО ПОЛЬЗОВАТЕЛЯ";
            ApplicationUser foundUser = userManager.FindByName(name);
            if (foundUser == null)
            {
                ViewBag.Result = "Пользователь с таким логином не зарегистрирован!!";
                ViewBag.Roles = GetSelectList_Roles();
                return View("DeleteRole_Post");
            }
            // проверить - возможно у запрашиваемого пользователя уже есть эта роль
            if (!(userManager.IsInRole(foundUser.Id, role)))
            {
                ViewBag.Result = "Пользователь не обладает правами запрашиваемой роли!!";
                ViewBag.Roles = GetSelectList_Roles();
                return View("DeleteRole_Post");
            }
            int n = 0;
            ViewBag.Num = n;
            //Удаление у текущего пользователя выбранной роли
            userManager.RemoveFromRole(foundUser.Id, role);
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
            TempData["IdOfUser"] = foundUser.Id.ToString();
            TempData["NameOfUser"] = foundUser.UserName.ToString();
            ViewBag.Result = $"После удаления выбранной роли, пользователь с именем: {foundUser.UserName}\0\0 обладает следующими правами:";
            ViewBag.Result0 = $"Роль\0\0 {role}\0\0 успешно удалена у пользователя {foundUser.UserName} !";
            return View("DeleteRole_Success");
        }

        //Удалить роль из БД
        [HttpGet]
        [Route("Role/DeleteRoleFromDB_Admin")]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteRoleFromDB_Admin()
        {
            ViewBag.ResultPartial = "УДАЛИТЬ РОЛЬ ИЗ БД";
            ViewBag.Roles = GetSelectList_Roles();
            return PartialView("DeleteRoleFromDB_Admin");
        }
        //Удалить роль из БД
        [HttpPost]
        [Route("Role/DeleteRoleFromDB_Admin/titleRole")]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteRoleFromDB_Admin(string titleRole)
        {
            role = roleManager.Roles.FirstOrDefault(_ => _.Name == titleRole);
            string tempRolesName = role.Name;
            roleManager.Delete(role);
            result = $"РОЛЬ {tempRolesName} УСПЕШНО УДАЛЕНА ИЗ БАЗЫ ДАННЫХ !";
            return RedirectToRoute(new { controller = "Role", action = "AllRoles", res = result });
        }
    }
}