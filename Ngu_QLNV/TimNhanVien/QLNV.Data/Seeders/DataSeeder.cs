using System;
using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;

namespace TatBlog.Data.Seeders;

public class DataSeeder : IDataSeeder
{
    private readonly BlogDbContext _dbContext;

    public DataSeeder(BlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Initialize()
    {
        _dbContext.Database.EnsureCreated();

        var employees = AddEmployees();

    }

    private IList<Employee> AddEmployees() 
    {
        var employees = new List<Employee>()
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
