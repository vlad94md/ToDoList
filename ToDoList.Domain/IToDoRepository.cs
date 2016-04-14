using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain
{
    public interface IToDoRepository
    {
        IEnumerable<User> Users { get; }
        int AddUser(User user);
        IEnumerable<ToDoRecord> Records { get; }
        int AddRecord(ToDoRecord toDo);
        int MakeDoneRecord(Guid recordId);
        int RemoveRecord(Guid recordId);
    }
}
