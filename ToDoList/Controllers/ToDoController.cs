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
    public class ToDoController : Controller
    {
        private IToDoRepository repository;

        public ToDoController(IToDoRepository repos)
        {
            repository = repos;
        }

        public ActionResult List(UserModel user)
        {
            if (user.Username == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [HttpPost]
        public void Add(UserModel user, string subject)
        {
            ToDoRecord record = new ToDoRecord();
            record.Subject = subject;
            record.IsComplete = false;
            record.Author = user.Username;
            record.CreatedOn = DateTime.Now;

            repository.AddRecord(record);
        }

        public PartialViewResult GetAllRecords(UserModel user)
        {
            string currUser = user.Username;
            var userRecords = repository.Records.Where(x => x.Author == currUser).OrderByDescending(x => x.CreatedOn).ToList();

            return PartialView("Shared/Records", userRecords);
        }

        public PartialViewResult GetNotFinishedRecords(UserModel user)
        {
            string currUser = user.Username;
            var userRecords = repository.Records.Where(x => x.Author == currUser && !x.IsComplete).OrderByDescending(x => x.CreatedOn).ToList();

            return PartialView("Shared/Records", userRecords);
        }

        public PartialViewResult GetOnlyDoneRecords(UserModel user)
        {
            string currUser = user.Username;
            var userRecords = repository.Records.Where(x => x.Author == currUser && x.IsComplete).OrderByDescending(x => x.CreatedOn).ToList();

            return PartialView("Shared/Records", userRecords);
        }

        public PartialViewResult Delete(UserModel user, string id)
        {
            repository.RemoveRecord(Guid.Parse(id));
            string currUser = user.Username;
            var userRecords = repository.Records.Where(x => x.Author == currUser).OrderByDescending(x=>x.CreatedOn).ToList();

            return PartialView("Shared/Records", userRecords);
        }

        public PartialViewResult Done(UserModel user, string id)
        {
            repository.MakeDoneRecord(Guid.Parse(id));
            string currUser = user.Username;
            var userRecords = repository.Records.Where(x => x.Author == currUser).OrderByDescending(x => x.CreatedOn).ToList();

            return PartialView("Shared/Records", userRecords);
        }

    }
}
