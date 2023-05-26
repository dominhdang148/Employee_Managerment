//using StaffManage.Data.Contexts;
//using StaffManage.Data.Seeders;
//using StaffManage.Services.Manager;
//using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

//var context = new StaffDbContext();
//var seeder = new DataSeeder(context);
//seeder.Initialize();
//var curriculumVitaes = context.CurriculumVitaes.ToList();
//var works = context.Work.ToList();
//var qualifications = context.Qualification.ToList();
//var attendances = context.Attendance.ToList();
//var absences = context.Absence.ToList();


//Thêm hoặc cập nhật một CV
//var newCV = new CurriculumVitae()
//{

//    Name = "Employee15",
//foreach (var curriculumVitae in curriculumVitaes)
//{
//    Console.WriteLine(curriculumVitae.Name);
//}
//var works = context.Work.ToList();
//foreach (var work in works)
//{
//    Console.WriteLine(work.Name);
//    Console.WriteLine("date:{0:MM/dd/yyyyy}", work.EndTime);
//}
//IQLNVRepository qlnvRepo=  new QLNVRepository(context);
//var works = await qlnvRepo.GetWorkAsync();
//foreach (var item in works)
//{
//    Console.WriteLine(item.Name);
//}

//Thêm hoặc cập nhật một CV
//var newCV = new CurriculumVitae()
//{ Id=1,
//    Name = "Employee1_Update",
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
//IQLNVRepository blogRepo = new QLNVRepository(context);
//var rowChange = await blogRepo.AddOrEditCVsAsync(newCV);
//Console.WriteLine(rowChange ? "Update success" : "Failed, try again");



//Thêm hoặc cập nhật một employee
//var newemp = new Employee()
//{

//Thêm hoặc cập nhật một employee
//var newemp = new Employee()
//{
//    Id=1,
//    Qualification = qualifications[0],
//    Absence = absences[1],
//    Attendance = attendances[1],
//    Work = works[2],
//    CurriculumVitae = curriculumVitaes[10]
//};

//IStaffRepository blogRepo = new StaffRepository(context);
//var rowChange = await blogRepo.AddOrUpdateEmployeeAsync(newemp);
//Console.WriteLine(rowChange ? "Update success" : "Failed, try again");

//var emps = context.Employee

//    .Select(p => new
//    {
//        Id = p.Id,
//        Qualification = p.Qualification.Name,
//        CurriculumVitae = p.CurriculumVitae.Name,
//        Absence = p.Absence.Reason,
//        Work = p.Work.Name,
//        Attendance = p.Attendance.OffDay,
//    })
//    .ToList();

//foreach (var emp in emps)
//{
//    Console.WriteLine("ID:     : {0}", emp.Id);
//    Console.WriteLine("Qualification: {0}", emp.Qualification);
//    Console.WriteLine("CurriculumVitae_Name:   : {0}", emp.CurriculumVitae);
//    Console.WriteLine("Attendance:   : {0}", emp.Attendance);
//    Console.WriteLine("Work  : {0}", emp.Work);
//    Console.WriteLine("Absence: {0}", emp.Absence);
//    Console.WriteLine("".PadRight(80, '-'));
//}

//Console.ReadKey();
//    CurriculumVitae = curriculumVitaes[6]
//};

//IQLNVRepository blogRepo = new QLNVRepository(context);
//var rowChange = await blogRepo.AddOrUpdateEmployeeAsync(newemp);
//Console.WriteLine(rowChange ? "Update success" : "Failed, try again");




//var emps = context.Employee.Select(p => new
//	{
//		Id = p.Id,
//		Qualification = p.Qualification.Name,
//		CurriculumVitae = p.CurriculumVitae.Name,
//		Absence = p.Absence.Reason,
//		Work = p.Work.Name,
//		Attendance = p.Attendance.OffDay,
//	})
//	.ToList();

//foreach (var emp in emps)
//{
//	Console.WriteLine("ID:     : {0}", emp.Id);
//	Console.WriteLine("Qualification: {0}", emp.Qualification);
//	Console.WriteLine("CurriculumVitae_Name:   : {0}", emp.CurriculumVitae);
//	Console.WriteLine("Attendance:   : {0:MM/dd/yyyy}", emp.Attendance);
//	Console.WriteLine("Work  : {0}", emp.Work);
//	Console.WriteLine("Absence: {0}", emp.Absence);
//	Console.WriteLine("".PadRight(80, '-'));
//}
//// Xóa nhân viên
//var employeeIdToDelete = 1;
//IStaffRepository qlnvRepo = new StaffRepository(context);
//var deleteResult = await qlnvRepo.DeleteEmployeeAsync(employeeIdToDelete);
//Console.WriteLine(deleteResult ? "Employee deleted successfully" : "Failed to delete employee");

//// Xóa toàn bộ nhân viên
//var deleteAllResult = await qlnvRepo.DeleteAllEmployeesAsync();
//Console.WriteLine(deleteAllResult ? "All employees deleted successfully" : "Failed to delete all employees");

//// Xóa nhân viên theo tên
//var employeeNameToDelete = "John Doe";
//var deleteByNameResult = await qlnvRepo.DeleteEmployeesByNameAsync(employeeNameToDelete);
//Console.WriteLine(deleteByNameResult ? $"Employees with name '{employeeNameToDelete}' deleted successfully" : $"Failed to delete employees with name '{employeeNameToDelete}'");

//// Xóa các nhân viên cùng công việc
//var workIdToDelete = "1";
//if (int.TryParse(workIdToDelete, out int workId))
//{
//	var deleteByWorkResult = await qlnvRepo.DeleteEmployeesByWorkAsync(workId);
//	Console.WriteLine(deleteByWorkResult ? $"Employees with work ID '{workIdToDelete}' deleted successfully" : $"Failed to delete employees with work ID '{workIdToDelete}'");
//}
//else
//{
//	Console.WriteLine($"Invalid work ID: '{workIdToDelete}'");
//}
//// Xóa các nhân viên cùng chức vụ
//var positionIdToDelete = "1";
//var deleteByPositionResult = await qlnvRepo.DeleteEmployeesByPositionAsync(positionIdToDelete);
//Console.WriteLine(deleteByPositionResult ? $"Employees with position ID '{positionIdToDelete}' deleted successfully" : $"Failed to delete employees with position ID '{positionIdToDelete}'");

Console.WriteLine("Hello World");