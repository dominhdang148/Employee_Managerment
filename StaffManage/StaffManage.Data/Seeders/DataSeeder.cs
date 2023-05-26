using StaffManage.Core.Entities;
using StaffManage.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace StaffManage.Data.Seeders
{
    public class DataSeeder : IDataSeeder
    {
        private readonly StaffDbContext _dbContext;
        public DataSeeder(StaffDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Initialize()
        {
            _dbContext.Database.EnsureCreated();
            if (_dbContext.Employee.Any()) return;

            var department = AddDepartment();
            var salary = AddSalary();

        }
        private IList<Department> AddDepartment()
        {
            var departments = new List<Department>()
            {
                new()
                {
                    Name="Buồng Phòng"
                },
                new()
                {
                    Name="Lễ tân"
                },
                new()
                {
                    Name="Ẩm thực"
                },
                new()
                {
                    Name="Tài chính - Kế toán"
                },
                new()
                {
                    Name="Kinh doanh"
                },
            };
        }
        //private IList<Salary> AddSalary()
        //{

        //}
    }
}
