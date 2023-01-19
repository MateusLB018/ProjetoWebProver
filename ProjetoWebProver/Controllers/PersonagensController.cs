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
    public class PersonagensController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonagensController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Personagens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Personagems.ToListAsync());
        }

        // GET: Personagens/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personagem = await _context.Personagems
                .FirstOrDefaultAsync(m => m.ID == id);
            if (personagem == null)
            {
                return NotFound();
            }

            return View(personagem);
        }

        // GET: Personagens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personagens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Personagem personagem)
        {
            if (ModelState.IsValid)
            {
               
                _context.Add(personagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personagem);
        }

        // GET: Personagens/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personagem = await _context.Personagems.FindAsync(id);
            if (personagem == null)
            {
                return NotFound();
            }
            return View(personagem);
        }

        // POST: Personagens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,Personagem personagem)
        {
            if (id != personagem.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonagemExists(personagem.ID))
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
            return View(personagem);
        }

        // GET: Personagens/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personagem = await _context.Personagems
                .FirstOrDefaultAsync(m => m.ID == id);
            if (personagem == null)
            {
                return NotFound();
            }

            return View(personagem);
        }

        // POST: Personagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var personagem = await _context.Personagems.FindAsync(id);
            _context.Personagems.Remove(personagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonagemExists(Guid id)
        {
            return _context.Personagems.Any(e => e.ID == id);
        }
    }
}
