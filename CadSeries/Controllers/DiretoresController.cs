using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadSeries.Dados;
using CadSeries.Models;

namespace CadSeries.Controllers
{
    public class DiretoresController : Controller
    {
        private readonly Contexto _context;

        public DiretoresController(Contexto context)
        {
            _context = context;
        }

        // GET: Diretores
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Diretor.Include(d => d.Tv);
            return View(await contexto.ToListAsync());
        }

        // GET: Diretores/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diretor = await _context.Diretor
                .Include(d => d.Tv)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diretor == null)
            {
                return NotFound();
            }

            return View(diretor);
        }

        // GET: Diretores/Create
        public IActionResult Create()
        {
            ViewData["TVId"] = new SelectList(_context.TVs, "Id", "NomeTv");
            return View();
        }

        // POST: Diretores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TVId,NomeDiretor,Biografia,Ativo,Id")] Diretor diretor)
        {
            if (ModelState.IsValid)
            {
                diretor.Id = Guid.NewGuid();
                _context.Add(diretor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TVId"] = new SelectList(_context.TVs, "Id", "NomeTv", diretor.TVId);
            return View(diretor);
        }

        // GET: Diretores/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diretor = await _context.Diretor.FindAsync(id);
            if (diretor == null)
            {
                return NotFound();
            }
            ViewData["TVId"] = new SelectList(_context.TVs, "Id", "NomeTv", diretor.TVId);
            return View(diretor);
        }

        // POST: Diretores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TVId,NomeDiretor,Biografia,Ativo,Id")] Diretor diretor)
        {
            if (id != diretor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diretor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiretorExists(diretor.Id))
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
            ViewData["TVId"] = new SelectList(_context.TVs, "Id", "NomeTv", diretor.TVId);
            return View(diretor);
        }

        // GET: Diretores/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diretor = await _context.Diretor
                .Include(d => d.Tv)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diretor == null)
            {
                return NotFound();
            }

            return View(diretor);
        }

        // POST: Diretores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var diretor = await _context.Diretor.FindAsync(id);
            _context.Diretor.Remove(diretor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiretorExists(Guid id)
        {
            return _context.Diretor.Any(e => e.Id == id);
        }
    }
}
