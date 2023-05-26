﻿using StaffManage.Core.Entities;
using StaffManage.Data.Contexts;
using StaffManage.Data.Seeders;
using StaffManage.Services.Manager;

var context = new StaffDbContext();
var seeder = new DataSeeder(context);
seeder.Initialize();
var curriculumVitaes = context.CurriculumVitaes.ToList();
var works = context.Work.ToList();
var qualifications = context.Qualification.ToList();
var attendances = context.Attendance.ToList();
var absences = context.Absence.ToList();


//Thêm hoặc cập nhật một CV
//var newCV = new CurriculumVitae()
//{

//    Name = "Employee15",
//    Gender = false,
//    PortraitUrl = "",
//    PhoneNumber = "0344567",
//    DateOfBirth = new DateTime(2000, 5, 5),
//    IdentityCardNumber = "122349999",
//    JoinedDate = new DateTime(2023, 6, 7),
//    Address = "Ha Noi",
//    Email = "@dou.edu.vn"
//};

//IStaffRepository blogRepo = new StaffRepository(context);
//var rowChange = await blogRepo.AddOrEditCVsAsync(newCV);
//Console.WriteLine(rowChange ? "Update success" : "Failed, try again");



//Thêm hoặc cập nhật một employee
//var newemp = new Employee()
//{

//    Qualification = qualifications[0],
//    Absence = absences[1],
//    Attendance = attendances[1],
//    Work = works[2],
//    CurriculumVitae = curriculumVitaes[10]
//};

//IStaffRepository blogRepo = new StaffRepository(context);
//var rowChange = await blogRepo.AddOrUpdateEmployeeAsync(newemp);
//Console.WriteLine(rowChange ? "Update success" : "Failed, try again");

var emps = context.Employee

    .Select(p => new
    {
        Id = p.Id,
        Qualification = p.Qualification.Name,
        CurriculumVitae = p.CurriculumVitae.Name,
        Absence = p.Absence.Reason,
        Work = p.Work.Name,
        Attendance = p.Attendance.OffDay,
    })
    .ToList();

foreach (var emp in emps)
{
    Console.WriteLine("ID:     : {0}", emp.Id);
    Console.WriteLine("Qualification: {0}", emp.Qualification);
    Console.WriteLine("CurriculumVitae_Name:   : {0}", emp.CurriculumVitae);
    Console.WriteLine("Attendance:   : {0}", emp.Attendance);
    Console.WriteLine("Work  : {0}", emp.Work);
    Console.WriteLine("Absence: {0}", emp.Absence);
    Console.WriteLine("".PadRight(80, '-'));
}

Console.ReadKey();