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
    }
}
