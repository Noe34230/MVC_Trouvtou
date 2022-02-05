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
    public class ObjetsController : Controller
    {
        private readonly TrouvtouContext _context;

        public ObjetsController(TrouvtouContext context)
        {
            _context = context;
        }

        // GET: Objets
        public async Task<IActionResult> Index(string searchString )
        {
            var objets = from o in _context.Objet
                 select o;

            objets = _context.Objet.Include(c => c.rangement);

            
            if (!string.IsNullOrEmpty(searchString))
            {
                objets = objets.Where(s => s.nom.Contains(searchString));
            }

            return View(await objets.ToListAsync());
        }

        // GET: Objets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objet = await _context.Objet
                .Include(c => c.rangement)
                .FirstOrDefaultAsync(m => m.id == id);
            if (objet == null)
            {
                return NotFound();
            }

            return View(objet);
        }

        // GET: Objets/Create
        public IActionResult Create()
        {
            ViewData["rangementId"]=new SelectList(_context.Rangement, "id","description");
            return View();
        }

        // POST: Objets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nom,description,typeObjet,estConsultable,dateDernierRangement,rangementid")] Objet objet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["rangementid"]=new SelectList(_context.Rangement, "id","description", objet.rangementid);
            return View(objet);
        }

        // GET: Objets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objet = await _context.Objet.FindAsync(id);
            if (objet == null)
            {
                return NotFound();
            }
            ViewData["rangementid"]=new SelectList(_context.Rangement, "id","description", objet.rangementid);
            return View(objet);
        }

        // POST: Objets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nom,description,typeObjet,estConsultable,dateDernierRangement")] Objet objet)
        {
            if (id != objet.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(objet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObjetExists(objet.id))
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
            ViewData["rangementid"]=new SelectList(_context.Rangement, "id","description", objet.rangementid);
            return View(objet);
        }

        // GET: Objets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objet = await _context.Objet
                .Include(c => c.rangement)
                .FirstOrDefaultAsync(m => m.id == id);
            if (objet == null)
            {
                return NotFound();
            }

            return View(objet);
        }

        // POST: Objets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var objet = await _context.Objet.FindAsync(id);
            _context.Objet.Remove(objet);
            //_context.Rangement.Remove(objet); /////////////////Faire gaffe ici erreur possible
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObjetExists(int id)
        {
            return _context.Objet.Any(e => e.id == id);
        }
    }
}
