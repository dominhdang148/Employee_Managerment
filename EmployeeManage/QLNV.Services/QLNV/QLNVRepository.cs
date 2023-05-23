using Microsoft.EntityFrameworkCore;
using QLNV.Core.DTO;
using QLNV.Core.Entities;
using QLNV.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV.Services.QLNV
{
    public class QLNVRepository:IQLNVRepository
    {
        private readonly StaffDbContext _context;

        public QLNVRepository(StaffDbContext context)
        {
            _context = context;
        }

        //public async Task<bool> AddOrEditCategoryAsync(CurriculumVitae newCurriculumVitae, CancellationToken cancellationToken = default)
        //{
        //    _context.Entry(newCurriculumVitae).State = newCurriculumVitae.Id == 0 ? EntityState.Added : EntityState.Modified;
        //    return await _context.SaveChangesAsync(cancellationToken) > 0;
        //}
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
            IQueryable<Work> works=_context.Set<Work>();
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
        }
    }
}
