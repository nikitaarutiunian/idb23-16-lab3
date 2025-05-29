using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LAB3;
using LAB3.Models;

namespace LAB3.Controllers
{
    public class ConstellationsController : Controller
    {
        private readonly SkylineContext _context;

        public ConstellationsController(SkylineContext context)
        {
            _context = context;
        }

        // GET: Constellations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Constellations.ToListAsync());
        }

        // GET: Constellations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var constellation = await _context.Constellations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (constellation == null)
            {
                return NotFound();
            }

            return View(constellation);
        }

        // GET: Constellations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Constellations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ShapeDescription")] Constellation constellation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(constellation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(constellation);
        }

        // GET: Constellations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var constellation = await _context.Constellations.FindAsync(id);
            if (constellation == null)
            {
                return NotFound();
            }
            return View(constellation);
        }

        // POST: Constellations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ShapeDescription")] Constellation constellation)
        {
            if (id != constellation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(constellation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConstellationExists(constellation.Id))
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
            return View(constellation);
        }

        // GET: Constellations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var constellation = await _context.Constellations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (constellation == null)
            {
                return NotFound();
            }

            return View(constellation);
        }

        // POST: Constellations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var constellation = await _context.Constellations.FindAsync(id);
            if (constellation != null)
            {
                _context.Constellations.Remove(constellation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConstellationExists(int id)
        {
            return _context.Constellations.Any(e => e.Id == id);
        }
    }
}
