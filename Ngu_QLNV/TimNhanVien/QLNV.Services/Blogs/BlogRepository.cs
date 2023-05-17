using System;
using Microsoft.EntityFrameworkCore;
using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;

namespace TatBlog.Services.Blogs;

public class BlogRepository : IBlogRepository
{
    private readonly BlogDbContext _context;
    private BlogDbContext context;

    public BlogRepository(BlogRepository context) => _context = context;

    public BlogRepository(BlogDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Employee>> GetEmployeesByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await _context.Employees.Where(e => e.FullName == name).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Employee>> GetEmployeesByAddressAsync(string address, CancellationToken cancellationToken = default)
    {
        return await _context.Employees.Where(e => e.Address == address).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Employee>> GetEmployeesByAgeAsync(string age, CancellationToken cancellationToken = default)
    {
        return await _context.Employees.Where(e => e.Age == age).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Employee>> GetEmployeesByJobAsync(string job, CancellationToken cancellationToken = default)
    {
        return await _context.Employees.Where(e => e.Job == job).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Employee>> GetEmployeesByTimeOfWorkAsync(string timeOfWork, CancellationToken cancellationToken = default)
    {
        return await _context.Employees.Where(e => e.TimeOfWork == timeOfWork).ToListAsync(cancellationToken);
    }
}
