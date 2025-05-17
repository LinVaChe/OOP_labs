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
    public class GameAndEndingsController : Controller
    {
        private readonly ApplicationContext _context;

        public GameAndEndingsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: GameAndEndings
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.GameAndEnding.Include(g => g.Ending).Include(g => g.Game);
            return View(await applicationContext.ToListAsync());
        }

        // GET: GameAndEndings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameAndEnding = await _context.GameAndEnding
                .Include(g => g.Ending)
                .Include(g => g.Game)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameAndEnding == null)
            {
                return NotFound();
            }

            return View(gameAndEnding);
        }

        // GET: GameAndEndings/Create
        public IActionResult Create()
        {
            ViewData["EndingId"] = new SelectList(_context.Endings, "Id", "Id");
            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Id");
            return View();
        }

        // POST: GameAndEndings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GameId,EndingId")] GameAndEnding gameAndEnding)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameAndEnding);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EndingId"] = new SelectList(_context.Endings, "Id", "Id", gameAndEnding.EndingId);
            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Id", gameAndEnding.GameId);
            return View(gameAndEnding);
        }

        // GET: GameAndEndings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameAndEnding = await _context.GameAndEnding.FindAsync(id);
            if (gameAndEnding == null)
            {
                return NotFound();
            }
            ViewData["EndingId"] = new SelectList(_context.Endings, "Id", "Id", gameAndEnding.EndingId);
            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Id", gameAndEnding.GameId);
            return View(gameAndEnding);
        }

        // POST: GameAndEndings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GameId,EndingId")] GameAndEnding gameAndEnding)
        {
            if (id != gameAndEnding.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameAndEnding);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameAndEndingExists(gameAndEnding.Id))
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
            ViewData["EndingId"] = new SelectList(_context.Endings, "Id", "Id", gameAndEnding.EndingId);
            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Id", gameAndEnding.GameId);
            return View(gameAndEnding);
        }

        // GET: GameAndEndings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameAndEnding = await _context.GameAndEnding
                .Include(g => g.Ending)
                .Include(g => g.Game)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameAndEnding == null)
            {
                return NotFound();
            }

            return View(gameAndEnding);
        }

        // POST: GameAndEndings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameAndEnding = await _context.GameAndEnding.FindAsync(id);
            if (gameAndEnding != null)
            {
                _context.GameAndEnding.Remove(gameAndEnding);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameAndEndingExists(int id)
        {
            return _context.GameAndEnding.Any(e => e.Id == id);
        }
    }
}
