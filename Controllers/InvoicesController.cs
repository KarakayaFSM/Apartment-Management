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
    public class InvoicesController : Controller
    {
        private readonly AppDbContext _context;

        public InvoicesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Invoices
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Invoices.Include(i => i.Flat).Include(i => i.InvoiceType).Include(i => i.Period);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices
                .Include(i => i.Flat)
                .Include(i => i.InvoiceType)
                .Include(i => i.Period)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // GET: Invoices/Create
        public IActionResult Create()
        {
            ViewData["FlatID"] = new SelectList(_context.Flats, "ID", "BlockCode");
            ViewData["InvoiceTypeID"] = new SelectList(_context.InvoiceTypes, "ID", "Name");
            ViewData["PeriodID"] = new SelectList(_context.Periods, "ID", "Name");
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PeriodID,InvoiceTypeID,FlatID,Amount")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FlatID"] = new SelectList(_context.Flats, "ID", "BlockCode", invoice.FlatID);
            ViewData["InvoiceTypeID"] = new SelectList(_context.InvoiceTypes, "ID", "Name", invoice.InvoiceTypeID);
            ViewData["PeriodID"] = new SelectList(_context.Periods, "ID", "Name", invoice.PeriodID);
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            ViewData["FlatID"] = new SelectList(_context.Flats, "ID", "BlockCode", invoice.FlatID);
            ViewData["InvoiceTypeID"] = new SelectList(_context.InvoiceTypes, "ID", "Name", invoice.InvoiceTypeID);
            ViewData["PeriodID"] = new SelectList(_context.Periods, "ID", "Name", invoice.PeriodID);
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PeriodID,InvoiceTypeID,FlatID,Amount")] Invoice invoice)
        {
            if (id != invoice.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceExists(invoice.ID))
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
            ViewData["FlatID"] = new SelectList(_context.Flats, "ID", "BlockCode", invoice.FlatID);
            ViewData["InvoiceTypeID"] = new SelectList(_context.InvoiceTypes, "ID", "Name", invoice.InvoiceTypeID);
            ViewData["PeriodID"] = new SelectList(_context.Periods, "ID", "Name", invoice.PeriodID);
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices
                .Include(i => i.Flat)
                .Include(i => i.InvoiceType)
                .Include(i => i.Period)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoices.Any(e => e.ID == id);
        }
    }
}
