using StaffManage.Core.Contracts;

namespace StaffManage.Core.Entities
{
    public class Work : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}
