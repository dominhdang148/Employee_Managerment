using Microsoft.EntityFrameworkCore;
using StaffManage.Core.Constants;
using StaffManage.Core.DTO;
using StaffManage.Core.Entities;
using StaffManage.Data.Contexts;
using StaffManage.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StaffManage.Services.Manager
{
    public class StaffRepository : IStaffRepository
    {
        private readonly StaffDbContext _context;
        public StaffRepository(StaffDbContext context) => _context = context;
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

        public async Task<IList<CVItem>> GetCVAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<CurriculumVitae> cvs = _context.Set<CurriculumVitae>();
            return await cvs
                .OrderBy(x => x.Name)
                .Select(x => new CVItem()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Gender = x.Gender,
                    PortraitUrl = x.PortraitUrl,
                    PhoneNumber = x.PhoneNumber,
                    DateOfBirth = x.DateOfBirth,
                    IdentityCardNumber = x.IdentityCardNumber,
                    JoinedDate = x.JoinedDate,
                    Address = x.Address,
                    Email = x.Email
                })
                .ToListAsync(cancellationToken);
        }

        public async Task<IList<QualificationItem>> GetQualificationAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<Qualification> qualifications = _context.Set<Qualification>();

            return await qualifications
                .OrderBy(x => x.Name)
                .Select(x => new QualificationItem()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    IssuedDate = x.IssuedDate,
                })
                .ToListAsync(cancellationToken);
        }

        public IQueryable<Employee> FilterEmployee(EmployeeQuery condition)
        {
            return _context.Set<Employee>()
                .Include(q => q.Qualification)
                .Include(a => a.Attendance)
                .Include(w => w.Work)
                .Include(c => c.CurriculumVitae)
                .Include(a => a.Absence)
                .WhereIf(condition.CVId > 0, p => p.CurriculumVitaeId == condition.CVId)
                .WhereIf(condition.QualificationId > 0, p => p.QualificationId == condition.QualificationId)
                .WhereIf(condition.AttendanceId > 0, p => p.AttendanceId == condition.AttendanceId)
                .WhereIf(condition.WorkId > 0, p => p.WorkId == condition.WorkId)
                .WhereIf(condition.AbsenceId > 0, p => p.AbsenceId == condition.AbsenceId)
                .WhereIf(!string.IsNullOrWhiteSpace(condition.Keyword), e => e.CurriculumVitae.Name.ToLower().Contains(condition.Keyword.ToLower()));

        }

        public async Task<IList<Employee>> GetFilteredEmployeesAsync(EmployeeQuery condition, CancellationToken cancellationToken = default)
        {
            return await FilterEmployee(condition)
                .ToListAsync(cancellationToken);
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            if (!includeDetails)
            {
                return await _context.Set<Employee>().FindAsync(id);
            }
            return await _context.Set<Employee>()
                .Include(x => x.Qualification)
                .Include(x => x.Absence)
                .Include(x => x.CurriculumVitae)
                .Include(x => x.Attendance)
                .Include(x => x.Work)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
