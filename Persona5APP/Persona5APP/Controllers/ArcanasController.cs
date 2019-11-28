using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Persona5APP.Models;
using Persona5APP.ViewModels;

namespace Persona5APP.Controllers
{
    public class ArcanasController : Controller
    {
        private readonly DBContext _context;

        public ArcanasController(DBContext context)
        {
            _context = context;
        }

        // GET: Arcanas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Arcanas.ToListAsync());
        }

        // GET: Arcanas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arcana = await _context.Arcanas
                .FirstOrDefaultAsync(m => m.arcanaID == id);
            if (arcana == null)
            {
                return NotFound();
            }
            ArcanaPersonaViewModel arcanapersona = new ArcanaPersonaViewModel()
            {
                Arcana = arcana,
                Personas = _context.Personas.Where(c => c.arcanaID == id)
            };
            return View(arcanapersona);
        }

        // GET: Arcanas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Arcanas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("arcanaID,Arcananame")] Arcana arcana)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arcana);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(arcana);
        }

        // GET: Arcanas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arcana = await _context.Arcanas.FindAsync(id);
            if (arcana == null)
            {
                return NotFound();
            }
            return View(arcana);
        }

        // POST: Arcanas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Arcana arcana)
        {
            if (id != arcana.arcanaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arcana);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArcanaExists(arcana.arcanaID))
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
            return View(arcana);
        }

        // GET: Arcanas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arcana = await _context.Arcanas
                .FirstOrDefaultAsync(m => m.arcanaID == id);
            if (arcana == null)
            {
                return NotFound();
            }

            return View(arcana);
        }

        // POST: Arcanas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arcana = await _context.Arcanas.FindAsync(id);
            _context.Arcanas.Remove(arcana);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArcanaExists(int id)
        {
            return _context.Arcanas.Any(e => e.arcanaID == id);
        }
    }
}
