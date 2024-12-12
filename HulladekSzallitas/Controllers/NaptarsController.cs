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
    public class NaptarsController : Controller
    {
        private readonly HulladekSzallitasContext _context;

        public NaptarsController(HulladekSzallitasContext context)
        {
            _context = context;
        }

        // GET: Naptars
        public async Task<IActionResult> Index()
        {
            var hulladekSzallitasContext = _context.Naptar.Include(n => n.Szolgaltatas);
            return View(await hulladekSzallitasContext.ToListAsync());
        }

        // GET: Naptars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naptar = await _context.Naptar
                .Include(n => n.Szolgaltatas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (naptar == null)
            {
                return NotFound();
            }

            return View(naptar);
        }

        // GET: Naptars/Create
        public IActionResult Create()
        {
            ViewData["SzolgaltatasId"] = new SelectList(_context.Szolgaltatas, "Id", "tipus");
            return View();
        }

        // POST: Naptars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,datum,SzolgaltatasId")] Naptar naptar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(naptar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SzolgaltatasId"] = new SelectList(_context.Szolgaltatas, "Id", "tipus", naptar.SzolgaltatasId);
            return View(naptar);
        }

        // GET: Naptars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naptar = await _context.Naptar.FindAsync(id);
            if (naptar == null)
            {
                return NotFound();
            }
            ViewData["SzolgaltatasId"] = new SelectList(_context.Szolgaltatas, "Id", "tipus", naptar.SzolgaltatasId);
            return View(naptar);
        }

        // POST: Naptars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,datum,SzolgaltatasId")] Naptar naptar)
        {
            if (id != naptar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(naptar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NaptarExists(naptar.Id))
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
            ViewData["SzolgaltatasId"] = new SelectList(_context.Szolgaltatas, "Id", "tipus", naptar.SzolgaltatasId);
            return View(naptar);
        }

        // GET: Naptars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naptar = await _context.Naptar
                .Include(n => n.Szolgaltatas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (naptar == null)
            {
                return NotFound();
            }

            return View(naptar);
        }

        // POST: Naptars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var naptar = await _context.Naptar.FindAsync(id);
            if (naptar != null)
            {
                _context.Naptar.Remove(naptar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NaptarExists(int id)
        {
            return _context.Naptar.Any(e => e.Id == id);
        }
    }
}
