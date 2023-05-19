using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Services.Employees
{
    public interface ICvRepository
    {
        Task<bool> UpdateAsync(
        Employee employee,
        CancellationToken cancellationToken = default);

        Task<bool> UpdateNameAsync(
        int employeeId, string newName,
        CancellationToken cancellationToken = default);
    }
}