using FullStackManagementMVC.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FullStackManagementMVC.Controllers
{
    

    public class ChartController : Controller
    {
        private readonly FullStackManagementMVCContext _context;
        //DI being peformed in HomeController
        //Sets up HttpClient and Controller
        public ChartController(FullStackManagementMVCContext context)
        {

            _context = context;
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<bool> Edit(int month, string income)
        {
            var uid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (uid is null) return false;


            var LineChart = await _context.LineChart.FirstOrDefaultAsync(Lc => Lc.Id == month);
            if (LineChart == null)
            {
                LineChart = new Models.LineChart()
                {
                    Id = month,
                    Income = income,
                    UserId = uid

                };
                _context.LineChart.Add(LineChart);
            }
            else
            {
                LineChart.Income = income;

            }
                await _context.SaveChangesAsync();
            
            return true;
        }
        public record PostData(int month, string income);

        // GET: ChartUpdateController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ChartUpdateController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ChartUpdateController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChartUpdateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        // GET: ChartUpdateController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChartUpdateController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
