using StaffManage.Data.Contexts;
using StaffManage.Data.Seeders;

var context = new StaffDbContext();

var seeder = new DataSeeder(context);

seeder.Initialize();

var employees = context.Employees.ToList();

Console.WriteLine("{0,-5}{1,-50}{2,10}{2,10}{1,-50}{1,-50}{2,-30}{3,12}{2,-30}{3,12}{2,-30}{1,-50}",
    "ID", "Full Name", "Gender", "Age", "Job", "TimeOfWork", "Phone", "Birthday", "Resident_ID", "Joined Date", "Email", "Address");

foreach (var employee in employees)
{
    Console.WriteLine("{0,-5}{1,-50}{2,10}{2,10}{1,-50}{1,-50}{2,-30}{3,12:MM/dd/yyyy}{2,-30}{3,12:MM/dd/yyyy}{2,-30}{1,-50}",
        employee.Id, employee.FullName, employee.Gender, employee.Age, employee.Job, employee.TimeOfWork, employee.Phone, employee.Birthday, employee.Resident_ID, employee.JoinedDate, employee.Email, employee.Address);
}