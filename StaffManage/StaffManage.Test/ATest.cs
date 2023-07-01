using StaffManage.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManage.Test
{
    public abstract class ATest
    {
        protected StaffDbContext _context = new StaffDbContext();
    }
}
