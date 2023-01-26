using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoWebProver.Data;
using ProjetoWebProver.Models;

namespace ProjetoWebProver.Controllers
{
    public class PoderesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PoderesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Poderes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Poderes.Include(p => p.Personagem);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Poderes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poder = await _context.Poderes
                .Include(p => p.Personagem)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (poder == null)
            {
                return NotFound();
            }

            return View(poder);
        }

        // GET: Poderes/Create
        public IActionResult Create()
        {
            ViewData["PersonagemId"] = new SelectList(_context.Personagems, "ID", "ItemIni");
            return View();
        }

        // POST: Poderes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonagemId,Pod,ID")] Poder poder)
        {
            if (ModelState.IsValid)
            {
                poder.ID = Guid.NewGuid();
                _context.Add(poder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonagemId"] = new SelectList(_context.Personagems, "ID", "ItemIni", poder.PersonagemId);
            return View(poder);
        }

        // GET: Poderes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poder = await _context.Poderes.FindAsync(id);
            if (poder == null)
            {
                return NotFound();
            }
            ViewData["PersonagemId"] = new SelectList(_context.Personagems, "ID", "ItemIni", poder.PersonagemId);
            return View(poder);
        }

        // POST: Poderes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PersonagemId,Pod,ID")] Poder poder)
        {
            if (id != poder.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoderExists(poder.ID))
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
            ViewData["PersonagemId"] = new SelectList(_context.Personagems, "ID", "ItemIni", poder.PersonagemId);
            return View(poder);
        }

        // GET: Poderes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poder = await _context.Poderes
                .Include(p => p.Personagem)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (poder == null)
            {
                return NotFound();
            }

            return View(poder);
        }

        // POST: Poderes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var poder = await _context.Poderes.FindAsync(id);
            _context.Poderes.Remove(poder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoderExists(Guid id)
        {
            return _context.Poderes.Any(e => e.ID == id);
        }
    }
}
