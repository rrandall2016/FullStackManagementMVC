using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackManagementMVC.Models
{
    public class Calories
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public IndividualUsers User { get; set; }
        public int BurnTarget { get; set; }
        public int IntakeTarget { get; set; }
        public int Protein { get; set; }
        public int Fat { get; set; }
        public int Carbs { get; set; }

        public int test { get; set; }
    }
}
