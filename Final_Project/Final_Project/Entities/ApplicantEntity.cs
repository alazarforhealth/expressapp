using System;
using System.Collections.Generic;
using System.Text;
using Final_Project.Utilities.Enums;

namespace Final_Project.Entities
{
	public class ApplicantEntity
	{
		public Guid id { get; set; }
		public string SSN { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Address { get; set; }
		public JobTypeEnum JobPosition { get; set; }
		public string LinkedInUrl { get; set; }
		public string PortifolioUrl { get; set; }
		public string ResumeUrl { get; set; }

		public bool AcceptedByRecuriter { get; set; }

		public bool AcceptedByManager { get; set; }

	}
}
