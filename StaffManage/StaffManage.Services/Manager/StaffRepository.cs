using StaffManage.Core.Entities;
using StaffManage.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManage.Services.Manager
{
    public class StaffRepository : IStaffRepository
    {
        private readonly StaffDbContext _context;
        public StaffRepository(StaffDbContext context) => _context = context;

        // Code truy vấn ở đây

        public async Task<IEnumerable<CurriculumVitae>> GetEmployeesByNameAsync(
            string name, CancellationToken cancellationToken = default)
        {
            return await _context.Employees.Where(
                e => e.Name == name).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<CurriculumVitae>> GetEmployeesByAddressAsync(
            string address, CancellationToken cancellationToken = default)
        {
            return await _context.Employees.Where(
                e => e.Address == address).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<CurriculumVitae>> GetEmployeesByEmailAsync(
            string email, CancellationToken cancellationToken = default)
        {
            return await _context.Employees.Where(
                e => e.Email == email).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<CurriculumVitae>> GetEmployeesByIdentityCardNumberAsync(
            string identityCardNumber, CancellationToken cancellationToken = default)
        {
            return await _context.Employees.Where(
                e => e.IdentityCardNumber == identityCardNumber).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<CurriculumVitae>> GetEmployeesByJoinedDateAsync(
            string joinedDate, CancellationToken cancellationToken = default)
        {
            return await _context.Employees.Where(
                e => e.JoinedDate == joinedDate).ToListAsync(cancellationToken);
        }

        // Các phương thức Cập nhật của Hưng
        public async Task<bool> UpdateCvAsync(
        CurriculumVitae curriculumVitae, CancellationToken cancellationToken = default)
        {
            if (curriculumVitae.Id > 0)
                _context.CurriculumVitaes.Update(curriculumVitae);

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> UpdateNameAsync(int curriculumVitaeId,
        string newName, CancellationToken cancellationToken = default)
        {
            if (curriculumVitaeId > 0)
                _context.CurriculumVitaes.Where(e => e.Id == curriculumVitaeId)
                .ExecuteUpdate(b => b.SetProperty(e => e.Name, newName));
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> UpdateGenderAsync(int curriculumVitaeId, CancellationToken cancellationToken = default)
        {
            if (curriculumVitaeId > 0)
            {
                var curriculumVitaes = _context.CurriculumVitaes.ToList();
                foreach (var curriculumVitae in curriculumVitaes)
                {
                    if (curriculumVitae.Id == curriculumVitaeId)
                    {
                        curriculumVitae.Gender = !curriculumVitae.Gender;
                        _context.CurriculumVitaes.Update(curriculumVitae);
                    }
                }
            }
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> UpdateBirthdateAsync(int curriculumVitaeId,
        DateTime newBirthDate, CancellationToken cancellationToken = default)
        {
            if (curriculumVitaeId > 0)
                _context.CurriculumVitaes.Where(e => e.Id == curriculumVitaeId)
                .ExecuteUpdate(b => b.SetProperty(e => e.DateOfBirth, newBirthDate));
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> UpdateJoinedDateAsync(int curriculumVitaeId,
        DateTime newJoinedDate, CancellationToken cancellationToken = default)
        {
            if (curriculumVitaeId > 0)
                _context.CurriculumVitaes.Where(e => e.Id == curriculumVitaeId)
                .ExecuteUpdate(b => b.SetProperty(e => e.JoinedDate, newJoinedDate));
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> UpdateImgUrlAsync(int curriculumVitaeId,
        string newUrl, CancellationToken cancellationToken = default)
        {
            if (curriculumVitaeId > 0)
                _context.CurriculumVitaes.Where(e => e.Id == curriculumVitaeId)
                .ExecuteUpdate(b => b.SetProperty(e => e.PortraitUrl, newUrl));
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> UpdatePhoneNumberAsync(int curriculumVitaeId,
        string newPhoneNumber, CancellationToken cancellationToken = default)
        {
            if (curriculumVitaeId > 0)
                _context.CurriculumVitaes.Where(e => e.Id == curriculumVitaeId)
                .ExecuteUpdate(b => b.SetProperty(e => e.PhoneNumber, newPhoneNumber));
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> UpdateCCCDAsync(int curriculumVitaeId,
        string newCCCD, CancellationToken cancellationToken = default)
        {
            if (curriculumVitaeId > 0)
                _context.CurriculumVitaes.Where(e => e.Id == curriculumVitaeId)
                .ExecuteUpdate(b => b.SetProperty(e => e.IdentityCardNumber, newCCCD));
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> UpdateAddressAsync(int curriculumVitaeId,
        string newAddress, CancellationToken cancellationToken = default)
        {
            if (curriculumVitaeId > 0)
                _context.CurriculumVitaes.Where(e => e.Id == curriculumVitaeId)
                .ExecuteUpdate(b => b.SetProperty(e => e.Address, newAddress));
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
        public async Task<bool> UpdateEmailAsync(int curriculumVitaeId,
        string newEmail, CancellationToken cancellationToken = default)
        {
            if (curriculumVitaeId > 0)
                _context.CurriculumVitaes.Where(e => e.Id == curriculumVitaeId)
                .ExecuteUpdate(b => b.SetProperty(e => e.Email, newEmail));
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
        public async Task<bool> AddOrEditCVsAsync(CurriculumVitae newCurriculumVitae, CancellationToken cancellationToken = default)
        {
            var existing = _context.CurriculumVitaes.Find(newCurriculumVitae.Id);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(newCurriculumVitae);
            }
            else
            {
                _context.Attach(newCurriculumVitae);
                _context.Entry(newCurriculumVitae).State = EntityState.Added;
            }

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> AddOrUpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken = default)
        {
            _context.Entry(employee).State = employee.Id == 0 ? EntityState.Added : EntityState.Modified;
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<Work> FindWorkByIdAsync(int workid, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Work>().FindAsync(workid);
        }

        public async Task<IList<Work>> GetWorkAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<Work> works = _context.Set<Work>();
            return await works
                .OrderBy(x => x.Name)
                .Select(x => new Work()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime
                })
                .ToListAsync(cancellationToken);
        }
        public async Task<bool> DeleteEmployeeAsync(int employeeId, CancellationToken cancellationToken = default)
        {
            var employee = await _context.Employee.FindAsync(employeeId);
            if (employee == null)
                return false;

            _context.Employee.Remove(employee);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> DeleteAllEmployeesAsync(CancellationToken cancellationToken = default)
        {
            var employees = await _context.Employee.ToListAsync(cancellationToken);
            if (employees == null || employees.Count == 0)
                return false;

            _context.Employee.RemoveRange(employees);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> DeleteEmployeesByNameAsync(string employeeName, CancellationToken cancellationToken = default)
        {
            var employees = await _context.Employee.Where(e => e.CurriculumVitae.Name == employeeName).ToListAsync(cancellationToken);
            if (employees == null || employees.Count == 0)
                return false;

            _context.Employee.RemoveRange(employees);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> DeleteEmployeesByWorkAsync(int workId, CancellationToken cancellationToken = default)
        {
            var employees = await _context.Employee.Where(e => e.WorkId == workId).ToListAsync(cancellationToken);
            if (employees == null || employees.Count == 0)
                return false;

            _context.Employee.RemoveRange(employees);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> DeleteEmployeesByPositionAsync(string position, CancellationToken cancellationToken = default)
        {
            //var employees = await _context.Employee.Where(e => e.Position == position).ToListAsync(cancellationToken);
            //if (employees == null || employees.Count == 0)
            //    return false;

            //_context.Employees.RemoveRange(employees);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
