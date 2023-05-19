using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Contracts;

namespace Core.Entities
{
    public class Employee:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public string? PortraitUrl { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? IdentityCardNumber { get; set; }
        public string? Address { get; set; }
    }
}