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

		/// <summary>
		/// Xóa toàn bộ nhân viên.
		/// </summary>
		/// <param name="cancellationToken">Token hủy (tùy chọn)</param>
		public async Task DeleteAllEmployeesAsync(CancellationToken cancellationToken = default)
		{
			var allEmployees = await _context.Employee.ToListAsync(cancellationToken);

			_context.Employee.RemoveRange(allEmployees);
			await _context.SaveChangesAsync(cancellationToken);
		}

		/// <summary>
		/// Xóa nhân viên theo tên.
		/// </summary>
		/// <param name="name">Tên nhân viên</param>
		/// <param name="cancellationToken">Token hủy (tùy chọn)</param>
		public async Task DeleteEmployeesByNameAsync(string name, CancellationToken cancellationToken = default)
		{
			var employeesToDelete = await _context.Employee.Where(e => e.CurriculumVitae.Name == name).ToListAsync(cancellationToken);

			_context.Employee.RemoveRange(employeesToDelete);
			await _context.SaveChangesAsync(cancellationToken);
		}

		/// <summary>
		/// Xóa các nhân viên cùng công việc.
		/// </summary>
		/// <param name="workId">ID công việc</param>
		/// <param name="cancellationToken">Token hủy (tùy chọn)</param>
		public async Task DeleteEmployeesByWorkAsync(int workId, CancellationToken cancellationToken = default)
		{
			var employeesToDelete = await _context.Employee.Where(e => e.WorkId == workId).ToListAsync(cancellationToken);

			_context.Employee.RemoveRange(employeesToDelete);
			await _context.SaveChangesAsync(cancellationToken);
		}

		/// <summary>
		/// Xóa các nhân viên cùng chức vụ.
		/// </summary>
		/// <param name="positionId">ID chức vụ</param>
		/// <param name="cancellationToken">Token hủy (tùy chọn)</param>
		public async Task DeleteEmployeesByPositionAsync(int positionId, CancellationToken cancellationToken = default)
		{
			var employeesToDelete = await _context.Employee.Where(e => e.PositionId == positionId).ToListAsync(cancellationToken);

			_context.Employee.RemoveRange(employeesToDelete);
			await _context.SaveChangesAsync(cancellationToken);
		}
	}
}
