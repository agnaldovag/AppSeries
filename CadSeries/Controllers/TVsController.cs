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
    public class TVsController : Controller
    {
        private readonly Contexto _context;

        public TVsController(Contexto context)
        {
            _context = context;
        }

        // GET: TVs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TVs.ToListAsync());
        }

        // GET: TVs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tV = await _context.TVs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tV == null)
            {
                return NotFound();
            }

            return View(tV);
        }

        // GET: TVs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TVs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomeTv,Ativo,Id")] TV tV)
        {
            if (ModelState.IsValid)
            {
                tV.Id = Guid.NewGuid();
                _context.Add(tV);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tV);
        }

        // GET: TVs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tV = await _context.TVs.FindAsync(id);
            if (tV == null)
            {
                return NotFound();
            }
            return View(tV);
        }

        // POST: TVs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("NomeTv,Ativo,Id")] TV tV)
        {
            if (id != tV.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tV);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TVExists(tV.Id))
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
            return View(tV);
        }

        // GET: TVs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tV = await _context.TVs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tV == null)
            {
                return NotFound();
            }

            return View(tV);
        }

        // POST: TVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tV = await _context.TVs.FindAsync(id);
            _context.TVs.Remove(tV);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TVExists(Guid id)
        {
            return _context.TVs.Any(e => e.Id == id);
        }
    }
}
