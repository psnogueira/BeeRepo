﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bee.Data;
using Bee.Models;
using System.Text;
using ExcelDataReader;
using System.Data;
using System.Diagnostics;
using Bee.Repository;

namespace Bee.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ApplicationDbContext _context;

        private IWebHostEnvironment _webHostEnvironment;
        private readonly IExpense _expense;

        public ExpensesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, IExpense expense)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _expense = expense;
        }

        // GET: Expenses
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var expense = from s in _context.Expense
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                int searchId;
                bool isNumericSearch = int.TryParse(searchString, out searchId);

                expense = expense.Where(r => (isNumericSearch && r.ExpenseTypeId == searchId));
            }

            return View(await expense.ToListAsync());
        }

        public IActionResult Import()
        {
            return View();
        }

        public IActionResult ImportConfirmation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ImportConfirmation(IFormFile formFile)
        {
            string path = _expense.DocumentUpload(formFile);
            DataTable dt = _expense.ExpenseDataTable(path);
            _expense.ImportExpense(dt);

            //return RedirectToAction(nameof(Index));

            return View();
        }

        // GET: Expenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expense
                .FirstOrDefaultAsync(m => m.ExpenseId == id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // GET: Expenses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExpenseId,SupplierId,ExpenseTypeId,Value")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expense);
        }

        // GET: Expenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expense.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }
            return View(expense);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExpenseId,SupplierId,ExpenseTypeId,Value")] Expense expense)
        {
            if (id != expense.ExpenseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseExists(expense.ExpenseId))
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
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var expense = await _context.Expense.FindAsync(id);
            if (expense != null)
            {
                _context.Expense.Remove(expense);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expense = await _context.Expense.FindAsync(id);
            if (expense != null)
            {
                _context.Expense.Remove(expense);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseExists(int id)
        {
            return _context.Expense.Any(e => e.ExpenseId == id);
        }
    }
}
