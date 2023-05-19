using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Services.Employees
{
    public class EmployeeRepository
    {
        private readonly EmployeeDbContext _context;
        public EmployeeRepository(EmployeeDbContext context){
            _context = context;
        }
        public async Task<bool> UpdateAsync(
		Employee employee, CancellationToken cancellationToken = default)
        {
            if (employee.Id > 0)
                _context.Employee.Update(employee);

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> UpdateNameAsync(int employeeId,
		string newName, CancellationToken cancellationToken = default)
        {
            if (employeeId > 0)
                _context.Employee.Where(e=>e.Id == employeeId)
                .ExecuteUpdate(b => b.SetProperty(e=>e.Name,newName));
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> UpdateGenderAsync(int employeeId, CancellationToken cancellationToken = default)
        {
            if (employeeId > 0){
                var employees = _context.Employee.ToList();
                foreach(var employee in employees){
                    if(employee.Id == employeeId){
                        employee.Gender = !employee.Gender;
                        _context.Employee.Update(employee);
                    }
                }
            }
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> UpdateBirthdayAsync(int employeeId,
		DateTime newBirthdate, CancellationToken cancellationToken = default)
        {
            if (employeeId > 0)
                _context.Employee.Where(e=>e.Id == employeeId)
                .ExecuteUpdate(b => b.SetProperty(e=>e.DateOfBirth,newBirthdate));
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> UpdateImgUrlAsync(int employeeId,
		string newUrl, CancellationToken cancellationToken = default)
        {
            if (employeeId > 0)
                _context.Employee.Where(e=>e.Id == employeeId)
                .ExecuteUpdate(b => b.SetProperty(e=>e.PortraitUrl,newUrl));
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> UpdatePhoneNumberAsync(int employeeId,
		string newPhoneNumber, CancellationToken cancellationToken = default)
        {
            if (employeeId > 0)
                _context.Employee.Where(e=>e.Id == employeeId)
                .ExecuteUpdate(b => b.SetProperty(e=>e.PhoneNumber,newPhoneNumber));
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> UpdateCCCDAsync(int employeeId,
		string newCCCD, CancellationToken cancellationToken = default)
        {
            if (employeeId > 0)
                _context.Employee.Where(e=>e.Id == employeeId)
                .ExecuteUpdate(b => b.SetProperty(e=>e.IdentityCardNumber,newCCCD));
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> UpdateAddressAsync(int employeeId,
		string newAddress, CancellationToken cancellationToken = default)
        {
            if (employeeId > 0)
                _context.Employee.Where(e=>e.Id == employeeId)
                .ExecuteUpdate(b => b.SetProperty(e=>e.Address,newAddress));
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}