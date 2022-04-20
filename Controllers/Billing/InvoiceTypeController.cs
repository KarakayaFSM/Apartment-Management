using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Apartment_Management.Data;
using Apartment_Management.Models;

namespace Apartment_Management.Controllers.Billing
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceTypeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InvoiceTypeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceType>>> GetBillTypes()
        {
            return await _context.BillTypes.ToListAsync();
        }

        // GET: api/InvoiceType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceType>> GetInvoiceType(int id)
        {
            var invoiceType = await _context.BillTypes.FindAsync(id);

            if (invoiceType == null)
            {
                return NotFound();
            }

            return invoiceType;
        }

        // PUT: api/InvoiceType/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceType(int id, InvoiceType invoiceType)
        {
            if (id != invoiceType.ID)
            {
                return BadRequest();
            }

            _context.Entry(invoiceType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/InvoiceType
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InvoiceType>> PostInvoiceType(InvoiceType invoiceType)
        {
            _context.BillTypes.Add(invoiceType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoiceType", new { id = invoiceType.ID }, invoiceType);
        }

        // DELETE: api/InvoiceType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InvoiceType>> DeleteInvoiceType(int id)
        {
            var invoiceType = await _context.BillTypes.FindAsync(id);
            if (invoiceType == null)
            {
                return NotFound();
            }

            _context.BillTypes.Remove(invoiceType);
            await _context.SaveChangesAsync();

            return invoiceType;
        }

        private bool InvoiceTypeExists(int id)
        {
            return _context.BillTypes.Any(e => e.ID == id);
        }
    }
}
