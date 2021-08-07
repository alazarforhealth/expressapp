using Final_Project.Entities;
using Final_Project.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project.Users
{
    class Manager: User
    {
        public Manager(UserEntity user, IDataService dataService) : base(user, dataService)
        {
        }
        public void acceptApplicant(string applicantId)
        {
            throw new NotImplementedException();
        }
    }
}
