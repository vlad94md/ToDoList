using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Domain.Entities
{
    public class ToDoRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Author { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsComplete { get; set; }
    }
}
