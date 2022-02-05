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
    public class ObjetsControllerAPI : ControllerBase
    {
        private readonly TrouvtouContext _context;

        public ObjetsControllerAPI(TrouvtouContext context)
        {
            _context = context;
        }

        // GET: api/ObjetsControllerAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Objet>>> GetObjet()
        {
            return await _context.Objet.ToListAsync();
        }

        // GET: api/ObjetsControllerAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Objet>> GetObjet(int id)
        {
            var objet = await _context.Objet.FindAsync(id);

            if (objet == null)
            {
                return NotFound();
            }

            return objet;
        }

        // PUT: api/ObjetsControllerAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObjet(int id, Objet objet)
        {
            if (id != objet.id)
            {
                return BadRequest();
            }

            _context.Entry(objet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjetExists(id))
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

        // POST: api/ObjetsControllerAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Objet>> PostObjet(Objet objet)
        {
            _context.Objet.Add(objet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObjet", new { id = objet.id }, objet);
        }

        // DELETE: api/ObjetsControllerAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObjet(int id)
        {
            var objet = await _context.Objet.FindAsync(id);
            if (objet == null)
            {
                return NotFound();
            }

            _context.Objet.Remove(objet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ObjetExists(int id)
        {
            return _context.Objet.Any(e => e.id == id);
        }
    }
}
