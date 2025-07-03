using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BillApp2.Data;
using BillApp2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Text;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using BillApp2.DTOs;

namespace BillApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BireyselController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BireyselController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Bireysel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bireysel>>> GetBireysel()
        {
          if (_context.Bireysel == null)
          {
              return NotFound();
          }
            return await _context.Bireysel.ToListAsync();
        }

        // GET: api/Bireysel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bireysel>> GetBireysel(int id)
        {
          if (_context.Bireysel == null)
          {
              return NotFound();
          }
            var bireysel = await _context.Bireysel.FindAsync(id);

            if (bireysel == null)
            {
                return NotFound();
            }

            return bireysel;
        }

        // PUT: api/Bireysel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBireysel(int id, Bireysel bireysel)
        {
            if (id != bireysel.idNum)
            {
                return BadRequest();
            }

            _context.Entry(bireysel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BireyselExists(id))
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

        // POST: api/Bireysel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*  [HttpPost]
          public async Task<ActionResult<Bireysel>> PostBireysel(Bireysel bireysel)
          {
            if (_context.Bireysel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Bireysel'  is null.");
            }
              _context.Bireysel.Add(bireysel);
              await _context.SaveChangesAsync();

              return CreatedAtAction("GetBireysel", new { id = bireysel.idNum }, bireysel);
          }
        */

        [HttpPost]
        public async Task<ActionResult<Bireysel>> PostBireysel(Bireysel bireysel)
        {
            if (bireysel == null)
            {
                return BadRequest();
            }

            // E-posta adresini kontrol et
            if (await CheckEmailExistAsync(bireysel.email))
                return BadRequest(new { Message = "Bu email önceden kayıt edilmiş, yeniden deneyin!" });

            bireysel.Role = "User";
            bireysel.Token = "";
           
            await _context.Bireysel.AddAsync(bireysel);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetBireysel", new { id = bireysel.idNum }, bireysel);
            return Ok(new
            {
                Message = "User Added!"
            });

        }
        private Task<bool> CheckEmailExistAsync(string? email)
            => _context.Bireysel.AnyAsync(x => x.email == email);

        [HttpPost("auth")]
        public async Task<IActionResult> Auth  (BireyselDto userObj)
        {
            if (userObj == null)
                return BadRequest();

            //if user already exists - return ı döndürecek
            var bireysel = await _context.Bireysel
                .FirstOrDefaultAsync(x => x.email == userObj.email && x.parola==userObj.parola);
  

            if (bireysel == null)
                return NotFound(new { Message = "User not found!" });

            bireysel.Token = CreateJwt(bireysel);

            return Ok(new
            {
                Role=bireysel.Role,
                Token = bireysel.Token,
                Message = "Login Success!"
            }) ;
                }
        

       
        // DELETE: api/Bireysel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBireysel(int id)
        {
            if (_context.Bireysel == null)
            {
                return NotFound();
            }
            var bireysel = await _context.Bireysel.FindAsync(id);
            if (bireysel == null)
            {
                return NotFound();
            }

            _context.Bireysel.Remove(bireysel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BireyselExists(int id)
        {
            return (_context.Bireysel?.Any(e => e.idNum == id)).GetValueOrDefault();
        }


        private string CreateJwt(Bireysel bireysel)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler(); 
            var key = Encoding.ASCII.GetBytes("veryverysecret....."); //our secret key
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role, bireysel.Role),
                new Claim(ClaimTypes.Name,$"{bireysel.firstName} {bireysel.lastName}")
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
