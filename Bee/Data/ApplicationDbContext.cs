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
        public DbSet<Bee.Models.ExpenseType> ExpenseType { get; set; } = default!;
        public DbSet<Bee.Models.EventType> EventType { get; set; } = default!;
        public DbSet<Bee.Models.Supplier> Supplier { get; set; } = default!;
        public DbSet<Bee.Models.Company> Company { get; set; } = default!;
        public DbSet<Bee.Models.HACAT> HACAT { get; set; } = default!;
        public DbSet<Bee.Models.Franchise> Franchise { get; set; } = default!;
        public DbSet<Bee.Models.Event> Event { get; set; } = default!;
        public DbSet<Bee.Models.Expense> Expense { get; set; } = default!;
    }
}
