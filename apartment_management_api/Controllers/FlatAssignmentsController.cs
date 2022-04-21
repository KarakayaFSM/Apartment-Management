using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Apartment_Management.Data;
using Apartment_Management.Models;

namespace Apartment_Management.Controllers
{
    public class FlatAssignmentsController : Controller
    {
        private readonly AppDbContext _context;

        public FlatAssignmentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: FlatAssignments
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.FlatAssignments.Include(f => f.Flat).Include(f => f.User);
            return View(await appDbContext.ToListAsync());
        }

        // GET: FlatAssignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flatAssignment = await _context.FlatAssignments
                .Include(f => f.Flat)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.FlatID == id);
            if (flatAssignment == null)
            {
                return NotFound();
            }

            return View(flatAssignment);
        }

        // GET: FlatAssignments/Create
        public IActionResult Create()
        {
            ViewData["FlatID"] = new SelectList(_context.Flats, "ID", "BlockCode");
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "Email");
            return View();
        }

        // POST: FlatAssignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlatID,UserID")] FlatAssignment flatAssignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flatAssignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FlatID"] = new SelectList(_context.Flats, "ID", "BlockCode", flatAssignment.FlatID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "Email", flatAssignment.UserID);
            return View(flatAssignment);
        }

        // GET: FlatAssignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flatAssignment = await _context.FlatAssignments.FindAsync(id);
            if (flatAssignment == null)
            {
                return NotFound();
            }
            ViewData["FlatID"] = new SelectList(_context.Flats, "ID", "BlockCode", flatAssignment.FlatID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "Email", flatAssignment.UserID);
            return View(flatAssignment);
        }

        // POST: FlatAssignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlatID,UserID")] FlatAssignment flatAssignment)
        {
            if (id != flatAssignment.FlatID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flatAssignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlatAssignmentExists(flatAssignment.FlatID))
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
            ViewData["FlatID"] = new SelectList(_context.Flats, "ID", "BlockCode", flatAssignment.FlatID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "Email", flatAssignment.UserID);
            return View(flatAssignment);
        }

        // GET: FlatAssignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flatAssignment = await _context.FlatAssignments
                .Include(f => f.Flat)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.FlatID == id);
            if (flatAssignment == null)
            {
                return NotFound();
            }

            return View(flatAssignment);
        }

        // POST: FlatAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flatAssignment = await _context.FlatAssignments.FindAsync(id);
            _context.FlatAssignments.Remove(flatAssignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlatAssignmentExists(int id)
        {
            return _context.FlatAssignments.Any(e => e.FlatID == id);
        }
    }
}
