using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts
{
    public class EmployeeDbContext: DbContext
    {
        public DbSet<Employee>? Employee { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=employee.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeMap).Assembly);
        }
    }
}