using StaffManage.Core.Entities;
using StaffManage.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManage.Services.Manager
{
    class StaffRepository : IStaffRepository
    {
        private readonly StaffDbContext _context;
        public StaffRepository(StaffDbContext context) => _context = context;

        // Code truy vấn ở đây
        // Tìm nhân viên
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
                _context.CurriculumVitae.Update(curriculumVitae);

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> UpdateNameAsync(int curriculumVitaeId,
		string newName, CancellationToken cancellationToken = default)
        {
            if (curriculumVitaeId > 0)
                _context.CurriculumVitae.Where(e=>e.Id == curriculumVitaeId)
                .ExecuteUpdate(b => b.SetProperty(e=>e.Name,newName));
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> UpdateGenderAsync(int curriculumVitaeId, CancellationToken cancellationToken = default)
        {
            if (curriculumVitaeId > 0){
                var curriculumVitaes = _context.CurriculumVitae.ToList();
                foreach(var curriculumVitae in curriculumVitaes){
                    if(curriculumVitae.Id == curriculumVitaeId){
                        curriculumVitae.Gender = !curriculumVitae.Gender;
                        _context.CurriculumVitae.Update(curriculumVitae);
                    }
                }
            }
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> UpdateBirthdateAsync(int curriculumVitaeId,
		DateTime newBirthDate, CancellationToken cancellationToken = default)
        {
            if (curriculumVitaeId > 0)
                _context.CurriculumVitae.Where(e=>e.Id == curriculumVitaeId)
                .ExecuteUpdate(b => b.SetProperty(e=>e.DateOfBirth,newBirthDate));
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
        
        public async Task<bool> UpdateJoinedDateAsync(int curriculumVitaeId,
		DateTime newJoinedDate, CancellationToken cancellationToken = default)
        {
            if (curriculumVitaeId > 0)
                _context.CurriculumVitae.Where(e=>e.Id == curriculumVitaeId)
                .ExecuteUpdate(b => b.SetProperty(e=>e.JoinedDate,newJoinedDate));
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> UpdateImgUrlAsync(int curriculumVitaeId,
		string newUrl, CancellationToken cancellationToken = default)
        {
            if (curriculumVitaeId > 0)
                _context.CurriculumVitae.Where(e=>e.Id == curriculumVitaeId)
                .ExecuteUpdate(b => b.SetProperty(e=>e.PortraitUrl,newUrl));
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> UpdatePhoneNumberAsync(int curriculumVitaeId,
		string newPhoneNumber, CancellationToken cancellationToken = default)
        {
            if (curriculumVitaeId > 0)
                _context.CurriculumVitae.Where(e=>e.Id == curriculumVitaeId)
                .ExecuteUpdate(b => b.SetProperty(e=>e.PhoneNumber,newPhoneNumber));
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> UpdateCCCDAsync(int curriculumVitaeId,
		string newCCCD, CancellationToken cancellationToken = default)
        {
            if (curriculumVitaeId > 0)
                _context.CurriculumVitae.Where(e=>e.Id == curriculumVitaeId)
                .ExecuteUpdate(b => b.SetProperty(e=>e.IdentityCardNumber,newCCCD));
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> UpdateAddressAsync(int curriculumVitaeId,
		string newAddress, CancellationToken cancellationToken = default)
        {
            if (curriculumVitaeId > 0)
                _context.CurriculumVitae.Where(e=>e.Id == curriculumVitaeId)
                .ExecuteUpdate(b => b.SetProperty(e=>e.Address,newAddress));
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
        public async Task<bool> UpdateEmailAsync(int curriculumVitaeId,
		string newEmail, CancellationToken cancellationToken = default)
        {
            if (curriculumVitaeId > 0)
                _context.CurriculumVitae.Where(e=>e.Id == curriculumVitaeId)
                .ExecuteUpdate(b => b.SetProperty(e=>e.Email,newEmail));
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
