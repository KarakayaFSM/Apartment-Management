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
    public class FlatController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FlatController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Flat
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flat>>> GetFlats()
        {
            return await _context.Flats.ToListAsync();
        }

        // GET: api/Flat/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Flat>> GetFlat(int id)
        {
            var flat = await _context.Flats.FindAsync(id);

            if (flat == null)
            {
                return NotFound();
            }

            return flat;
        }

        // PUT: api/Flat/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlat(int id, Flat flat)
        {
            if (id != flat.ID)
            {
                return BadRequest();
            }

            _context.Entry(flat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlatExists(id))
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

        // POST: api/Flat
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Flat>> PostFlat(Flat flat)
        {
            _context.Flats.Add(flat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlat", new { id = flat.ID }, flat);
        }

        // DELETE: api/Flat/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Flat>> DeleteFlat(int id)
        {
            var flat = await _context.Flats.FindAsync(id);
            if (flat == null)
            {
                return NotFound();
            }

            _context.Flats.Remove(flat);
            await _context.SaveChangesAsync();

            return flat;
        }

        private bool FlatExists(int id)
        {
            return _context.Flats.Any(e => e.ID == id);
        }
    }
}
