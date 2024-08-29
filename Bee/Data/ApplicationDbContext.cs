using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Bee.Models;
using System;

namespace Bee.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Bee.Models.Department> Department { get; set; } = default!;
        public DbSet<Bee.Models.WBS> WBS { get; set; } = default!;
    }
}
