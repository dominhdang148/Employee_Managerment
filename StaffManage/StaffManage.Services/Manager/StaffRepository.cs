using Microsoft.EntityFrameworkCore;
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
