using StaffManage.Core.Contracts;

namespace StaffManage.Core.Entities
{
    public class Absence : IEntity
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public IList<Employee> Employees { get; set; }
        
    }
}
