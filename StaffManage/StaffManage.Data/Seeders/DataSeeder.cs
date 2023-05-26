using StaffManage.Core.Entities;
using StaffManage.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace StaffManage.Data.Seeders
{
    ///*    public class DataSeeder */: IDataSeeder
    //    {
    //        private readonly StaffDbContext _dbContext;
    //        public DataSeeder(StaffDbContext dbContext)
    //        {
    //            _dbContext = dbContext;
    //        }
    //public void Initialize()
    //{
    //    _dbContext.Database.EnsureCreated();
    //    if (_dbContext.Employee.Any()) return;

    //    var department = AddDepartment();
    //    var salary = AddSalary();

    //}
    //private IList<Department> AddDepartment()
    //{
    //    var departments = new List<Department>()
    //    {
    //        new()
    //        {
    //            Name="Buồng Phòng"
    //        },
    //        new()
    //        {
    //            Name="Lễ tân"
    //        },
    //        new()
    //        {
    //            Name="Ẩm thực"
    //        },
    //        new()
    //        {
    //            Name="Tài chính - Kế toán"
    //        },
    //        new()
    //        {
    //            Name="Kinh doanh"
    //        },
    //    };
    //}
    //private IList<Salary> AddSalary()
    //{

    //}

    //}
    public class DataSeeder : IDataSeeder
    {
        private readonly StaffDbContext _dbContext;
        public DataSeeder(StaffDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Initialize()
        {
            _dbContext.Database.EnsureCreated();
            if (_dbContext.Employee.Any()) return;
            var works = AddWorks();

            var attendances = AddAttendances();
            var absences = AddAbsences();
            var qualifications = AddQualifications();
            var curriculumVitaes = AddCurriculumVitaes();
            //var trainingHistory = AddTrainingHistories();
            var employees = AddEmployees(works, attendances, absences, curriculumVitaes, qualifications);
        }
        private IList<Work> AddWorks()
        {
            var works = new List<Work>()
            {
                new()
                {
                    Name="Nhan vien",
                    Description="Nhan vien",
                    StartTime=new DateTime(2022,2,2),
                    EndTime=new DateTime(2022,4,4),
                    Status="Onl"
                },
                new()
                {
                    Name="Dich vu",
                    Description="dich vu",
                    StartTime=new DateTime(2022,3,2),
                    EndTime=new DateTime(2022,5,4),
                     Status="Onl"
                },
                new()
                {
                    Name="Ke toan",
                    Description="Ke toan",
                    StartTime=new DateTime(2022,3,2),
                    EndTime=new DateTime(2022,5,4),
                     Status="Onl"
                },
                new()
                {
                    Name="Le tan",
                    Description="Le tan",
                    StartTime=new DateTime(2022,3,2),
                    EndTime=new DateTime(2022,5,4),
                    Status="Onl"
                },
                new()
                {
                    Name="Bao ve",
                    Description="Clear_2",
                    StartTime=new DateTime(2022,3,2),
                    EndTime=new DateTime(2022,5,4),
                     Status="Onl"
                },
                new()
                {
                    Name="Giam doc",
                    Description="Clear_2",
                    StartTime=new DateTime(2022,3,2),
                    EndTime=new DateTime(2022,5,4),
                     Status="Onl"
                },
                new()
                {
                    Name="Thu ky",
                    Description="Thu ky",
                    StartTime=new DateTime(2022,3,2),
                    EndTime=new DateTime(2022,5,4),
                     Status="Onl"
                },
                new()
                {
                    Name="Tong giam doc",
                    Description="Tong giam doc",
                    StartTime=new DateTime(2022,3,2),
                    EndTime=new DateTime(2022,5,4),
                     Status="Onl"
                },
                new()
                {
                    Name="Ky thuat",
                    Description="Nhan vien ky thuat",
                    StartTime=new DateTime(2022,3,2),
                    EndTime=new DateTime(2022,5,4),
                     Status="Onl"
                },
                new()
                {
                    Name="quan ly",
                    Description="quan ly",
                    StartTime=new DateTime(2022,3,2),
                    EndTime=new DateTime(2022,5,4),
                     Status="Onl"
                }


            };
            _dbContext.Work.AddRange(works);
            _dbContext.SaveChanges();
            return works;
        }
        private IList<Attendance> AddAttendances()
        {
            var attendances = new List<Attendance>()
            {
                new()
                {
                    Month=1,
                    WorkDay=10,
                    OffDay=0
                },
                new()
                {
                    Month=5,
                    WorkDay=10,
                    OffDay=0
                },
                new()
                {
                    Month=10,
                    WorkDay=100,
                    OffDay=0
                }
            };
            _dbContext.Attendance.AddRange(attendances);
            _dbContext.SaveChanges();
            return attendances;
        }
        //private IList<TrainingHistory> AddTrainingHistories()
        //{
        //    var trainingHistories = new List<TrainingHistory>()
        //    {
        //        new()
        //        {

        //        },
        //        new()
        //        {
        //            Month=5,
        //            WorkDay=10,
        //            OffDay=0
        //        },
        //        new()
        //        {
        //            Month=10,
        //            WorkDay=100,
        //            OffDay=0
        //        }
        //    };
        //    _dbContext.Attendance.AddRange(attendances);
        //    _dbContext.SaveChanges();
        //    return attendances;
        //}
        private IList<Qualification> AddQualifications()
        {
            var qualifications = new List<Qualification>()
            {
                new()
                {
                   Name="THPT",
                   Type="ThPT",
                   IssuedDate=new DateTime(2001,7,7)
                },
                new()
                {
                   Name="Đai Hoc",
                   Type="Dai Hoc",
                   IssuedDate=new DateTime(2005,5,7)
                },
                new()
                {
                   Name="Thac si",
                   Type="Thac si",
                   IssuedDate=new DateTime(2000,7,12)
                },
                new()
                {
                   Name="Tien si",
                   Type="Tien si",
                   IssuedDate=new DateTime(2022,10,7)
                }
            };
            _dbContext.Qualification.AddRange(qualifications);
            _dbContext.SaveChanges();
            return qualifications;

        }
        private IList<Absence> AddAbsences()
        {
            var absences = new List<Absence>()
            {
                new()
                {
                   StartDate=new DateTime(2022,7,9),
                   EndDate=new DateTime(2022,8,10),
                   Reason="Reason_Test"
                },
                new()
                {
                   StartDate=new DateTime(2022,7,9),
                   EndDate=new DateTime(2022,8,10),
                   Reason="Reason_Test2"
                },
                new()
                {
                   StartDate=new DateTime(2022,7,9),
                   EndDate=new DateTime(2022,8,10),
                   Reason="Reason_Test3"
                },
                new()
                {
                   StartDate=new DateTime(2022,7,9),
                   EndDate=new DateTime(2022,8,10),
                   Reason="Reason_Test4"
                }
            };
            _dbContext.Absence.AddRange(absences);
            _dbContext.SaveChanges();
            return absences;

        }
        private IList<CurriculumVitae> AddCurriculumVitaes()

        {

            var curriculumVitaes = new List<CurriculumVitae>()
            {
                new()
                {
                    Name="Employee1",
                    Gender=true,
                    PortraitUrl="",
                    PhoneNumber="034444444",
                    DateOfBirth=new DateTime(2000,5,5),
                    IdentityCardNumber="1223444",
                    JoinedDate=new DateTime(2023,6,7),
                    Address="SG",
                    Email="@dlu.edu.vn"



                },
                new()
                {
                    Name="Employee2",
                    Gender=true,
                    PortraitUrl="",
                    PhoneNumber="034444444",
                    DateOfBirth=new DateTime(2000,5,5),
                    IdentityCardNumber="1223444",
                    JoinedDate=new DateTime(2023,6,7),
                    Address="SG",
                    Email="@dlu.edu.vn"



                },
                new()
                {
                    Name="Employee3",
                    Gender=true,
                    PortraitUrl="",
                    PhoneNumber="034444444",
                    DateOfBirth=new DateTime(2000,5,5),
                    IdentityCardNumber="1223444",
                    JoinedDate=new DateTime(2023,6,7),
                    Address="SG",
                    Email="@dlu.edu.vn"



                },new()
                {
                    Name="Employee4",
                    Gender=true,
                    PortraitUrl="",
                    PhoneNumber="034444444",
                    DateOfBirth=new DateTime(2000,5,5),
                    IdentityCardNumber="1223444",
                    JoinedDate=new DateTime(2023,6,7),
                    Address="SG",
                    Email="@dlu.edu.vn"



                },
                new()
                {
                    Name="Employee5",
                    Gender=true,
                    PortraitUrl="",
                    PhoneNumber="034444444",
                    DateOfBirth=new DateTime(2000,5,5),
                    IdentityCardNumber="1223444",
                    JoinedDate=new DateTime(2023,6,7),
                    Address="SG",
                    Email="@dlu.edu.vn"



                },
                new()
                {
                    Name="Employee6",
                    Gender=true,
                    PortraitUrl="",
                    PhoneNumber="034444444",
                    DateOfBirth=new DateTime(2000,5,5),
                    IdentityCardNumber="1223444",
                    JoinedDate=new DateTime(2023,6,7),
                    Address="SG",
                    Email="@dlu.edu.vn"



                },
                new()
                {
                    Name="Employee7",
                    Gender=true,
                    PortraitUrl="",
                    PhoneNumber="034444444",
                    DateOfBirth=new DateTime(2000,5,5),
                    IdentityCardNumber="1223444",
                    JoinedDate=new DateTime(2023,6,7),
                    Address="SG",
                    Email="@dlu.edu.vn"



                },
                new()
                {
                    Name="Employee8",
                    Gender=true,
                    PortraitUrl="",
                    PhoneNumber="034444444",
                    DateOfBirth=new DateTime(2000,5,5),
                    IdentityCardNumber="1223444",
                    JoinedDate=new DateTime(2023,6,7),
                    Address="SG",
                    Email="@dlu.edu.vn"



                },
                new()
                {
                    Name="Employee9",
                    Gender=true,
                    PortraitUrl="",
                    PhoneNumber="034444444",
                    DateOfBirth=new DateTime(2000,5,5),
                    IdentityCardNumber="1223444",
                    JoinedDate=new DateTime(2023,6,7),
                    Address="SG",
                    Email="@dlu.edu.vn"



                },
                new()
                {
                    Name="Employee10",
                    Gender=true,
                    PortraitUrl="",
                    PhoneNumber="034444444",
                    DateOfBirth=new DateTime(2000,5,5),
                    IdentityCardNumber="1223444",
                    JoinedDate=new DateTime(2023,6,7),
                    Address="SG",
                    Email="@dlu.edu.vn"



                }
            };
            _dbContext.CurriculumVitaes.AddRange(curriculumVitaes);
            _dbContext.SaveChanges();
            return curriculumVitaes;
        }
        private IList<Employee> AddEmployees(
             IList<Work> works,
              IList<Attendance> attendances,
               IList<Absence> absences,
                IList<CurriculumVitae> curriculumVitaes,
                 IList<Qualification> qualifications)

        {


            var employees = new List<Employee>()
            {
                new()
                {
                    Qualification=qualifications[0],
                    Absence=absences[0],
                    Attendance=attendances[0],
                    Work=works[0],
                    CurriculumVitae=curriculumVitaes[0]



                },
                 new()
                {
                    Qualification=qualifications[1],
                                        Absence=absences[1],
                    Attendance=attendances[0],
                    Work=works[1],
                    CurriculumVitae=curriculumVitaes[1]



                },
                  new()
                {
                                          Absence=absences[0],
                    Qualification=qualifications[3],
                    Attendance=attendances[0],
                    Work=works[0],
                    CurriculumVitae=curriculumVitaes[3]



                },
                   new()
                {
                                           Absence=absences[0],
                    Qualification=qualifications[0],
                    Attendance=attendances[0],
                    Work=works[5],
                    CurriculumVitae=curriculumVitaes[7]



                },
                    new()
                {
                                            Absence=absences[0],
                    Qualification=qualifications[2],
                    Attendance=attendances[0],
                    Work=works[2],
                    CurriculumVitae=curriculumVitaes[8]



                }

            };
            _dbContext.Employee.AddRange(employees);
            _dbContext.SaveChanges();
            return employees;
        }

    }
}
