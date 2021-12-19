using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FullStackManagementMVC.Data;
using FullStackManagementMVC.Models;
using System.Security.Claims;

namespace FullStackManagementMVC.Controllers
{
    public class CaloriesController : Controller
    {
        private readonly FullStackManagementMVCContext _context;

        public CaloriesController(FullStackManagementMVCContext context)
        {
            _context = context;
        }

        // GET: Calories
        public async Task<IActionResult> Index()
        {

            return View(await _context.Calories.Where(x => x.User.UserName == User.Identity.Name).ToListAsync());
        }

        // GET: Calories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calories = await _context.Calories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calories == null)
            {
                return NotFound();
            }

            return View(calories);
        }

        // GET: Calories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Calories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BurnTarget,IntakeTarget,Protein,Fat,Carbs")] Calories calories)
        {

            var uid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (uid is null) return Unauthorized();
            calories.UserId = uid;

            if (ModelState.IsValid)
            {
                _context.Add(calories);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calories);
        }

        // GET: Calories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calories = await _context.Calories.FindAsync(id);
            if (calories == null)
            {
                return NotFound();
            }
            return View(calories);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PostData data)
        {
            //Get ID of currently logged in user
            var uid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (uid is null) return Unauthorized();
            var calories = await _context.Calories
              .Where(e => e.Id == data.Id)
              // we can check if it belongs to currently logged-in user too
              .Where(e => e.UserId == uid)
              .FirstOrDefaultAsync();

            if (calories is null) return NotFound();

            if (!ModelState.IsValid) return View(calories);

            calories.BurnTarget = data.BurnTarget;
            calories.IntakeTarget = data.IntakeTarget;
            calories.Protein = data.Protein;
            calories.Carbs = data.Carbs;
            calories.Fat = data.Fat;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public sealed record PostData(int Id, int BurnTarget, int IntakeTarget, int Protein, int Carbs, int Fat);

        // GET: Calories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calories = await _context.Calories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calories == null)
            {
                return NotFound();
            }

            return View(calories);
        }

        // POST: Calories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calories = await _context.Calories.FindAsync(id);
            _context.Calories.Remove(calories);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaloriesExists(int id)
        {
            return _context.Calories.Any(e => e.Id == id);
        }
    }
}
