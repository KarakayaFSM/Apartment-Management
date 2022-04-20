using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Apartment_Management.Data;
using Apartment_Management.Models;

namespace Apartment_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillTypeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BillTypeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/BillType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillType>>> GetBillTypes()
        {
            return await _context.BillTypes.ToListAsync();
        }

        // GET: api/BillType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillType>> GetBillType(int id)
        {
            var billType = await _context.BillTypes.FindAsync(id);

            if (billType == null)
            {
                return NotFound();
            }

            return billType;
        }

        // PUT: api/BillType/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBillType(int id, BillType billType)
        {
            if (id != billType.ID)
            {
                return BadRequest();
            }

            _context.Entry(billType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillTypeExists(id))
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

        // POST: api/BillType
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BillType>> PostBillType(BillType billType)
        {
            _context.BillTypes.Add(billType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBillType", new { id = billType.ID }, billType);
        }

        // DELETE: api/BillType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BillType>> DeleteBillType(int id)
        {
            var billType = await _context.BillTypes.FindAsync(id);
            if (billType == null)
            {
                return NotFound();
            }

            _context.BillTypes.Remove(billType);
            await _context.SaveChangesAsync();

            return billType;
        }

        private bool BillTypeExists(int id)
        {
            return _context.BillTypes.Any(e => e.ID == id);
        }
    }
}
