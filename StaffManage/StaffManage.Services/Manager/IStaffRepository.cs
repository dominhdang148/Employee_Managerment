﻿using Microsoft.EntityFrameworkCore;
using StaffManage.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManage.Services.Manager
{
	public interface IStaffRepository
	{
		Task<Work> FindWorkByIdAsync(int wordid, CancellationToken cancellationToken = default);
		Task<IList<Work>> GetWorkAsync(CancellationToken cancellationToken = default);

		Task<bool> AddOrEditCVsAsync(CurriculumVitae newcurriculumVitae, CancellationToken cancellationToken = default);


		Task<bool> AddOrUpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken = default);

		Task<bool> DeleteEmployeeAsync(int employeeId, CancellationToken cancellationToken = default);
		Task<bool> DeleteAllEmployeesAsync(CancellationToken cancellationToken = default);
		Task<bool> DeleteEmployeesByNameAsync(string employeeName, CancellationToken cancellationToken = default);
		Task<bool> DeleteEmployeesByWorkAsync(int workId, CancellationToken cancellationToken = default);
		Task<bool> DeleteEmployeesByPositionAsync(string position, CancellationToken cancellationToken = default);
	}
}
