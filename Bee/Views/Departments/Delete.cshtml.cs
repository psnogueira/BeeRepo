﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bee.Data;
using Bee.Models;

namespace Bee.Views.Departments
{
    public class DeleteModel : PageModel
    {
        private readonly Bee.Data.ApplicationDbContext _context;

        public DeleteModel(Bee.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Department Department { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Department.FirstOrDefaultAsync(m => m.DepartmentId == id);

            if (department == null)
            {
                return NotFound();
            }
            else
            {
                Department = department;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Department.FindAsync(id);
            if (department != null)
            {
                Department = department;
                _context.Department.Remove(Department);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
