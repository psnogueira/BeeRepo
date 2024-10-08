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
using Bee.Models.ViewModel;

namespace Bee.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private IWebHostEnvironment _webHostEnvironment;
        private readonly IEvent _event;

        public EventsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, IEvent f_event)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _event = f_event;
        }

        // GET: Events
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var _event = from s in _context.Event
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                int searchId;
                bool isNumericSearch = int.TryParse(searchString, out searchId);

                _event = _event.Where(r => r.Name.Contains(searchString) || (isNumericSearch && r.EventId == searchId));
            }

            return View(await _event.ToListAsync());
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
            string path = _event.DocumentUpload(formFile);
            DataTable dt = _event.EventDataTable(path);
            _event.ImportEvent(dt);

            //return RedirectToAction(nameof(Index));

            return View();
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,Name,EventTypeId,CompanyId,FranchiseId,StartDate,EndDate,Objective,Status,Format,City,Localization,Budget")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,Name,EventTypeId,CompanyId,FranchiseId,StartDate,EndDate,Objective,Status,Format,City,Localization,Budget")] Event @event)
        {
            if (id != @event.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventId))
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
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var _event = await _context.Event.FindAsync(id);
            if (_event != null)
            {
                _context.Event.Remove(_event);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Event.FindAsync(id);
            if (@event != null)
            {
                _context.Event.Remove(@event);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.EventId == id);
        }
    }
}
