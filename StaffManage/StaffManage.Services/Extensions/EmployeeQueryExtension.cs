using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StaffManage.Services.Extensions
{
    public static class EmployeeQueryExtension
    {
        public static IQueryable<T> WhereIf<T>(
            this IQueryable<T> source,
            bool condition,
            Expression<Func<T, bool>> predicated)
        {
            if (condition)
            {
                return source.Where(predicated);
            }
            else
            {
                return source;
            }
        }
    }
}
