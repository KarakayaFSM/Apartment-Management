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
    public class FlatsController : Controller
    {
        private readonly AppDbContext _context;

        public FlatsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Flats
        public async Task<IActionResult> Index()
        {
            return View(await _context.Flats.ToListAsync());
        }

        // GET: Flats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flat = await _context.Flats
                .FirstOrDefaultAsync(m => m.ID == id);
            if (flat == null)
            {
                return NotFound();
            }

            return View(flat);
        }

        // GET: Flats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FlatLabel,BlockCode,IsFull,FlatSize,Floor,DoorNum")] Flat flat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flat);
        }

        // GET: Flats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flat = await _context.Flats.FindAsync(id);
            if (flat == null)
            {
                return NotFound();
            }
            return View(flat);
        }

        // POST: Flats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FlatLabel,BlockCode,IsFull,FlatSize,Floor,DoorNum")] Flat flat)
        {
            if (id != flat.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlatExists(flat.ID))
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
            return View(flat);
        }

        // GET: Flats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flat = await _context.Flats
                .FirstOrDefaultAsync(m => m.ID == id);
            if (flat == null)
            {
                return NotFound();
            }

            return View(flat);
        }

        // POST: Flats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flat = await _context.Flats.FindAsync(id);
            _context.Flats.Remove(flat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlatExists(int id)
        {
            return _context.Flats.Any(e => e.ID == id);
        }
    }
}
