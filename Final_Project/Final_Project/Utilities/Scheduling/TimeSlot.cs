using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Final_Project.Utilities.Scheduling
{
	public class TimeSlot: IComparer<TimeSlot>
	{
		private DateTime _startDate;
		private DateTime _endDate;
        private Guid _userId;

        public TimeSlot(DateTime startDate, DateTime endDate)
        {
			_startDate = startDate;
			_endDate = endDate;
        }

		public DateTime getStartDate()
		{
			return _startDate;
		}

		public DateTime getEndDate()
		{
			return _endDate;
		}

		public void addInvite(Guid userId)
        {
			_userId = userId;
        }

		public Guid getInvitee()
		{
			return _userId;
		}


		public int Compare(TimeSlot a, TimeSlot b) {
            if (DateTime.Compare(a.getStartDate(), b.getStartDate()) < 0)
            {
				return -1;
            }
			else if (DateTime.Compare(a.getStartDate(), b.getStartDate()) == 0)
            {
				return 0;
            }
            else
            {
				return 1;
            }
		}
	}
}
