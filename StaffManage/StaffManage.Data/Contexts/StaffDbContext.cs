﻿using Microsoft.EntityFrameworkCore;
using StaffManage.Core.Entities;
using StaffManage.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManage.Data.Contexts
{
    public class StaffDbContext : DbContext
    {
        public DbSet<Absence> Absence { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<Contract> Contract { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<CurriculumVitae> CurriculumVitaes { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Payroll> Payroll { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Qualification> Qualification { get; set; }
        public DbSet<Salary> Salary { get; set; }
        public DbSet<TrainingHistory> TrainingHistory { get; set; }
        public DbSet<Work> Work { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-D79P76S\DOMINHDANG;Database=StaffManage;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AbsenceMap).Assembly);
        }
    }
}
