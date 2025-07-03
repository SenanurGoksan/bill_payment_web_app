using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BillApp2.Data;
using BillApp2.Models;

namespace BillApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OdemeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OdemeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Odeme
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Odeme>>> GetOdenmisFatura()
        {
          if (_context.OdenmisFatura == null)
          {
              return NotFound();
          }
            return await _context.OdenmisFatura.ToListAsync();
        }

        // GET: api/Odeme/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Odeme>> GetOdeme(int id)
        {
          if (_context.OdenmisFatura == null)
          {
              return NotFound();
          }
            var odeme = await _context.OdenmisFatura.FindAsync(id);

            if (odeme == null)
            {
                return NotFound();
            }

            return odeme;
        }

        // PUT: api/Odeme/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOdeme(int id, Odeme odeme)
        {
            if (id != odeme.odemeId)
            {
                return BadRequest();
            }

            _context.Entry(odeme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OdemeExists(id))
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

        // POST: api/Odeme
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Odeme>> PostOdeme(Odeme odeme)
        {
          if (_context.OdenmisFatura == null)
          {
              return Problem("Entity set 'ApplicationDbContext.OdenmisFatura'  is null.");
          }
            _context.OdenmisFatura.Add(odeme);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOdeme", new { id = odeme.odemeId }, odeme);
        }

        // DELETE: api/Odeme/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOdeme(int id)
        {
            if (_context.OdenmisFatura == null)
            {
                return NotFound();
            }
            var odeme = await _context.OdenmisFatura.FindAsync(id);
            if (odeme == null)
            {
                return NotFound();
            }

            _context.OdenmisFatura.Remove(odeme);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OdemeExists(int id)
        {
            return (_context.OdenmisFatura?.Any(e => e.odemeId == id)).GetValueOrDefault();
        }
    }
}
