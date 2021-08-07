using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project.Utilities.Scheduling
{
	public class Schedule
	{
		private SortedSet<TimeSlot> _bookedTimes;
		private SortedSet<TimeSlot> _freeTimes;


        Schedule()
        {
			_bookedTimes = new SortedSet<TimeSlot>();
			_freeTimes = new SortedSet<TimeSlot>();
		}

		public void addEvent(TimeSlot newEvent)
		{
			foreach (var time in _freeTimes)
			{
				if(DateTime.Compare(time.getStartDate() ,newEvent.getStartDate()) <= 0  && DateTime.Compare(time.getEndDate(), newEvent.getEndDate()) >= 0) 
				{
					_bookedTimes.Add(newEvent);
                    if (time.getStartDate() != newEvent.getStartDate())
                    {
						_freeTimes.Add(new TimeSlot(time.getStartDate(), newEvent.getStartDate()));
					}
					if (time.getEndDate() != newEvent.getEndDate())
					{

						_freeTimes.Add(new TimeSlot(time.getEndDate(), newEvent.getEndDate()));
					}
					_freeTimes.Remove(time);
					
					return;
				}

				// throw exception?
			}
		}

		public void deleteEvent(TimeSlot oldEvent)
		{
            foreach (var time in _bookedTimes)
            {
                if (time.getStartDate().Equals(oldEvent.getStartDate()))
                {
					_bookedTimes.Remove(time);
                }

				//throw exception?
            }
		}
	}
}
