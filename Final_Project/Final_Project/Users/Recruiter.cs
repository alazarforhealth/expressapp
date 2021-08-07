using System;
using System.Collections.Generic;
using System.Text;
using Final_Project.Entities;
using Final_Project.Services.Interfaces;

namespace Final_Project.Users
{
	public class Recuriter : User
    { 

		public Recuriter(UserEntity user, IDataService dataService): base(user, dataService)
		{
		}
        public override void acceptApplicant(Guid applicantId)
        {
            var applicant = _dataService.getApplicant(applicantId);
            applicant.AcceptedByRecuriter = true;
            _dataService.updateApplicant(applicant);
        }


    }
}
