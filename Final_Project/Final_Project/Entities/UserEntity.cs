using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project.Entities
{
	public class UserEntity
	{
		public Guid id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public bool Recuriter{ get; set; }
		public string username { get; set; }
		public string password { get; set; }

	}
}
