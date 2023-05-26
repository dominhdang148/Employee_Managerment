﻿using Microsoft.EntityFrameworkCore;
using QLNV.Core.DTO;
using QLNV.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV.Services.QLNV
{
    public interface IQLNVRepository
    {
        Task<Work> FindWorkByIdAsync(int wordid, CancellationToken cancellationToken = default);
        Task<IList<WorkItem>>GetWorkAsync(CancellationToken cancellationToken = default);
        
        Task<bool> AddOrEditCVsAsync(CurriculumVitae newcurriculumVitae, CancellationToken cancellationToken = default);


       Task<bool> AddOrUpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken = default);
       
    }
}
