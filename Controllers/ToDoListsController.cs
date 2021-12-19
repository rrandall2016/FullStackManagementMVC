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
    public class ToDoListsController : Controller
    {
        private readonly FullStackManagementMVCContext _context;

        public ToDoListsController(FullStackManagementMVCContext context)
        {
            _context = context;
        }

        // GET: ToDoLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.ToDoList.ToListAsync());
        }
        public IEnumerable<ToDoList> GetMyToDoes()
        {
            return  _context.ToDoList.ToList();
        }
        public async Task<ActionResult> BuildToDoTable()
        {

            return PartialView("_ToDoTable", await _context.ToDoList.Where(x => x.User.UserName == User.Identity.Name).ToListAsync());
        }
        
        // GET: ToDoLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoList = await _context.ToDoList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDoList == null)
            {
                return NotFound();
            }

            return View(toDoList);
        }

        // GET: ToDoLists/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostData data)
        {
            var uid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (uid is null) return Unauthorized();

            _context.ToDoList.Add(new ToDoList
            {
                Description = data.Description,
                isDone = data.isDone,
                UserId = uid
            });
            await _context.SaveChangesAsync();

            //return RedirectToAction(nameof(Index));
            return View();
        }

        public record PostData(string Description, bool isDone);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AJAXCreate([Bind("Id,Description,isDone")] ToDoList toDoList)
        {
            if (ModelState.IsValid)
            {
                toDoList.isDone = false;
                _context.Add(toDoList);
                await _context.SaveChangesAsync();
                
            }
            return PartialView("_ToDoTable", await _context.ToDoList.ToListAsync());
        }

        // GET: ToDoLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoList = await _context.ToDoList.FindAsync(id);
            if (toDoList == null)
            {
                return NotFound();
            }
            return View(toDoList);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PostData3 data)
        {
            //Get ID of currently logged in user
            var uid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (uid is null) return Unauthorized();
            var toDoList = await _context.ToDoList
              .Where(e => e.Id == data.Id)
              // we can check if it belongs to currently logged-in user too
              .Where(e => e.UserId == uid)
              .FirstOrDefaultAsync();

            if (toDoList is null) return NotFound();

            if (!ModelState.IsValid) return View(toDoList);

            toDoList.Description = data.Description;
            toDoList.isDone = data.isDone;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public sealed record PostData3(int Id, string Description, bool isDone);
        // GET: ToDoLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoList = await _context.ToDoList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDoList == null)
            {
                return NotFound();
            }

            return View(toDoList);
        }

        // POST: ToDoLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toDoList = await _context.ToDoList.FindAsync(id);
            _context.ToDoList.Remove(toDoList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToDoListExists(int id)
        {
            return _context.ToDoList.Any(e => e.Id == id);
        }
    }
}
