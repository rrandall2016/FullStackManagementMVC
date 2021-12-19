using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackManagementMVC.Models
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public IndividualUsers User { get; set; }
        public string Description { get; set; }

        public bool isDone { get; set; }

        //public virtual ApplicationUser User { get; set; }



    }
}
