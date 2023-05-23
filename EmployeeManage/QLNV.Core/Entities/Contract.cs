using QLNV.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV.Core.Entities
{
    public class Contract:IEntity
    {
        public int Id { get; set; }
        public string TermOfServices { get; set; }
        public string Partner { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public int PayrollId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Payroll Payroll { get; set; }


    }
}
