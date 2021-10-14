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
    public class LessonsController : Controller
    {
        private readonly Assignment1Context _context;

        public LessonsController(Assignment1Context context)
        {
            _context = context;
        }

        // GET: Lessons
        public async Task<IActionResult> Index(string searchString)
        {
            // var assignment1Context = _context.Lesson.Include(l => l.DurationCost).Include(l => l.Instrument).Include(l => l.Student).Include(l => l.Tutor);
            var lessons = from l in _context.Lesson
                          select l;

            if (!String.IsNullOrEmpty(searchString))
            {
                lessons = lessons.Where(l => l.Student.StudentFirstName.Contains(searchString));
            }

            lessons = lessons.Include(l => l.DurationCost).Include(l => l.Instrument).Include(l => l.Student).Include(l => l.Tutor);

            return View(await lessons.ToListAsync());
            
        }


        // GET: Lessons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson
                .Include(l => l.DurationCost)
                .Include(l => l.Instrument)
                .Include(l => l.Student)
                .Include(l => l.Tutor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // GET: Lessons/Create
        public IActionResult Create()
        {
            ViewData["DurationCostId"] = new SelectList(_context.DurationCost, "Id", "LessonDurationCost");
            ViewData["InstrumentId"] = new SelectList(_context.Instrument, "Id", "StudentInstrument");
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "StudentFullName");
            ViewData["TutorId"] = new SelectList(_context.Tutor, "Id", "TutorFullName");
            return View();
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentId,InstrumentId,TutorId,LessonDate,LessonTime,DurationCostId,Checkbox")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lesson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DurationCostId"] = new SelectList(_context.DurationCost, "Id", "Id", lesson.DurationCostId);
            ViewData["InstrumentId"] = new SelectList(_context.Instrument, "Id", "Id", lesson.InstrumentId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", lesson.StudentId);
            ViewData["TutorId"] = new SelectList(_context.Tutor, "Id", "Id", lesson.TutorId);
            return View(lesson);
        }

        // GET: Lessons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            ViewData["DurationCostId"] = new SelectList(_context.DurationCost, "Id", "LessonDurationCost", lesson.DurationCostId);
            ViewData["InstrumentId"] = new SelectList(_context.Instrument, "Id", "StudentInstrument", lesson.InstrumentId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "StudentFullName", lesson.StudentId);
            ViewData["TutorId"] = new SelectList(_context.Tutor, "Id", "TutorFullName", lesson.TutorId);
            return View(lesson);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,InstrumentId,TutorId,LessonDate,LessonTime,DurationCostId,Checkbox")] Lesson lesson)
        {
            if (id != lesson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lesson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonExists(lesson.Id))
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
            ViewData["DurationCostId"] = new SelectList(_context.DurationCost, "Id", "Id", lesson.DurationCostId);
            ViewData["InstrumentId"] = new SelectList(_context.Instrument, "Id", "Id", lesson.InstrumentId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", lesson.StudentId);
            ViewData["TutorId"] = new SelectList(_context.Tutor, "Id", "Id", lesson.TutorId);
            return View(lesson);
        }

        // GET: Lessons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson
                .Include(l => l.DurationCost)
                .Include(l => l.Instrument)
                .Include(l => l.Student)
                .Include(l => l.Tutor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lesson = await _context.Lesson.FindAsync(id);
            _context.Lesson.Remove(lesson);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LessonExists(int id)
        {
            return _context.Lesson.Any(e => e.Id == id);
        }
    }
}
