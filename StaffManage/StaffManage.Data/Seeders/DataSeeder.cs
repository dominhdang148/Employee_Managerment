using StaffManage.Core.Entities;
using StaffManage.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Reflection;
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
            var employees = AddEmployees();

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
    

        private IList<CurriculumVitae> AddEmployees()
        {
            var employees = new List<CurriculumVitae>()
        {
            new()
            {
                Name = "Võ Văn Hoàng",
                Gender = true,
                PhoneNumber = "0928457295",
                DateOfBirth = new DateTime(2002, 01, 21),
                IdentityCardNumber = "CV01D252",
                JoinedDate = new DateTime(2022, 10, 21),
                Email = "vovanhoang@gmail.com",
                Address = "61 Bà Triệu, Đà Lạt"
            },
            new()
                {
                Name = "Trần Đình Công",
                Gender = true,
                PhoneNumber = "0927849123",
                DateOfBirth = new DateTime(2002, 07, 03),
                IdentityCardNumber = "CV02D271",
                JoinedDate = new DateTime(2022, 08, 28),
                Email = "trandinhcong@gmail.com",
                Address = "152 Phan Đình Phùng, Đà Lạt"
            },
            new()
                {
                Name = "Ngyễn Thị Thủy Tiên",
                Gender = false,
                PhoneNumber = "0972811992",
                DateOfBirth = new DateTime(2003, 05, 15),
                IdentityCardNumber = "CV01D252",
                JoinedDate = new DateTime(2021, 12, 20),
                Email = "nguyenthithuytien@gmail.com",
                Address = "1 Trần Khánh Dư, Đà Lạt"
            },
            new()
                {
                Name = "Trần Duy Quang",
                Gender = true,
                PhoneNumber = "0995038129",
                DateOfBirth = new DateTime(2003, 06, 30),
                IdentityCardNumber = "CV01D252",
                JoinedDate = new DateTime(2023, 11, 11),
                Email = "tranduyquang@gmail.com",
                Address = "20 Phạm Ngũ Lão, Đà Lạt"
            },
            new()
                {
                Name = "Hải Thị Mỹ Yến",
                Gender = true,
                PhoneNumber = "0986177280",
                DateOfBirth = new DateTime(2002, 12, 08),
                IdentityCardNumber = "CV01D252",
                JoinedDate = new DateTime(2021, 03, 30),
                Email = "haithimyyen@gmail.com",
                Address = "102 Trần Phú, Đà Lạt,"
            }

        };

            _dbContext.Employees.AddRange(employees);
            _dbContext.SaveChanges();

            return employees;
        }
}
