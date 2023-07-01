using StaffManage.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManage.Core.DTO
{
    public class CVItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public string PortraitUrl { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdentityCardNumber { get; set; }
        public DateTime JoinedDate { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public Employee Employee { get; set; }
    }
}
