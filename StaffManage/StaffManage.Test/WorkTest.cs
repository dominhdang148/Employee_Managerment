using StaffManage.Services.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManage.Test
{
    public class WorkTest : ATest
    {
        [Fact]
        public async Task GetWorksAsync()
        {
            IStaffRepository staff = new StaffRepository(_context);
            var works = await staff.GetWorkAsync();
            Assert.NotEmpty(works);
        }
        [Fact]
        public async void GetWorkByIdAsync()
        {
            IStaffRepository staff = new StaffRepository(_context);
            var works = await staff.GetWorkAsync();
            int id = works[0].Id;
            var work = await (staff.FindWorkByIdAsync(id));

            Assert.Equal(id, work.Id);
        }
    }
}
