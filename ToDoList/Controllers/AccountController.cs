using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Domain;
using ToDoList.Domain.Entities;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class AccountController : Controller
    {
        private IToDoRepository repository;

        public AccountController(IToDoRepository repos)
        {
            repository = repos;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            repository.AddUser(user);

            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var currUser = repository.Users.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);

            if (currUser != null)
            {
                UserModel currentUser = new UserModel()
                {
                    Username = user.Username,
                    FirstName = user.Username,
                    LastName = user.LastName
                };
                System.Web.HttpContext.Current.Session["user"] = currentUser;
            }

            return RedirectToAction("List", "ToDo");
        }

        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Login", "Account");
        }

    }
}
