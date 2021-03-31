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
    public class SeriesController : Controller
    {
        private readonly Contexto _context;

        public SeriesController(Contexto context)
        {
            _context = context;
        }

        // GET: Series
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Series.Include(s => s.Diretor).Include(s => s.Genero);
            return View(await contexto.ToListAsync());
        }

        // GET: Series/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var series = await _context.Series
                .Include(s => s.Diretor)
                .Include(s => s.Genero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (series == null)
            {
                return NotFound();
            }

            return View(series);
        }

        // GET: Series/Create
        public IActionResult Create()
        {
            ViewData["DiretorId"] = new SelectList(_context.Diretor, "Id", "NomeDiretor");
            ViewData["GeneroId"] = new SelectList(_context.Genero, "Id", "NomeGenero");
            return View();
        }

        // POST: Series/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiretorId,GeneroId,Titulo,Cartaz,Descricao,Ativo,Id")] Series series)
        {
            if (ModelState.IsValid)
            {
                series.Id = Guid.NewGuid();
                _context.Add(series);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiretorId"] = new SelectList(_context.Diretor, "Id", "NomeDiretor", series.DiretorId);
            ViewData["GeneroId"] = new SelectList(_context.Genero, "Id", "NomeGenero", series.GeneroId);
            return View(series);
        }

        // GET: Series/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var series = await _context.Series.FindAsync(id);
            if (series == null)
            {
                return NotFound();
            }
            ViewData["DiretorId"] = new SelectList(_context.Diretor, "Id", "NomeDiretor", series.DiretorId);
            ViewData["GeneroId"] = new SelectList(_context.Genero, "Id", "NomeGenero", series.GeneroId);
            return View(series);
        }

        // POST: Series/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DiretorId,GeneroId,Titulo,Cartaz,Descricao,Ativo,Id")] Series series)
        {
            if (id != series.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(series);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeriesExists(series.Id))
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
            ViewData["DiretorId"] = new SelectList(_context.Diretor, "Id", "NomeDiretor", series.DiretorId);
            ViewData["GeneroId"] = new SelectList(_context.Genero, "Id", "NomeGenero", series.GeneroId);
            return View(series);
        }

        // GET: Series/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var series = await _context.Series
                .Include(s => s.Diretor)
                .Include(s => s.Genero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (series == null)
            {
                return NotFound();
            }

            return View(series);
        }

        // POST: Series/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var series = await _context.Series.FindAsync(id);
            _context.Series.Remove(series);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeriesExists(Guid id)
        {
            return _context.Series.Any(e => e.Id == id);
        }
    }
}
