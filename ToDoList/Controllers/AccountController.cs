using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Domain;
using ToDoList.Domain.Entities;

namespace ToDoList.Controllers
{
    public class AccountController : Controller
    {
        private DbToDoRepository repository = new DbToDoRepository();

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
                System.Web.HttpContext.Current.Session["username"] = user.Username.ToString();
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
