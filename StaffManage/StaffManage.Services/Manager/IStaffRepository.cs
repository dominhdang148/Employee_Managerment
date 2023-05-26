using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManage.Services.Manager
{
    interface IStaffRepository
    {
		// Code truy vấn ở đây
		Task DeleteEmployeesByPositionAsync(int positionId, CancellationToken cancellationToken = default);
		Task DeleteEmployeesByWorkAsync(int workId, CancellationToken cancellationToken = default);
		Task DeleteEmployeesByNameAsync(string name, CancellationToken cancellationToken = default);
		Task DeleteAllEmployeesAsync(CancellationToken cancellationToken = default);


	}
}
