using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaffManage.Core.Entities;

namespace StaffManage.Services.Manager
{
    interface IStaffRepository
    {
        // Code truy vấn ở đây
        Task<IEnumerable<EmployeeInfo>> GetEmployeesByNameAsync(string name, CancellationToken cancellationToken = default);

        Task<IEnumerable<EmployeeInfo>> GetEmployeesByAddressAsync(string address, CancellationToken cancellationToken = default);

        Task<IEnumerable<EmployeeInfo>> GetEmployeesByAgeAsync(string age, CancellationToken cancellationToken = default);

        Task<IEnumerable<EmployeeInfo>> GetEmployeesByJobAsync(string job, CancellationToken cancellationToken = default);

        Task<IEnumerable<EmployeeInfo>> GetEmployeesByTimeOfWorkAsync(string timeOfWork, CancellationToken cancellationToken = default);
    }
}
