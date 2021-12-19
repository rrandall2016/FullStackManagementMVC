using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FullStackManagementMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace FullStackManagementMVC.Data
{
    public class FullStackManagementMVCContext : IdentityDbContext<IndividualUsers>
    {
        public FullStackManagementMVCContext (DbContextOptions<FullStackManagementMVCContext> options)
            : base(options)
        {
        }

        public DbSet<FullStackManagementMVC.Models.Exercises> Exercises { get; set; }

        public DbSet<FullStackManagementMVC.Models.ToDoList> ToDoList { get; set; }

        public DbSet<FullStackManagementMVC.Models.Goals> Goals { get; set; }

        public DbSet<FullStackManagementMVC.Models.Calories> Calories { get; set; }
        public DbSet<FullStackManagementMVC.Models.LineChart> LineChart { get; set; }
    }
}
