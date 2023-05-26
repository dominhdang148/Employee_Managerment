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
        Task<IEnumerable<Employee>> GetEmployeesByNameAsync(string name, CancellationToken cancellationToken = default);

        Task<IEnumerable<Employee>> GetEmployeesByAddressAsync(string address, CancellationToken cancellationToken = default);

        Task<IEnumerable<Employee>> GetEmployeesByAgeAsync(string age, CancellationToken cancellationToken = default);

        Task<IEnumerable<Employee>> GetEmployeesByJobAsync(string job, CancellationToken cancellationToken = default);

        Task<IEnumerable<Employee>> GetEmployeesByTimeOfWorkAsync(string timeOfWork, CancellationToken cancellationToken = default);
    }
}
