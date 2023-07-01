using Microsoft.Identity.Client;
using StaffManage.Core.Constants;
using StaffManage.Core.Entities;
using StaffManage.Data.Contexts;
using StaffManage.Data.Seeders;
using StaffManage.Services.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StaffManage.Test
{
    public class EmployeeTest : ATest
    {

        [Fact]
        public async Task GetEmployeesByNameAsync()
        {
            IStaffRepository staffRepo = new StaffRepository(_context);
            string name = "Employee1";
            var employees = await staffRepo.GetFilteredEmployeesAsync(new EmployeeQuery()
            {
                Keyword = name
            });

            Assert.Contains(employees, e => e.CurriculumVitae.Name == name);

        }

        [Fact]
        public async void GetEmployeeById()
        {
            IStaffRepository staffRepository = new StaffRepository(_context);
            var employeeList = await staffRepository.GetFilteredEmployeesAsync(new EmployeeQuery());
            int id = employeeList[0].Id;
            var employee = await staffRepository.GetEmployeeByIdAsync(id);
            Assert.Equal(id, employee.Id);
        }
        [Fact]
        public async void GetEmployees()
        {
            IStaffRepository staff = new StaffRepository(_context);
            var employees = await staff.GetFilteredEmployeesAsync(new EmployeeQuery());
            Assert.NotEmpty(employees);
        }
        [Fact]
        public async Task DeleteAllEmployeeAsync()
        {
            IStaffRepository staff = new StaffRepository(_context);
            bool result = await staff.DeleteAllEmployeesAsync();
            Assert.True(result);
            var seeder = new DataSeeder(_context);
            seeder.Initialize();
        }
        [Fact]
        public async void DeleteByName()
        {
            IStaffRepository staff = new StaffRepository(_context);
            bool result = await staff.DeleteEmployeesByNameAsync("Test");
            Assert.True(result);
        }
        


    }
}
