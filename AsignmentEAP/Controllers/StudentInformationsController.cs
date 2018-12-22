using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsignmentEAP.Models;

namespace AsignmentEAP.Controllers
{
    public class StudentInformationsController : Controller
    {
        private readonly AsignmentEAPContext _context;

        public StudentInformationsController(AsignmentEAPContext context)
        {
            _context = context;
        }

        // GET: StudentInformations
        public async Task<IActionResult> Index()
        {
            var asignmentEAPContext = _context.StudentInformation.Include(s => s.Account).Include(s => s.Classroom);
            return View(await asignmentEAPContext.ToListAsync());
        }

        // GET: StudentInformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentInformation = await _context.StudentInformation
                .Include(s => s.Account)
                .Include(s => s.Classroom)
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (studentInformation == null)
            {
                return NotFound();
            }

            return View(studentInformation);
        }

        // GET: StudentInformations/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "Id");
            ViewData["ClassId"] = new SelectList(_context.Classroom, "Id", "Id");
            return View();
        }

        // POST: StudentInformations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountId,ClassId,FirstName,LastName,Phone,Address,BirthDay")] StudentInformation studentInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "Id", studentInformation.AccountId);
            ViewData["ClassId"] = new SelectList(_context.Classroom, "Id", "Id", studentInformation.ClassId);
            return View(studentInformation);
        }

        // GET: StudentInformations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentInformation = await _context.StudentInformation.FindAsync(id);
            if (studentInformation == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "Id", studentInformation.AccountId);
            ViewData["ClassId"] = new SelectList(_context.Classroom, "Id", "Id", studentInformation.ClassId);
            return View(studentInformation);
        }

        // POST: StudentInformations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountId,ClassId,FirstName,LastName,Phone,Address,BirthDay,CreateAt,UpdateAt")] StudentInformation studentInformation)
        {
            if (id != studentInformation.AccountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentInformationExists(studentInformation.AccountId))
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
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "Id", studentInformation.AccountId);
            ViewData["ClassId"] = new SelectList(_context.Classroom, "Id", "Id", studentInformation.ClassId);
            return View(studentInformation);
        }

        // GET: StudentInformations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentInformation = await _context.StudentInformation
                .Include(s => s.Account)
                .Include(s => s.Classroom)
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (studentInformation == null)
            {
                return NotFound();
            }

            return View(studentInformation);
        }

        // POST: StudentInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentInformation = await _context.StudentInformation.FindAsync(id);
            _context.StudentInformation.Remove(studentInformation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentInformationExists(int id)
        {
            return _context.StudentInformation.Any(e => e.AccountId == id);
        }
    }
}
