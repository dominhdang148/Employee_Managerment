
using Microsoft.EntityFrameworkCore;
using TatBlog.Core.Entities;

namespace TatBlog.Services.Blogs;

public interface IBlogRepository
{
    Task<IEnumerable<Employee>> GetEmployeesByNameAsync(string name, CancellationToken cancellationToken = default);

    Task<IEnumerable<Employee>> GetEmployeesByAddressAsync(string address, CancellationToken cancellationToken = default);

    Task<IEnumerable<Employee>> GetEmployeesByAgeAsync(string age, CancellationToken cancellationToken = default);

    Task<IEnumerable<Employee>> GetEmployeesByJobAsync(string job, CancellationToken cancellationToken = default);

    Task<IEnumerable<Employee>> GetEmployeesByTimeOfWorkAsync(string timeOfWork, CancellationToken cancellationToken = default);
}

