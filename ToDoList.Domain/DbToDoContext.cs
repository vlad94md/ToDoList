using System.Data.Entity;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain
{
    public class DbToDoContext : DbContext
    {
        public DbToDoContext()
        {
            //Database.SetInitializer<DbToDoContext>(new DropCreateDatabaseIfModelChanges<DbToDoContext>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ToDoRecord> Records { get; set; }
    }
}