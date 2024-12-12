using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hulladékszállítás.Models;

namespace HulladekSzallitas.Controllers
{
    public class LakigsController : Controller
    {
        private readonly HulladekSzallitasContext _context;

        public LakigsController(HulladekSzallitasContext context)
        {
            _context = context;
        }

        // GET: Lakigs
        public async Task<IActionResult> Index()
        {
            var hulladekSzallitasContext = _context.Lakig.Include(l => l.Szolgaltatas);
            return View(await hulladekSzallitasContext.ToListAsync());
        }

        // GET: Lakigs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lakig = await _context.Lakig
                .Include(l => l.Szolgaltatas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lakig == null)
            {
                return NotFound();
            }

            return View(lakig);
        }

        // GET: Lakigs/Create
        public IActionResult Create()
        {
            ViewData["SzolgaltatasId"] = new SelectList(_context.Szolgaltatas, "Id", "tipus");
            return View();
        }

        // POST: Lakigs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,igeny,SzolgaltatasId,mennyiseg")] Lakig lakig)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lakig);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SzolgaltatasId"] = new SelectList(_context.Szolgaltatas, "Id", "tipus", lakig.SzolgaltatasId);
            return View(lakig);
        }

        // GET: Lakigs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lakig = await _context.Lakig.FindAsync(id);
            if (lakig == null)
            {
                return NotFound();
            }
            ViewData["SzolgaltatasId"] = new SelectList(_context.Szolgaltatas, "Id", "tipus", lakig.SzolgaltatasId);
            return View(lakig);
        }

        // POST: Lakigs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,igeny,SzolgaltatasId,mennyiseg")] Lakig lakig)
        {
            if (id != lakig.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lakig);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LakigExists(lakig.Id))
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
            ViewData["SzolgaltatasId"] = new SelectList(_context.Szolgaltatas, "Id", "tipus", lakig.SzolgaltatasId);
            return View(lakig);
        }

        // GET: Lakigs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lakig = await _context.Lakig
                .Include(l => l.Szolgaltatas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lakig == null)
            {
                return NotFound();
            }

            return View(lakig);
        }

        // POST: Lakigs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lakig = await _context.Lakig.FindAsync(id);
            if (lakig != null)
            {
                _context.Lakig.Remove(lakig);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LakigExists(int id)
        {
            return _context.Lakig.Any(e => e.Id == id);
        }
    }
}
