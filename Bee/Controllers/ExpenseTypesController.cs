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
    public class ExpenseTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpenseTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExpenseTypes
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var eventType = from s in _context.ExpenseType
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                int searchId;
                bool isNumericSearch = int.TryParse(searchString, out searchId);

                eventType = eventType.Where(r => r.Name.Contains(searchString) || (isNumericSearch && r.ExpenseTypeId == searchId));
            }

            return View(await eventType.ToListAsync());
        }

        // GET: ExpenseTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseType = await _context.ExpenseType
                .FirstOrDefaultAsync(m => m.ExpenseTypeId == id);
            if (expenseType == null)
            {
                return NotFound();
            }

            return View(expenseType);
        }

        // GET: ExpenseTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExpenseTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExpenseTypeId,Name,Desc")] ExpenseType expenseType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expenseType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expenseType);
        }

        // GET: ExpenseTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseType = await _context.ExpenseType.FindAsync(id);
            if (expenseType == null)
            {
                return NotFound();
            }
            return View(expenseType);
        }

        // POST: ExpenseTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExpenseTypeId,Name,Desc")] ExpenseType expenseType)
        {
            if (id != expenseType.ExpenseTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expenseType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseTypeExists(expenseType.ExpenseTypeId))
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
            return View(expenseType);
        }

        // GET: ExpenseTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var expenseType = await _context.ExpenseType.FindAsync(id);
            if (expenseType != null)
            {
                _context.ExpenseType.Remove(expenseType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: ExpenseTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expenseType = await _context.ExpenseType.FindAsync(id);
            if (expenseType != null)
            {
                _context.ExpenseType.Remove(expenseType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseTypeExists(int id)
        {
            return _context.ExpenseType.Any(e => e.ExpenseTypeId == id);
        }
    }
}
