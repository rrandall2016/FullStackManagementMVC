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
using Microsoft.AspNetCore.Authorization;

namespace FullStackManagementMVC.Controllers
{
    public class ExercisesController : Controller
    {
        private readonly FullStackManagementMVCContext _context;

        public ExercisesController(FullStackManagementMVCContext context)
        {
            _context = context;
        }

        // GET: Exercises
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var lists = await _context.Exercises.Where(x => x.User.UserName == User.Identity.Name).ToListAsync();
                //OrderBy(x => x.MuscleGroup);
            return View(lists);
        }

        // GET: Exercises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercises = await _context.Exercises
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exercises == null)
            {
                return NotFound();
            }

            return View(exercises);
        }

        // GET: Exercises/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostData data)
        {
            var uid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (uid is null) return Unauthorized();

             _context.Exercises.Add(new Exercises
            {
                Name = data.Name,
                MuscleGroup = data.MuscleGroup,
                Reps = data.Reps,
                Sets = data.Sets,
                Weight = data.Weights,
                UserId = uid
            });
            await _context.SaveChangesAsync();

            //return RedirectToAction(nameof(Index));
            return View();
        }

        public record PostData(string Name, string MuscleGroup, int Reps, int Sets, int Weights);


        
        // GET: Exercises/Edit/5
        //Fix db bug
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercises = await _context.Exercises.FindAsync(id);
            if (exercises == null)
            {
                return NotFound();
            }
            return View(exercises);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PostData2 data)
        {
            //Get ID of currently logged in user
            var uid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (uid is null) return Unauthorized();
            var exercise = await _context.Exercises
              .Where(e => e.Id == data.Id)
              // we can check if it belongs to currently logged-in user too
              .Where(e => e.UserId == uid)
              .FirstOrDefaultAsync();

            if (exercise is null) return NotFound();

            if (!ModelState.IsValid) return View(exercise);

            exercise.Name = data.Name;
            exercise.MuscleGroup = data.MuscleGroup;
            exercise.Reps = data.Reps;
            exercise.Sets = data.Sets;
            exercise.Weight = data.Weight;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public sealed record PostData2(int Id, string Name, string MuscleGroup, int Reps, int Sets, int Weight);
        // GET: Exercises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercises = await _context.Exercises
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exercises == null)
            {
                return NotFound();
            }

            return View(exercises);
        }

        // POST: Exercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exercises = await _context.Exercises.FindAsync(id);
            _context.Exercises.Remove(exercises);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExercisesExists(int id)
        {
            return _context.Exercises.Any(e => e.Id == id);
        }
    }
}
