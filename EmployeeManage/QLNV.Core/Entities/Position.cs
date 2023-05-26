using QLNV.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV.Core.Entities
{
   public class Position:IEntity

    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int SalaryId { get; set; }
        public Salary Salary { get; set; }
        public IList<Payroll> Payrolls { get; set; }


    }
}
