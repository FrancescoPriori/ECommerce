using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Priori.francesco._5h.ECommerce.Models;

namespace Priori.francesco._5h.ECommerce.Controllers
{
    public class ComponentiController : Controller
    {
        private readonly dbContext _context;

        public ComponentiController(dbContext context)
        {
            _context = context;
        }

        // GET: Componenti
        public async Task<IActionResult> Index()
        {
            return View(await _context.Componenti.ToListAsync());
        }

        // GET: Componenti/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componenti = await _context.Componenti
                .FirstOrDefaultAsync(m => m.Id == id);
            if (componenti == null)
            {
                return NotFound();
            }

            return View(componenti);
        }

        // GET: Componenti/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Componenti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Componenti componenti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(componenti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(componenti);
        }

        // GET: Componenti/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componenti = await _context.Componenti.FindAsync(id);
            if (componenti == null)
            {
                return NotFound();
            }
            return View(componenti);
        }

        // POST: Componenti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Componenti componenti)
        {
            if (id != componenti.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(componenti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComponentiExists(componenti.Id))
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
            return View(componenti);
        }

        // GET: Componenti/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componenti = await _context.Componenti
                .FirstOrDefaultAsync(m => m.Id == id);
            if (componenti == null)
            {
                return NotFound();
            }

            return View(componenti);
        }

        // POST: Componenti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var componenti = await _context.Componenti.FindAsync(id);
            if (componenti != null)
            {
                _context.Componenti.Remove(componenti);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComponentiExists(int id)
        {
            return _context.Componenti.Any(e => e.Id == id);
        }
    }
}
