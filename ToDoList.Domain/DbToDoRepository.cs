using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain
{
    public class DbToDoRepository
    {
        DbToDoContext context = new DbToDoContext();

        public IEnumerable<User> Users
        {
            get { return context.Users; }
        }

        public int AddUser(User user)
        {
            context.Users.Add(user);
            return context.SaveChanges();
        }

        public IEnumerable<ToDoRecord> Records
        {
            get { return context.Records; }
        }

        public int AddRecord(ToDoRecord toDo)
        {
            context.Records.Add(toDo);
            return context.SaveChanges();
        }

        public int MakeDoneRecord(Guid recordId)
        {
            var recordToBeDone = context.Records.FirstOrDefault(x => x.Id == recordId);
            if (recordToBeDone != null)
            {
                recordToBeDone.IsComplete = true;
            }
                
            return context.SaveChanges();
        }

        public int RemoveRecord(Guid recordId)
        {
            var recordToDelete = context.Records.FirstOrDefault(x => x.Id == recordId);
            context.Records.Remove(recordToDelete);
            return context.SaveChanges();
        }
    }
}
