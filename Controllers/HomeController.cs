using FullStackManagementMVC.Models;
using FullStackManagementMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FullStackManagementMVC.ViewModels;
using Microsoft.EntityFrameworkCore;
using FullStackManagementMVC.Data;
using Microsoft.AspNetCore.Authorization;

namespace FullStackManagementMVC.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly WebServices webServices;
        private readonly FullStackManagementMVCContext _context;
        //DI being peformed in HomeController
        //Sets up HttpClient and Controller
        public HomeController(WebServices webServices, FullStackManagementMVCContext context)
        {
            this.webServices = webServices;
            _context = context;
        }


        [Authorize]
        //Change to public async Task<IActionResult>
        public async Task<IActionResult> Index()
        {

            //IEnumerable<LineChart> holdData;

            //await webservice
            var asyncResult = await webServices.GetData("");


            var toDoList =  await _context.ToDoList.Where(x => x.User.UserName == User.Identity.Name).ToListAsync();
            var goalList = await _context.Goals.ToListAsync();
            var macroList = await _context.Calories.Where(x => x.User.UserName == User.Identity.Name).ToListAsync();
            var lineData = _context.LineChart.OrderBy(x => x.Month).Select(x => x.Income);
            string newData = "[" + string.Join(", ", lineData) + "]";






            var homeViewModel = new HomeViewModel
            {
                Weather = asyncResult,
                ToDoItem = toDoList,
                GoalList = goalList,
                Macros = macroList,
                ChartData = newData
            };

            return View(homeViewModel);

        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //public IActionResult LineChartData()
        //{
            
        //}
    }
}
