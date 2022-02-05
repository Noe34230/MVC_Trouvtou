using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trouvtou.Models;

namespace Trouvtou.Controllers
{
    public class RangementController : Controller
    {
        private readonly TrouvtouContext _context;

        public RangementController(TrouvtouContext context)
        {
            _context = context;
        }

        // GET: Rangement
        public async Task<IActionResult> Index(string searchString)
        {
            var rangement = from o in _context.Rangement
                 select o;
            rangement = _context.Rangement
                .Include(i => i.listObjet)
                .AsNoTracking();

            if (!string.IsNullOrEmpty(searchString))
            {
                rangement = rangement.Where(s => s.description.Contains(searchString));
            }
            return View(await rangement.ToListAsync());
        }

        // GET: Rangement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rangement = await _context.Rangement
                .Include(i =>i.listObjet)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.id == id);
            if (rangement == null)
            {
                return NotFound();
            }

            return View(rangement);
        }

        // GET: Rangement/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rangement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,description,couleur,descriptionDetail")] Rangement rangement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rangement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rangement);
        }

        // GET: Rangement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rangement = await _context.Rangement
                .Include(i =>i.listObjet)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.id == id);  
            if (rangement == null)
            {
                return NotFound();
            }
            //////////////////////////// Il faut rajouter un truc
            return View(rangement);
        }

        // POST: Rangement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,description,couleur,descriptionDetail")] Rangement rangement)
        {
            if (id != rangement.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rangement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RangementExists(rangement.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(rangement);
        }

        // GET: Rangement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rangement = await _context.Rangement
                .FirstOrDefaultAsync(m => m.id == id);
            if (rangement == null)
            {
                return NotFound();
            }

            if(rangement.listObjet != null)
            {
                return NotFound();
            }

            return View(rangement);
        }

        // POST: Rangement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rangement = await _context.Rangement.FindAsync(id);
            

            
            // for (int i=0;i<rangement.listObjet.Count;i++)
            // {
            //     rangement.listObjet.ElementAt<Objet>(i).rangementid = null;
            // }
            _context.Rangement.Remove(rangement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RangementExists(int id)
        {
            return _context.Rangement.Any(e => e.id == id);
        }
    }
}
