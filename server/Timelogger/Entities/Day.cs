using System;
using System.ComponentModel.DataAnnotations;

namespace Timelogger.Entities
{
	public class Day
	{
		public int Id { get; set; }
		[Required]
		public int WeekId { get; set; }
		[Required]
		public DayOfWeek DayOfWeek { get; set; }
		private double hours;
		public double Hours 
		{
            get { return this.hours; }
			
			set 
			{
				if ((value < 0.5) || (value > 10))
					throw new Exception("Hours applied is not between 0.5 and 10!");

				this.hours = value;
			} 
		}
	}

	public enum DayOfWeek
	{
		MONDAY,
		TUESDAY,
		WEDNESDAY,
		THURSDAY,
		FRIDAY,
		SATURDAY,
		SUNDAY
	}
}
