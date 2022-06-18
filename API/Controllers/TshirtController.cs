using API.Contexts;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TshirtController : ControllerBase
    {
        private readonly TshirtDbContext _context;
        public TshirtController(TshirtDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TShirt>>> GetTshirt()
        {
            return await _context.Tshirts.Include(x => x.Color)
                .Include(y => y.Size).ToListAsync();
        }


        [HttpGet("id")]
        public async Task<ActionResult<TShirt>> GetTshirt(int id)
        {
            var shirt = await _context.Tshirts
                .Include(x => x.Color)
                .Include(y => y.Size)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (shirt == null)
            {
                return NotFound();
            }

            return shirt;
        }

        [HttpPost]
        public async Task<ActionResult<TShirt>> InsertTShirt(TShirt shirt)
        {

            _context.Tshirts.Add(shirt);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTshirt), new { id = shirt.Id }, shirt);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTShirt(int id)
        {
            var tshirt = await _context.Tshirts.FindAsync(id);

            if(tshirt == null)
            {
               return NotFound();
            }

            _context.Tshirts.Remove(tshirt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, TShirt shirt)
        {
            if (id != shirt.Id)
            {
                return BadRequest();
            }

            _context.Entry(shirt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        private bool ProductExists(int id)
        {
            return _context.Tshirts.Any(x => x.Id == id);
        }
    }
}