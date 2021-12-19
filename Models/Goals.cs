using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackManagementMVC.Models
{
    public class Goals
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public IndividualUsers User { get; set; }
        public string Goal { get; set; }
        public int Percentage { get; set; }
    }
}
