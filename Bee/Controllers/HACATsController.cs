using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bee.Data;
using Bee.Models;

namespace Bee.Controllers
{
    public class HACATsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HACATsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HACATs
        public async Task<IActionResult> Index()
        {
            return View(await _context.HACAT.ToListAsync());
        }

        // GET: HACATs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hACAT = await _context.HACAT
                .FirstOrDefaultAsync(m => m.HACATId == id);
            if (hACAT == null)
            {
                return NotFound();
            }

            return View(hACAT);
        }

        // GET: HACATs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HACATs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HACATId,Code,Desc")] HACAT hACAT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hACAT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hACAT);
        }

        // GET: HACATs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hACAT = await _context.HACAT.FindAsync(id);
            if (hACAT == null)
            {
                return NotFound();
            }
            return View(hACAT);
        }

        // POST: HACATs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HACATId,Code,Desc")] HACAT hACAT)
        {
            if (id != hACAT.HACATId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hACAT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HACATExists(hACAT.HACATId))
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
            return View(hACAT);
        }

        // GET: HACATs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hACAT = await _context.HACAT
                .FirstOrDefaultAsync(m => m.HACATId == id);
            if (hACAT == null)
            {
                return NotFound();
            }

            return View(hACAT);
        }

        // POST: HACATs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hACAT = await _context.HACAT.FindAsync(id);
            if (hACAT != null)
            {
                _context.HACAT.Remove(hACAT);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HACATExists(int id)
        {
            return _context.HACAT.Any(e => e.HACATId == id);
        }
    }
}
