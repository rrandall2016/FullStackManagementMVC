using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackManagementMVC.Models
{
    public class LineChart
    {
        public int Id { get; set; }

        public IndividualUsers User { get; set; }
        public string UserId { get; set; }
        public string Income { get; set; }
        
        public int Month { get; set; }
    }
}
