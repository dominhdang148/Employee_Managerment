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
        Task<IEnumerable<CurriculumVitae>> GetEmployeesByNameAsync(string name, CancellationToken cancellationToken = default);

        Task<IEnumerable<CurriculumVitae>> GetEmployeesByAddressAsync(string address, CancellationToken cancellationToken = default);

        Task<IEnumerable<CurriculumVitae>> GetEmployeesByEmailAsync(string age, CancellationToken cancellationToken = default);

        Task<IEnumerable<CurriculumVitae>> GetEmployeesByIdentityCardNumberAsync(string identityCardNumber, CancellationToken cancellationToken = default);

        Task<IEnumerable<CurriculumVitae>> GetEmployeesByJoinedDateAsync(string joinedDate, CancellationToken cancellationToken = default);
    }
}
