using System;
using System.Collections.Generic;
using System.Text;
using Final_Project.Services;
using Final_Project.Entities;
using Final_Project.Services.Interfaces;
using Final_Project.Utilities.Scheduling;

namespace Final_Project.Users
{
	abstract public class User
	{

		protected Guid Id;
		protected string firstName;
		protected string lastName;
		protected string email;
		protected List<Guid> applicantIds;
		protected Schedule userSchedule;
		protected IDataService _dataService;

		public User(UserEntity user, IDataService dataService)
        {
			Id = user.id;
			firstName = user.FirstName;
			lastName = user.LastName;
			email = user.Email;
			applicantIds = new List<Guid>();
			userSchedule = new Schedule();
			_dataService = dataService;

		}

		public abstract void acceptApplicant(Guid applicantId);
		public void rejectApplicant(Guid applicantId)
        {
			_dataService.deleteApplicant(applicantId);
		}

		public void scheduleMeeting(Guid userId, DateTime startDate, DateTime endDate)
		{
			TimeSlot time = new TimeSlot(startDate, endDate);
			time.addInvite(userId);
			userSchedule.addEvent(time);
		}

		public bool applicantInList(Guid applicantId)
		{
			return applicantIds.Contains(applicantId);

		}

		public void removeApplicantFromList(Guid applicantId)
		{
			applicantIds.Remove(applicantId);
			//delete applicant from search list
		}

		public void addApplicantToList(Guid applicantId)
        {
			applicantIds.Add(applicantId);
        }

		public string getName()
        {
			return firstName + " " + lastName;
        }

	}

}



