using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackManagementMVC.Models
{
    public class Exercises
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }
        public IndividualUsers User { get; set; }
        public string Name { get; set; }
        public string MuscleGroup { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }
        public int Weight { get; set; }
       
    }
}
