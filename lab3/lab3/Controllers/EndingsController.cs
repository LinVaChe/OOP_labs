using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab3;
using lab3.Models;

namespace lab3.Controllers
{
    public class EndingsController : Controller
    {
        private readonly ApplicationContext _context;

        public EndingsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Endings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ending.ToListAsync());
        }

        // GET: Endings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ending = await _context.Ending
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ending == null)
            {
                return NotFound();
            }

            return View(ending);
        }

        // GET: Endings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Endings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Ending ending)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ending);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ending);
        }

        // GET: Endings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ending = await _context.Ending.FindAsync(id);
            if (ending == null)
            {
                return NotFound();
            }
            return View(ending);
        }

        // POST: Endings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Ending ending)
        {
            if (id != ending.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ending);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EndingExists(ending.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ending);
        }

        // GET: Endings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ending = await _context.Ending
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ending == null)
            {
                return NotFound();
            }

            return View(ending);
        }

        // POST: Endings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ending = await _context.Ending.FindAsync(id);
            if (ending != null)
            {
                _context.Ending.Remove(ending);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EndingExists(int id)
        {
            return _context.Ending.Any(e => e.Id == id);
        }
    }
}
