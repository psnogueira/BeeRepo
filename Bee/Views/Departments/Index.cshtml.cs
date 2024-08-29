using System;
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
    public class IndexModel : PageModel
    {
        private readonly Bee.Data.ApplicationDbContext _context;

        public IndexModel(Bee.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Department> Department { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Department = await _context.Department.ToListAsync();
        }
    }
}
