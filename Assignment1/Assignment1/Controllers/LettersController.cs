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
    public class LettersController : Controller
    {
        private readonly Assignment1Context _context;

        public LettersController(Assignment1Context context)
        {
            _context = context;
        }

        // GET: Letters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Letter.ToListAsync());
        }

        // GET: Letters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var letter = await _context.Letter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (letter == null)
            {
                return NotFound();
            }

            return View(letter);
        }

        // GET: Letters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Letters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentName,Begin_comment,Term,Term_Start,Payment_Final,Reference_Number,Student_FirstName,Student_LastName,Amount,Year,Semester,Bank,Account_Name,BSB,Account_Number,Signature")] Letter letter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(letter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(letter);
        }

        // GET: Letters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var letter = await _context.Letter.FindAsync(id);
            if (letter == null)
            {
                return NotFound();
            }
            return View(letter);
        }

        // POST: Letters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentName,Begin_comment,Term,Term_Start,Payment_Final,Reference_Number,Student_FirstName,Student_LastName,Amount,Year,Semester,Bank,Account_Name,BSB,Account_Number,Signature")] Letter letter)
        {
            if (id != letter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(letter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LetterExists(letter.Id))
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
            return View(letter);
        }

        // GET: Letters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var letter = await _context.Letter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (letter == null)
            {
                return NotFound();
            }

            return View(letter);
        }

        // POST: Letters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var letter = await _context.Letter.FindAsync(id);
            _context.Letter.Remove(letter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LetterExists(int id)
        {
            return _context.Letter.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Prime(Student student)
        {
            var prev_letter = _context.Letter.FirstOrDefault(); // For Letter deails that stay the same (didn't get that far).
         
            Letter letter = new()
            {
                Student_FirstName = student.StudentFirstName,
                Student_LastName = student.StudentLastName,
                Amount = _context.Lesson.Where(l => l.Id == student.Id).Where(l => l.Paid == false).Sum(l => l.DurationCost.LessonCost).ToString(), // Doesn't add all cost vaules
                Year = DateTime.Now.Year.ToString(),
                //Semester =

                Bank = "CYCM Bank placeholder",
                Account_Name = "CYCM Account Name placeholder",
                BSB = "CYCM BSB placeholder",
                Account_Number = "CYCM Account Number placeholder"
                //Signature =
            };
            return View(letter);
        }
    }
}
