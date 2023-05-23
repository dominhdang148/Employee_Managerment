using QLNV.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV.Core.Entities
{
    public class Salary:IEntity
    {
        public int Id { get; set; }
        public float Basic { get; set; }
        public float Bonus { get; set; }
        public float Amount { get; set; }
        public int Coefficient { get; set; }
        public float Deduction { get; set; }
        public IList<Position> Positions { get; set; }



    }
}
