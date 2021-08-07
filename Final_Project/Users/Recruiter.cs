using System;
using System.Collections.Generic;
using System.Text;
using Final_Project.Entities;
using Final_Project.Services.Interfaces;

namespace Final_Project.Users
{
	public class Recuriter : User
	{
		private List<Guid> managerIds;

		public Recuriter(UserEntity user, IDataService dataService): base(user, dataService)
		{
		}
		public void assignManager(string applicantId, string managerId)
		{
			throw new NotImplementedException();
		}
	}
}
