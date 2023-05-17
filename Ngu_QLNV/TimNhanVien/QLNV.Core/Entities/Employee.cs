

using QLNV.Core.Contracts;


namespace TatBlog.Core.Entities;

public class Employee : IEntity
{
    public int Id { get; set; }

    public string FullName { get; set; }

    public string Gender { get; set; }

    public string Age { get; set; }

    public string Job { get; set; }

    public string TimeOfWork { get; set; }

    public string ImageUrl { get; set; }

    public string Phone { get; set; }

    public DateTime Birthday { get; set; }

    public string Resident_ID { get; set; }

    public DateTime JoinedDate { get; set; }

    public string Email { get; set; }

    public string Address { get; set; }

}
