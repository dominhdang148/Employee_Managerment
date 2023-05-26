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
    

        private IList<EmployeeInfo> AddEmployees()
        {
            var employees = new List<EmployeeInfo>()
        {
            new()
            {
                FullName = "Võ Văn Hoàng",
                Gender = "Nam",
                Age = "21",
                Job = "Lễ tân",
                TimeOfWork = "Sáng",
                Phone = "0927849123",
                Birthday = new DateTime(2002, 01, 21),
                Resident_ID = "CV01D252",
                JoinedDate = new DateTime(2022, 10, 21),
                Email = "vovanhoang@gmail.com",
                Address = "61 Bà Triệu, Đà Lạt"
            },
            new()
            {
                FullName = "Trần Đình Công",
                Gender = "Nam",
                Age = "21",
                Job = "Bếp trưởng",
                TimeOfWork = "Sáng, Chiều",
                Phone = "0928457295",
                Birthday = new DateTime(2002, 07, 03),
                Resident_ID = "CV02D271",
                JoinedDate = new DateTime(2022, 08, 28),
                Email = "trandinhcong@gmail.com",
                Address = "152 Phan Đình Phùng, Đà Lạt"
            },
            new()
            {
                FullName = "Ngyễn Thị Thủy Tiên",
                Gender = "Nữ",
                Age = "20",
                Job = "Thu ngân",
                TimeOfWork = "Sáng",
                Phone = "0972811992",
                Birthday = new DateTime(2003, 05, 15),
                Resident_ID = "CV01D252",
                JoinedDate = new DateTime(2021, 12, 20),
                Email = "nguyenthithuytien@gmail.com",
                Address = "1 Trần Khánh Dư, Đà Lạt"
            },
            new()
            {
                FullName = "Trần Duy Quang",
                Gender = "Nam",
                Age = "20",
                Job = "Bảo vệ",
                TimeOfWork = "Cả ngày",
                Phone = "0995038129",
                Birthday = new DateTime(2003, 06, 30),
                Resident_ID = "CV04D118",
                JoinedDate = new DateTime(2023, 11, 11),
                Email = "tranduyquang@gmail.com",
                Address = "20 Phạm Ngũ Lão, Đà Lạt"
            },
            new()
            {
                FullName = "Hải Thị Mỹ Yến",
                Gender = "Nữ",
                Age = "21",
                Job = "Lễ tân",
                TimeOfWork = "Chiều",
                Phone = "0986177280",
                Birthday = new DateTime(2002, 12, 08),
                Resident_ID = "CV01D252",
                JoinedDate = new DateTime(2021, 03, 30),
                Email = "haithimyyen@gmail.com",
                Address = "102 Trần Phú, Đà Lạt, "
            }
        };

            _dbContext.Employees.AddRange(employees);
            _dbContext.SaveChanges();

            return employees;
        }
}
