using Data.Contexts;
using Data.Seeders;
using Services.Employees;

internal class Program
{
    private static async Task Main(string[] args)
    {

        // var seeder = new DataSeeder(context);

        // seeder.Initialize();
        do
        {
            var context = new EmployeeDbContext();
            EmployeeRepository employeeRepo = new EmployeeRepository(context);
            var employees = context.Employee.ToList();


            Console.WriteLine($"{"ID",-5}{"Ten",-20}{"Gioi tinh",-12}{"Url Anh",-15}{"So DT",-15}{"Ngay Sinh",-15:dd/MM/yyyy}{"CCCD",-15}{"Dia chi"}");

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Id,-5}{employee.Name,-20}{(employee.Gender ? "Nam" : "Nữ"),-12}{employee.PortraitUrl,-15}{employee.PhoneNumber,-15}{employee.DateOfBirth,-15:dd/MM/yyyy}{employee.IdentityCardNumber,-15}{employee.Address}");
            }
            Console.WriteLine("Enter the id: ");
            try
            {
                int inputId = Convert.ToInt32(Console.ReadLine());                
                Console.WriteLine("Pick an option (1 for name and 2 for gender):");
                int optionNum = Convert.ToInt32(Console.ReadLine());
                if (optionNum == 0)
                    break;
                switch (optionNum)
                {
                    case 1:
                        Console.WriteLine("Enter a new name");
                        string newName = Console.ReadLine();
                        await employeeRepo.UpdateNameAsync(inputId, newName);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Update Name Successfully!");
                        Console.ResetColor();
                        break;
                    case 2:
                        await employeeRepo.UpdateGenderAsync(inputId);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Update Gender Successfully!");
                        Console.ResetColor();
                        break;
                    case 3:
                        Console.WriteLine("Enter a new Image Url");
                        string? newUrl = Console.ReadLine();
                        await employeeRepo.UpdateImgUrlAsync(inputId, newUrl);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Update Image Url Successfully!");
                        Console.ResetColor();
                        break;
                    case 4:
                        Console.WriteLine("Enter a new Phone Number");
                        string? newPhoneNumber = Console.ReadLine();
                        await employeeRepo.UpdatePhoneNumberAsync(inputId, newPhoneNumber);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Update Number Successfully!");
                        Console.ResetColor();
                        break;
                    case 5:
                        DateTime newBirthdate = new DateTime(2002, 5, 15);
                        await employeeRepo.UpdateBirthdayAsync(inputId, newBirthdate);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Update Birthdate Successfully!");
                        Console.ResetColor();
                        break;
                    default:
                        Console.WriteLine("Please pick an option");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
            }
        } while (true);
        Console.WriteLine("Bye");


    }


}