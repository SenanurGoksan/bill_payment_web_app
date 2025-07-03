using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BillApp2.Data;
using BillApp2.Models;
using BillApp2.DTOs;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace BillApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaturaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FaturaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Fatura
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fatura>>> GetFatura()
        {
            if (_context.Fatura == null)
            {
                return NotFound();
            }
            return await _context.Fatura.ToListAsync();
        }
        [HttpGet("deneme")]
        public async Task<ActionResult<FaturaDto>> GetFaturaAl([FromQuery] int faturaNo)
        {
            var fatura = await _context.Fatura.SingleOrDefaultAsync(f => f.faturaNo == faturaNo);
            var kullanici = await _context.Bireysel.SingleOrDefaultAsync(u => u.idNum == fatura.userId);
            var kurum= await _context.Kurumsal.SingleOrDefaultAsync(x => x.kurumId== fatura.kurumId);

           
            if (fatura == null)
            {
                return NotFound();
            }

            return Ok(new FaturaDto
            {
                tutar = fatura.tutar,
                userId = fatura.userId,
                kurumId = fatura.kurumId,
                firstName=kullanici.firstName,
                lastName=kullanici.lastName,
                kurumAdi=kurum.kurumAdi
            });
        }


        // PUT: api/Fatura/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut()]
        public async Task<IActionResult> PutFatura(int faturaNo, Fatura fatura)
        {
            if (faturaNo != fatura.faturaNo)
            {
                return BadRequest();
            }

            _context.Entry(fatura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FaturaExists(faturaNo))
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

        // POST: api/Fatura
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPost("create")]
        public async Task<IActionResult> CreateFatura(FaturaDto model)

        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var faturaEntity = new Fatura
                {
                    tutar = model.tutar,
                    userId = model.userId,
                    kurumId = model.kurumId

                };

                _context.Fatura.Add(faturaEntity);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Fatura başarıyla oluşturuldu." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Sunucu hatası: " + ex.Message });
            }
        }



// DELETE: api/Fatura/5
[HttpDelete()]
        public async Task<IActionResult> DeleteFatura(int faturaNo)
        {
            if (_context.Fatura == null)
            {
                return NotFound();
            }
            var fatura = await _context.Fatura.FindAsync(faturaNo);
            if (fatura == null)
            {
                return NotFound();
            }

            _context.Fatura.Remove(fatura);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Fatura başarıyla silindi." });

        }

        private bool FaturaExists(int id)
        {
            return (_context.Fatura?.Any(e => e.faturaNo == id)).GetValueOrDefault();
        }
    }
}
