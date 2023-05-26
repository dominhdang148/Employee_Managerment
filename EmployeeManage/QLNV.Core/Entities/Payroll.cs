using QLNV.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV.Core.Entities
{
    public class Payroll : IEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TotalAmount { get; set; }
        public int Penalty { get; set; }
        public int Completment { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public IList<Contract> Contracts { get; set; }

    }
}
