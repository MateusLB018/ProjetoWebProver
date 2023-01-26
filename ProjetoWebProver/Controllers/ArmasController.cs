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
    public class ArmasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArmasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Armas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Armas.Include(a => a.Personagem);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Armas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arma = await _context.Armas
                .Include(a => a.Personagem)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (arma == null)
            {
                return NotFound();
            }

            return View(arma);
        }

        // GET: Armas/Create
        public IActionResult Create()
        {
            ViewData["PersonagemId"] = new SelectList(_context.Personagems, "ID", "ItemIni");
            return View();
        }

        // POST: Armas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonagemId,Dano,Peso,Qual,ID")] Arma arma)
        {
            if (ModelState.IsValid)
            {
                arma.ID = Guid.NewGuid();
                _context.Add(arma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonagemId"] = new SelectList(_context.Personagems, "ID", "ItemIni", arma.PersonagemId);
            return View(arma);
        }

        // GET: Armas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arma = await _context.Armas.FindAsync(id);
            if (arma == null)
            {
                return NotFound();
            }
            ViewData["PersonagemId"] = new SelectList(_context.Personagems, "ID", "ItemIni", arma.PersonagemId);
            return View(arma);
        }

        // POST: Armas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PersonagemId,Dano,Peso,Qual,ID")] Arma arma)
        {
            if (id != arma.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArmaExists(arma.ID))
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
            ViewData["PersonagemId"] = new SelectList(_context.Personagems, "ID", "ItemIni", arma.PersonagemId);
            return View(arma);
        }

        // GET: Armas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arma = await _context.Armas
                .Include(a => a.Personagem)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (arma == null)
            {
                return NotFound();
            }

            return View(arma);
        }

        // POST: Armas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var arma = await _context.Armas.FindAsync(id);
            _context.Armas.Remove(arma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArmaExists(Guid id)
        {
            return _context.Armas.Any(e => e.ID == id);
        }
    }
}
