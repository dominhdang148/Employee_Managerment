using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Data.Contexts;

namespace Data.Seeders
{
    public class DataSeeder:IDataSeeder
    {
        private readonly EmployeeDbContext _dbContext;

        public DataSeeder(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Initialize()
        {
            _dbContext.Database.EnsureCreated();
            if(_dbContext.Employee.Any()) return;

            var employees = AddEmployees();
        }

        private IList<Employee> AddEmployees()
        {
            var employees = new List<Employee>(){
                new(){
                    Name = "Seed 1",
                    Gender = true,
                    PortraitUrl = "seed.jpg",
                    PhoneNumber = "033333333",
                    DateOfBirth = new DateTime(2000, 1, 20),
                    IdentityCardNumber = "1341234231",
                    Address = "no where 02, nowhere City"
                },
                new(){
                    Name = "Seed 2",
                    Gender = true,
                    PortraitUrl = "seed2.jpg",
                    PhoneNumber = "044444444",
                    DateOfBirth = new DateTime(2001, 2, 15),
                    IdentityCardNumber = "1413241234",
                    Address = "no where 03, nowhere City"
                }
            };

            _dbContext.Employee.AddRange(employees);
            _dbContext.SaveChanges();
            return employees;
        }
    }
}