using StaffManage.Core.DTO;
using StaffManage.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManage.Services.Manager
{
    public interface IStaffRepository
    {

        Task<bool> UpdateCvAsync(
        CurriculumVitae curriculumVitae, CancellationToken cancellationToken = default);
        Task<bool> UpdateNameAsync(int curriculumVitaeId,
        string newName, CancellationToken cancellationToken = default);
        Task<bool> UpdateGenderAsync(int curriculumVitaeId, CancellationToken cancellationToken = default);
        Task<bool> UpdateBirthdateAsync(int curriculumVitaeId,
        DateTime newBirthDate, CancellationToken cancellationToken = default);
        Task<bool> UpdateJoinedDateAsync(int curriculumVitaeId,
        DateTime newJoinedDate, CancellationToken cancellationToken = default);
        Task<bool> UpdateImgUrlAsync(int curriculumVitaeId,
                string newUrl, CancellationToken cancellationToken = default);
        Task<bool> UpdatePhoneNumberAsync(int curriculumVitaeId,
		string newPhoneNumber, CancellationToken cancellationToken = default);
        Task<bool> UpdateCCCDAsync(int curriculumVitaeId,
		string newCCCD, CancellationToken cancellationToken = default);
        Task<bool> UpdateAddressAsync(int curriculumVitaeId,
		string newAddress, CancellationToken cancellationToken = default);
        Task<bool> UpdateEmailAsync(int curriculumVitaeId,
		string newEmail, CancellationToken cancellationToken = default);




        Task<Work> FindWorkByIdAsync(int wordid, CancellationToken cancellationToken = default);
        Task<IList<WorkItem>> GetWorkAsync(CancellationToken cancellationToken = default);

        Task<bool> AddOrEditCVsAsync(CurriculumVitae newcurriculumVitae, CancellationToken cancellationToken = default);


        Task<bool> AddOrUpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken = default);

    }
}
