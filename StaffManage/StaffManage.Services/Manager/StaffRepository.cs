﻿using Microsoft.EntityFrameworkCore;
using StaffManage.Core.DTO;
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
        public  StaffRepository(StaffDbContext context) => _context = context;

        // Code truy vấn ở đây

<<<<<<< HEAD
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
=======
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

        public async Task<IList<WorkItem>> GetWorkAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<Work> works = _context.Set<Work>();
            return await works
                .OrderBy(x => x.Name)
                .Select(x => new WorkItem()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime
                })
                .ToListAsync(cancellationToken);
>>>>>>> origin/SonV4
        }
    }

   
}
