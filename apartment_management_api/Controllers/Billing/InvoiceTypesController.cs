using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Apartment_Management.Data;
using Apartment_Management.Models;

namespace Apartment_Management.Controllers.Billing
{
    public class InvoiceTypesController : Controller
    {
        private readonly AppDbContext _context;

        public InvoiceTypesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: InvoiceTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvoiceTypes.ToListAsync());
        }

        // GET: InvoiceTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceType = await _context.InvoiceTypes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (invoiceType == null)
            {
                return NotFound();
            }

            return View(invoiceType);
        }

        // GET: InvoiceTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvoiceTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Charge")] InvoiceType invoiceType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoiceType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invoiceType);
        }

        // GET: InvoiceTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceType = await _context.InvoiceTypes.FindAsync(id);
            if (invoiceType == null)
            {
                return NotFound();
            }
            return View(invoiceType);
        }

        // POST: InvoiceTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Charge")] InvoiceType invoiceType)
        {
            if (id != invoiceType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoiceType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceTypeExists(invoiceType.ID))
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
            return View(invoiceType);
        }

        // GET: InvoiceTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceType = await _context.InvoiceTypes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (invoiceType == null)
            {
                return NotFound();
            }

            return View(invoiceType);
        }

        // POST: InvoiceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoiceType = await _context.InvoiceTypes.FindAsync(id);
            _context.InvoiceTypes.Remove(invoiceType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceTypeExists(int id)
        {
            return _context.InvoiceTypes.Any(e => e.ID == id);
        }
    }
}
