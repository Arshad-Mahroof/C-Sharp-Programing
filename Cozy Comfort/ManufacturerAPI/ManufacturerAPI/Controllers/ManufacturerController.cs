using ManufacturerAPI.Data;
using ManufacturerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManufacturerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManufacturerController : ControllerBase
    {
        private readonly ManufacturerContext _context;

        public ManufacturerController(ManufacturerContext context)
        {
            _context = context;
        }

        // GET: api/manufacturer/blankets
        [HttpGet("blankets")]
        public async Task<ActionResult<IEnumerable<Blanket>>> GetBlankets()
        {
            return await _context.Blankets.ToListAsync();
        }

        // GET: api/manufacturer/blankets/{id}
        [HttpGet("blankets/{id}")]
        public async Task<ActionResult<Blanket>> GetBlanket(int id)
        {
            var blanket = await _context.Blankets.FindAsync(id);
            if (blanket == null)
            {
                return NotFound();
            }
            return blanket;
        }

        // POST: api/manufacturer/add
        [HttpPost("add")]
        public async Task<ActionResult<Blanket>> AddBlanket(Blanket blanket)
        {
            _context.Blankets.Add(blanket);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBlanket), new { id = blanket.Id }, blanket);
        }

        // PUT: api/manufacturer/update/{id}
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateBlanket(int id, Blanket updatedBlanket)
        {
            if (id != updatedBlanket.Id)
            {
                return BadRequest("ID mismatch.");
            }

            _context.Entry(updatedBlanket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Blankets.Any(b => b.Id == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/manufacturer/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteBlanket(int id)
        {
            var blanket = await _context.Blankets.FindAsync(id);
            if (blanket == null)
            {
                return NotFound();
            }

            _context.Blankets.Remove(blanket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/manufacturer/produce
        [HttpPost("produce")]
        public async Task<IActionResult> Produce(ProductionRequest request)
        {
            var blanket = await _context.Blankets.FindAsync(request.BlanketId);
            if (blanket == null)
                return NotFound("Blanket not found.");

            if (request.Quantity > blanket.ProductionCapacity)
                return BadRequest("Requested quantity exceeds production capacity.");

            blanket.StockQuantity += request.Quantity;
            await _context.SaveChangesAsync();

            return Ok("Production updated.");
        }
    }
}
