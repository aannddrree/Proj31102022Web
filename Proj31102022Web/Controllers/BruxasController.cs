using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proj31102022Web.Data;
using Proj31102022Web.Models;

namespace Proj31102022Web.Controllers
{
    public class BruxasController : Controller
    {
        private readonly Proj31102022WebContext _context;

        public BruxasController(Proj31102022WebContext context)
        {
            _context = context;
        }

        // GET: Bruxas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bruxa.ToListAsync());
        }

        // GET: Bruxas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bruxa = await _context.Bruxa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bruxa == null)
            {
                return NotFound();
            }

            return View(bruxa);
        }

        // GET: Bruxas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bruxas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Bruxa bruxa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bruxa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bruxa);
        }

        // GET: Bruxas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bruxa = await _context.Bruxa.FindAsync(id);
            if (bruxa == null)
            {
                return NotFound();
            }
            return View(bruxa);
        }

        // POST: Bruxas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Bruxa bruxa)
        {
            if (id != bruxa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bruxa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BruxaExists(bruxa.Id))
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
            return View(bruxa);
        }

        // GET: Bruxas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bruxa = await _context.Bruxa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bruxa == null)
            {
                return NotFound();
            }

            return View(bruxa);
        }

        // POST: Bruxas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bruxa = await _context.Bruxa.FindAsync(id);
            _context.Bruxa.Remove(bruxa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BruxaExists(int id)
        {
            return _context.Bruxa.Any(e => e.Id == id);
        }
    }
}
