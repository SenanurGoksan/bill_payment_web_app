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
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BillApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KurumsalController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KurumsalController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Kurumsal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kurumsal>>> GetKurumsal()
        {
          if (_context.Kurumsal == null)
          {
              return NotFound();
          }
            return await _context.Kurumsal.ToListAsync();
        }

        // GET: api/Kurumsal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kurumsal>> GetKurumsal(int id)
        {
          if (_context.Kurumsal == null)
          {
              return NotFound();
          }
            var kurumsal = await _context.Kurumsal.FindAsync(id);

            if (kurumsal == null)
            {
                return NotFound();
            }

            return kurumsal;
        }

        // PUT: api/Kurumsal/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKurumsal(int id, Kurumsal kurumsal)
        {
            if (id != kurumsal.kurumId)
            {
                return BadRequest();
            }

            _context.Entry(kurumsal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KurumsalExists(id))
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

        // POST: api/Kurumsal
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
         [HttpPost]
         public async Task<ActionResult<Kurumsal>> PostKurumsal(Kurumsal kurumsal)
         {
           if (_context.Kurumsal == null)
           {
               return Problem("Entity set 'ApplicationDbContext.Kurumsal'  is null.");
           }
            // E-posta adresini kontrol et
            if (await CheckEmailExistAsync(kurumsal.adminMail))
                return BadRequest(new { Message = "Bu email önceden kayıt edilmiş, yeniden deneyin!" });

            kurumsal.Role = "Admin";
            kurumsal.Token = "";

            
             await _context.Kurumsal.AddAsync(kurumsal);
             await _context.SaveChangesAsync();

            // return CreatedAtAction("GetKurumsal", new { id = kurumsal.kurumId }, kurumsal);
            return Ok(new
            {
                Message = "User Added!"
            });

        }

        private Task<bool> CheckEmailExistAsync(string? adminMail)
           => _context.Kurumsal.AnyAsync(x => x.adminMail == adminMail);


        [HttpPost("login")]
        public async Task<IActionResult> Login(KurumsalDto model)
        {
            try
            {
                // Kullanıcının kimlik bilgilerini veritabanında sorgula ve hangi kuruma ait olduğunu bul
                var kurumsal = await _context.Kurumsal.FirstOrDefaultAsync(k => k.adminMail == model.adminMail && k.password == model.password);

                if (kurumsal != null)
                {
                    kurumsal.Token = CreateJwt(kurumsal);

                    return Ok(new
                    {
                        Token = kurumsal.Token,
                        Role = kurumsal.Role,
                        Message = "Login Success!"
                    });
                    // Başarılı giriş durumu
                }
                else
                {
                    // Hatalı giriş durumu
                    return BadRequest(new { Message = "Hatalı giriş." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Sunucu hatası: " + ex.Message });
            }
        }


        // DELETE: api/Kurumsal/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKurumsal(int id)
        {
            if (_context.Kurumsal == null)
            {
                return NotFound();
            }
            var kurumsal = await _context.Kurumsal.FindAsync(id);
            if (kurumsal == null)
            {
                return NotFound();
            }

            _context.Kurumsal.Remove(kurumsal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KurumsalExists(int id)
        {
            return (_context.Kurumsal?.Any(e => e.kurumId == id)).GetValueOrDefault();
        }

        private string CreateJwt(Kurumsal kurumsal)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryverysecret....."); //our secret key
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role, kurumsal.Role),
                new Claim(ClaimTypes.Name,$"{kurumsal.kurumAdi}")
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256); //token'ı oluştururken kullandığımız algoritmanın ismi

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddSeconds(10),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor); //token'ı oluşturuyoruz
            return jwtTokenHandler.WriteToken(token);
        }

    }
}
