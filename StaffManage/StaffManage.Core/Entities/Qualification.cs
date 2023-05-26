using StaffManage.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManage.Core.Entities
{
    public class Qualification : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime IssuedDate { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}
