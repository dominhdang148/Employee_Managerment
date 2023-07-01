using StaffManage.Services.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManage.Test
{
    public class QualificationTest : ATest
    {
        [Fact]
        public async Task GetQualificationsAsync()
        {
            IStaffRepository staffRepository = new StaffRepository(_context);
            var qualifications = await staffRepository.GetQualificationAsync();
            Assert.NotEmpty(qualifications);
        }
    }
}
