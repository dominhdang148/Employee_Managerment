// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

using var dbContext = new StaffDbContext();
var staffManager = new StaffManager(dbContext);

// Xóa toàn bộ nhân viên
await staffManager.DeleteAllEmployeesAsync();

// Xóa nhân viên theo tên
await staffManager.DeleteEmployeesByNameAsync("John");

// Xóa các nhân viên cùng công việc
await staffManager.DeleteEmployeesByWorkAsync(1);

// Xóa các nhân viên cùng chức vụ
await staffManager.DeleteEmployeesByPositionAsync(2);