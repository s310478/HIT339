using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment1.Data;
using Assignment1.Models;

namespace Assignment1.Controllers
{
    public class DurationCostsController : Controller
    {
        private readonly Assignment1Context _context;

        public DurationCostsController(Assignment1Context context)
        {
            _context = context;
        }

        // GET: DurationCosts
        public async Task<IActionResult> Index()
        {
            return View(await _context.DurationCost.ToListAsync());
        }

        // GET: DurationCosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var durationCost = await _context.DurationCost
                .FirstOrDefaultAsync(m => m.Id == id);
            if (durationCost == null)
            {
                return NotFound();
            }

            return View(durationCost);
        }

        // GET: DurationCosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DurationCosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LessonDuration,LessonCost")] DurationCost durationCost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(durationCost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(durationCost);
        }

        // GET: DurationCosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var durationCost = await _context.DurationCost.FindAsync(id);
            if (durationCost == null)
            {
                return NotFound();
            }
            return View(durationCost);
        }

        // POST: DurationCosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LessonDuration,LessonCost")] DurationCost durationCost)
        {
            if (id != durationCost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(durationCost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DurationCostExists(durationCost.Id))
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
            return View(durationCost);
        }

        // GET: DurationCosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var durationCost = await _context.DurationCost
                .FirstOrDefaultAsync(m => m.Id == id);
            if (durationCost == null)
            {
                return NotFound();
            }

            return View(durationCost);
        }

        // POST: DurationCosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var durationCost = await _context.DurationCost.FindAsync(id);
            _context.DurationCost.Remove(durationCost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DurationCostExists(int id)
        {
            return _context.DurationCost.Any(e => e.Id == id);
        }
    }
}
