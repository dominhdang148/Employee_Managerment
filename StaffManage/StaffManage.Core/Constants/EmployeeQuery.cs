using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManage.Core.Constants
{
    public class EmployeeQuery
    {
        public int? Id { get; set; }
        public int? QualificationId { get; set; }
        public int? AttendanceId { get; set; }
        public int? WorkId { get; set; }
        public int? CVId { get; set; }
        public int? AbsenceId { get; set; }
        public string Keyword { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
