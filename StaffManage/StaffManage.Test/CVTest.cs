using Microsoft.Identity.Client;
using StaffManage.Core.Entities;
using StaffManage.Data.Contexts;
using StaffManage.Services.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManage.Test
{
    public class CVTest : ATest
    {
        [Fact]
        public void GetAllCV()
        {
            IStaffRepository staffRepository = new StaffRepository(_context);
            var cvs = staffRepository.GetCVAsync();
            Assert.NotNull(cvs);
        }
        [Fact]
        public async Task AddCVAsync()
        {
            IStaffRepository staff = new StaffRepository(_context);
            var cv = new CurriculumVitae()
            {
                Name = "Test",
                Gender = true,
                DateOfBirth = DateTime.Now,
                Address = "DL",
                Email = "test@email.com",
                IdentityCardNumber = "47823432",
                PhoneNumber = "021372384"
            };

            var result = await staff.AddOrEditCVsAsync(cv);

            Assert.True(result);
        }
    }
}
