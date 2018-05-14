using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Models.Domain
{
	public class Sessie
	{

		//private Group _selectedGroup;


		public int SessionCode { get; private set; }
		public String Name { get; private set; }
		public String Desc { get; private set; }
		public DateTime DayStarted { get; private set; }
		public Boolean IsDayEducation { get; private set; }
		public Boolean HasFeedback { get; private set; }
		public Group Groups { get; private set; }
		//public Group SelectedGroup { get; set; }
		public Session_Group SessionGroup { get; set; }
		public BoB Box { get; set; }
		public Boolean IsActive { get; set; }
		public Boolean HasStarted { get; set; }

		public Sessie()
		{
            //Groups = new List<Group>();
		}

		public Sessie(String name, String desc, DateTime dayStarted, Boolean isDayEducation, Boolean hasFeedback) : this()
		{
            this.Name = name;
            this.Desc = desc;
            this.DayStarted = dayStarted;
            this.IsDayEducation = isDayEducation;
            this.HasFeedback = hasFeedback;
            this.IsActive = false;
            this.SessionCode = 10;
        }
		public Sessie(String name, String desc, DateTime dayStarted, Boolean isDayEducation, Boolean hasFeedback, IEnumerable<Group> groups, BoB bob) : this()
		{

		}

	}
}
