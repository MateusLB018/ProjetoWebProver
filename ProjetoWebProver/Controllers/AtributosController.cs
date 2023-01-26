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
    public class AtributosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AtributosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Atributos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Atributos.Include(a => a.Personagem);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Atributos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atributo = await _context.Atributos
                .Include(a => a.Personagem)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (atributo == null)
            {
                return NotFound();
            }

            return View(atributo);
        }

        // GET: Atributos/Create
        public IActionResult Create()
        {
            ViewData["PersonagemId"] = new SelectList(_context.Personagems, "ID", "ItemIni");
            return View();
        }

        // POST: Atributos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonagemId,Inteligencia,Força,Fe,Vitalidade,Energia,Magia,Defesa,Vigor,ID")] Atributo atributo)
        {
            if (ModelState.IsValid)
            {
                atributo.ID = Guid.NewGuid();
                _context.Add(atributo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonagemId"] = new SelectList(_context.Personagems, "ID", "ItemIni", atributo.PersonagemId);
            return View(atributo);
        }

        // GET: Atributos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atributo = await _context.Atributos.FindAsync(id);
            if (atributo == null)
            {
                return NotFound();
            }
            ViewData["PersonagemId"] = new SelectList(_context.Personagems, "ID", "ItemIni", atributo.PersonagemId);
            return View(atributo);
        }

        // POST: Atributos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PersonagemId,Inteligencia,Força,Fe,Vitalidade,Energia,Magia,Defesa,Vigor,ID")] Atributo atributo)
        {
            if (id != atributo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atributo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtributoExists(atributo.ID))
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
            ViewData["PersonagemId"] = new SelectList(_context.Personagems, "ID", "ItemIni", atributo.PersonagemId);
            return View(atributo);
        }

        // GET: Atributos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atributo = await _context.Atributos
                .Include(a => a.Personagem)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (atributo == null)
            {
                return NotFound();
            }

            return View(atributo);
        }

        // POST: Atributos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var atributo = await _context.Atributos.FindAsync(id);
            _context.Atributos.Remove(atributo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtributoExists(Guid id)
        {
            return _context.Atributos.Any(e => e.ID == id);
        }
    }
}
