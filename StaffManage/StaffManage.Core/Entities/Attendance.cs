using StaffManage.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManage.Core.Entities
{
    public class Attendance : IEntity
    {
        public int Id { get; set; }
        public int Month { get; set; }  
        public int WorkDay { get; set; }
        public int OffDay { get; set; } 
        public IList<Employee> Employees { get; set; }
    }
}
