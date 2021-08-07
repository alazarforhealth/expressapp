using System;
using System.Collections.Generic;
using System.Text;
using Final_Project.Entities;
using Final_Project.Users;
using Final_Project.Utilities.Enums;

namespace Final_Project.Services.Interfaces
{
    public interface IDataService
    {
        UserEntity getUser(Guid userId);

        ApplicantEntity getApplicant(Guid applicantId);

        void updateApplicant(ApplicantEntity applicant);
        void acceptApplicant(Guid applicantId);
        void deleteApplicant(Guid applicantId);

        List<ApplicantEntity> search(string fname, string lname, JobTypeEnum job);

        Guid login(string username, string password);

    }
}
