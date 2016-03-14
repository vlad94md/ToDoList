using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Domain;
using ToDoList.Domain.Entities;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        private DbToDoRepository repository = new DbToDoRepository();

        public ActionResult List()
        {
            string helloString = String.Empty;

            if (Session["username"] != null)
            {
                helloString = (string)Session["username"];
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Add(string subject)
        {
            ToDoRecord record = new ToDoRecord();
            record.Subject = subject;
            record.IsComplete = false;
            record.Author = (string) Session["username"];
            record.CreatedOn = DateTime.Now;
            repository.AddRecord(record);

            var userRecords = repository.Records.Where(x => x.Author == record.Author).OrderByDescending(x => x.CreatedOn).ToList();

            return PartialView("Records", userRecords);
        }

        public ActionResult MyRecords()
        {
            string currUser = (string) Session["username"];
            var userRecords = repository.Records.Where(x => x.Author == currUser).OrderByDescending(x => x.CreatedOn).ToList();

            return PartialView("Records", userRecords);
        }

        public ActionResult Delete(string id)
        {
            repository.RemoveRecord(Guid.Parse(id));
            string currUser = (string)Session["username"];
            var userRecords = repository.Records.Where(x => x.Author == currUser).OrderByDescending(x=>x.CreatedOn).ToList();

            return PartialView("Records", userRecords);
        }

        public ActionResult Done(string id)
        {
            repository.MakeDoneRecord(Guid.Parse(id));
            string currUser = (string)Session["username"];
            var userRecords = repository.Records.Where(x => x.Author == currUser).OrderByDescending(x => x.CreatedOn).ToList();

            return PartialView("Records", userRecords);
        }

    }
}
