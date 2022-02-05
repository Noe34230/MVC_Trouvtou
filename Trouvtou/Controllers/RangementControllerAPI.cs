using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trouvtou.Models;

namespace Trouvtou.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RangementControllerAPI : ControllerBase
    {
        private readonly TrouvtouContext _context;

        public RangementControllerAPI(TrouvtouContext context)
        {
            _context = context;
        }

        // GET: api/RangementControllerAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rangement>>> GetRangement()
        {
            return await _context.Rangement.ToListAsync();
        }

        // GET: api/RangementControllerAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rangement>> GetRangement(int id)
        {
            var rangement = await _context.Rangement.FindAsync(id);

            if (rangement == null)
            {
                return NotFound();
            }

            return rangement;
        }

        // PUT: api/RangementControllerAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRangement(int id, Rangement rangement)
        {
            if (id != rangement.id)
            {
                return BadRequest();
            }

            _context.Entry(rangement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RangementExists(id))
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

        // POST: api/RangementControllerAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rangement>> PostRangement(Rangement rangement)
        {
            _context.Rangement.Add(rangement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRangement", new { id = rangement.id }, rangement);
        }

        // DELETE: api/RangementControllerAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRangement(int id)
        {
            var rangement = await _context.Rangement.FindAsync(id);
            if (rangement == null)
            {
                return NotFound();
            }

            _context.Rangement.Remove(rangement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RangementExists(int id)
        {
            return _context.Rangement.Any(e => e.id == id);
        }
    }
}
