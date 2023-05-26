using Microsoft.EntityFrameworkCore;
using StaffManage.Core.Entities;
using StaffManage.Data.Mappings;

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
            //optionsBuilder.UseSqlServer("Data Source = DELL\\NGOCSON;Database=StaffManage_3; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AbsenceMap).Assembly);
        }
    }
}

