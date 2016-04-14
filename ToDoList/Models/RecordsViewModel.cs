using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.Domain.Entities;

namespace ToDoList.Models
{
    public class RecordsViewModel
    {
        public List<ToDoRecord> Records { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}