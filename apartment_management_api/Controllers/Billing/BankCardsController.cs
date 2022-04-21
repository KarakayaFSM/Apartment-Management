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
    public class BankCardsController : Controller
    {
        private readonly AppDbContext _context;

        public BankCardsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: BankCards
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.BankCards.Include(b => b.User);
            return View(await appDbContext.ToListAsync());
        }

        // GET: BankCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankCard = await _context.BankCards
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bankCard == null)
            {
                return NotFound();
            }

            return View(bankCard);
        }

        // GET: BankCards/Create
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "Email");
            return View();
        }

        // POST: BankCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserID,Name,CardHolderName,CardNumber,ExpireYear,ExpireMonth,CVV")] BankCard bankCard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bankCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "Email", bankCard.UserID);
            return View(bankCard);
        }

        // GET: BankCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankCard = await _context.BankCards.FindAsync(id);
            if (bankCard == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "Email", bankCard.UserID);
            return View(bankCard);
        }

        // POST: BankCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserID,Name,CardHolderName,CardNumber,ExpireYear,ExpireMonth,CVV")] BankCard bankCard)
        {
            if (id != bankCard.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bankCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankCardExists(bankCard.ID))
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
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "Email", bankCard.UserID);
            return View(bankCard);
        }

        // GET: BankCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankCard = await _context.BankCards
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bankCard == null)
            {
                return NotFound();
            }

            return View(bankCard);
        }

        // POST: BankCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bankCard = await _context.BankCards.FindAsync(id);
            _context.BankCards.Remove(bankCard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BankCardExists(int id)
        {
            return _context.BankCards.Any(e => e.ID == id);
        }
    }
}
