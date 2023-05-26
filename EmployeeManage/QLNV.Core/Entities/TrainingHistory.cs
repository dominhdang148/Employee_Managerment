using QLNV.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV.Core.Entities
{
    public class TrainingHistory
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public string Result { get; set; }



    }
}
