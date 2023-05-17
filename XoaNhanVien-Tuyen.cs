using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement
{
	public class Employee
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Title { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Address { get; set; }
		public string PhoneNo { get; set; }
		public string Email { get; set; }
	}

	public class EmployeeManager
	{
		private readonly EmployeeContext _context;

		public EmployeeManager(EmployeeContext context)
		{
			_context = context;
		}

		public async Task<bool> AddOrUpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken = default)
		{
			if (employee.Id > 0)
			{
				_context.Update(employee);
			}
			else
			{
				_context.Add(employee);
			}

			var result = await _context.SaveChangesAsync(cancellationToken);
			return result > 0;
		}

		public async Task<bool> DeleteEmployeeAsync(int employeeId, CancellationToken cancellationToken = default)
		{
			var employee = await _context.Employees.SingleOrDefaultAsync(e => e.Id == employeeId, cancellationToken);
			if (employee != null)
			{
				_context.Employees.Remove(employee);
				var result = await _context.SaveChangesAsync(cancellationToken);
				return result > 0;
			}

			return false;
		}

		public async Task<IEnumerable<Employee>> GetEmployeesAsync(CancellationToken cancellationToken = default)
		{
			return await _context.Employees.ToListAsync(cancellationToken);
		}

		public async Task<IEnumerable<Employee>> GetEmployeesByNameAsync(string name, CancellationToken cancellationToken = default)
		{
			return await _context.Employees.Where(e => e.Name == name).ToListAsync(cancellationToken);
		}

		public async Task<IEnumerable<Employee>> GetEmployeesByTitleAsync(string title, CancellationToken cancellationToken = default)
		{
			return await _context.Employees.Where(e => e.Title == title).ToListAsync(cancellationToken);
		}
		public async Task<bool> RemoveEmployeesWithSameJobFunction(string jobFunction, CancellationToken cancellationToken = default)
		{
			// Get all employees with the same job function.
			var employees = await _context.Employees.Where(e => e.Title == jobFunction).ToListAsync(cancellationToken);

			// Remove all employees with the same job function.
			foreach (var employee in employees)
			{
				_context.Employees.Remove(employee);
			}

			// Save the changes.
			await _context.SaveChangesAsync(cancellationToken);

			// Return true if the operation was successful.
			return employees.Any();
		}
		public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
      		{
            		// Save the changes.
         		var result = await _context.SaveChangesAsync(cancellationToken);

            		// Return the number of changes that were saved.
            		return result;
        	}
	}

	public class EmployeeContext : DbContext
	{
		public DbSet<Employee> Employees { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Employee>()
				.HasKey(e => e.Id);

			modelBuilder.Entity<Employee>()
				.Property(e => e.Name)
				.IsRequired();

			modelBuilder.Entity<Employee>()
				.Property(e => e.Title)
				.IsRequired();

			modelBuilder.Entity<Employee>()
				.Property(e => e.DateOfBirth)
				.IsRequired();

			modelBuilder.Entity<Employee>()
				.Property(e => e.Address)
				.IsRequired();

			modelBuilder.Entity<Employee>()
				.Property(e => e.PhoneNo)
				.IsRequired();

			modelBuilder.Entity<Employee>()
				.Property(e => e.Email)
				.IsRequired();
		}

		public string ConnectionString { get; set; }
	}
	public class Program
	{
		public static void Main(string[] args)
		{
			// Create a new EmployeeManager instance.
			var employeeManager = new EmployeeManager(new EmployeeContext());

			// Set the connection string.
			//employeeManager.ConnectionString = @"Data Source=localhost;Initial Catalog=EmployeeManagement;Integrated Security=True";

			// Add a new employee.
			var employee = new Employee
			{
				Name = "John Doe",
				Title = "Software Engineer",
				DateOfBirth = DateTime.Now,
				Address = "123 Main Street",
				PhoneNo = "123-456-7890",
				Email = "john.doe@example.com"
			};

			await employeeManager.AddOrUpdateEmployeeAsync(employee);

			// Get all employees.
			var employees = await employeeManager.GetEmployeesAsync();

			// Print the employees.
			foreach (var employee in employees)
			{
				Console.WriteLine(employee.Name);
			}

			Console.ReadKey();
		}
	}
