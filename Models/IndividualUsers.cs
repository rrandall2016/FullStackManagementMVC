using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackManagementMVC.Models
{
    public class IndividualUsers : IdentityUser
    {
        public ICollection<Exercises> Exercise { get; set; }
        public ICollection<Calories> Calorie { get; set; }
        public ICollection<Goals> Goals { get; set; }
        public ICollection<ToDoList> ToDoList { get; set; }

    }
}
