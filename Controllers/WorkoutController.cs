using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackManagementMVC.Controllers
{
    public class WorkoutController : Controller
    {
        public IActionResult WorkoutChart()
        {
            return View();
        }
    }
}
