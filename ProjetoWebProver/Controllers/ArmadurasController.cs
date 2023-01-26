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
    public class ArmadurasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArmadurasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Armaduras
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Armaduras.Include(a => a.Personagem);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Armaduras/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armadura = await _context.Armaduras
                .Include(a => a.Personagem)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (armadura == null)
            {
                return NotFound();
            }

            return View(armadura);
        }

        // GET: Armaduras/Create
        public IActionResult Create()
        {
            ViewData["PersonagemId"] = new SelectList(_context.Personagems, "ID", "ItemIni");
            return View();
        }

        // POST: Armaduras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonagemId,Qual,DanoAbs,Peso,ID")] Armadura armadura)
        {
            if (ModelState.IsValid)
            {
                armadura.ID = Guid.NewGuid();
                _context.Add(armadura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonagemId"] = new SelectList(_context.Personagems, "ID", "ItemIni", armadura.PersonagemId);
            return View(armadura);
        }

        // GET: Armaduras/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armadura = await _context.Armaduras.FindAsync(id);
            if (armadura == null)
            {
                return NotFound();
            }
            ViewData["PersonagemId"] = new SelectList(_context.Personagems, "ID", "ItemIni", armadura.PersonagemId);
            return View(armadura);
        }

        // POST: Armaduras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PersonagemId,Qual,DanoAbs,Peso,ID")] Armadura armadura)
        {
            if (id != armadura.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(armadura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArmaduraExists(armadura.ID))
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
            ViewData["PersonagemId"] = new SelectList(_context.Personagems, "ID", "ItemIni", armadura.PersonagemId);
            return View(armadura);
        }

        // GET: Armaduras/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armadura = await _context.Armaduras
                .Include(a => a.Personagem)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (armadura == null)
            {
                return NotFound();
            }

            return View(armadura);
        }

        // POST: Armaduras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var armadura = await _context.Armaduras.FindAsync(id);
            _context.Armaduras.Remove(armadura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArmaduraExists(Guid id)
        {
            return _context.Armaduras.Any(e => e.ID == id);
        }
    }
}
