﻿using StaffManage.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManage.Core.DTO
{
    public class QualificationItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime IssuedDate { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}
