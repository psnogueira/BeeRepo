using System;
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
    public class FranchisesController : Controller
    {
        private readonly ApplicationDbContext _context;

        private IWebHostEnvironment _webHostEnvironment;
        private readonly IFranchise _franchise;

        public FranchisesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, IFranchise franchise)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _franchise = franchise;
        }

        // GET: Franchises
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var franchise = from s in _context.Franchise
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                int searchId;
                bool isNumericSearch = int.TryParse(searchString, out searchId);

                franchise = franchise.Where(r => r.Name.Contains(searchString) || (isNumericSearch && r.FranchiseId == searchId));
            }

            return View(await franchise.ToListAsync());
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
            string path;
            DataTable dt;

            try
            {
                path = _franchise.DocumentUpload(formFile);
                dt = _franchise.FranchiseDataTable(path);
                _franchise.ImportFranchise(dt);
            }
            catch (Exception)
            {
                ModelState.AddModelError("Arquivo", "Erro ao ler o arquivo.");

                return RedirectToAction(nameof(Import));
            }
            
            //return RedirectToAction(nameof(Index));

            return View();
        }

        // GET: Franchises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var franchise = await _context.Franchise
                .FirstOrDefaultAsync(m => m.FranchiseId == id);
            if (franchise == null)
            {
                return NotFound();
            }

            return View(franchise);
        }

        // GET: Franchises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Franchises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FranchiseId,Name,Desc")] Franchise franchise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(franchise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(franchise);
        }

        // GET: Franchises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var franchise = await _context.Franchise.FindAsync(id);
            if (franchise == null)
            {
                return NotFound();
            }
            return View(franchise);
        }

        // POST: Franchises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FranchiseId,Name,Desc")] Franchise franchise)
        {
            if (id != franchise.FranchiseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(franchise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FranchiseExists(franchise.FranchiseId))
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
            return View(franchise);
        }

        // GET: Franchises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var franchise = await _context.Franchise.FindAsync(id);
            if (franchise != null)
            {
                _context.Franchise.Remove(franchise);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Franchises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var franchise = await _context.Franchise.FindAsync(id);
            if (franchise != null)
            {
                _context.Franchise.Remove(franchise);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FranchiseExists(int id)
        {
            return _context.Franchise.Any(e => e.FranchiseId == id);
        }
    }
}
