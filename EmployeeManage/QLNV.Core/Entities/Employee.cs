using QLNV.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV.Core.Entities
{
    public class Employee:IEntity
    {
        public int Id { get; set; }
		public string Name { get; set; }
		public int QualificationId { get; set; }
        public Qualification Qualification { get; set; }
        public int AttendanceId { get; set; }
        public Attendance Attendance { get; set; }
        public int WorkId { get; set; }
        public Work Work { get; set; }
        public int CurriculumVitaeId { get; set; }
        public CurriculumVitae CurriculumVitae { get; set; }
        public int AbsenceId { get; set; }
        public Absence Absence { get; set; }

		public string Position { get; set; }
		public IList<Contract> Contracts { get; set; }
        public IList<TrainingHistory> TrainingHistories { get; set; }


    }
}
