using System;
using System.Collections.Generic;
using System.Text;

namespace Timelogger.Entities
{
	public class Week
	{
		public int Id { get; set; }
		public int ProjectId { get; set; }
		public int WeekNr { get; set; }
		public IEnumerable<Day> Days { get; set; }

	}
}
