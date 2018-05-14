using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Models.Domain
{
	public class Sessie
	{

		//private Group _selectedGroup;


		public int SessionCode { get; set; }
		public String Name { get;  set; }
		public String Desc { get; set; }
		public DateTime DayStarted { get; set; }
		public Boolean IsDayEducation { get; set; }
		public Boolean HasFeedback { get; set; }
		public ICollection<Group> Groups { get; set; }
		//public Group SelectedGroup { get; set; }
		public Session_Group SessionGroup { get; set; }
		public BoB Box { get; set; }
		public Boolean IsActive { get; set; }
		public Boolean HasStarted { get; set; }

		public Sessie()
		{
            Groups = new List<Group>();
		}

		public Sessie(String name, String desc, DateTime dayStarted, Boolean isDayEducation, Boolean hasFeedback, int sessionCode) : this()
		{
            this.Name = name;
            this.Desc = desc;
            this.DayStarted = dayStarted;
            this.IsDayEducation = isDayEducation;
            this.HasFeedback = hasFeedback;
            this.IsActive = false;
        }
		public Sessie(String name, String desc, DateTime dayStarted, Boolean isDayEducation, Boolean hasFeedback, ICollection<Group> groups, BoB bob) : this()
		{
            this.Name = name;
            this.Desc = desc;
            this.DayStarted = dayStarted;
            this.IsDayEducation = isDayEducation;
            this.HasFeedback = hasFeedback;
            this.IsActive = false;
            this.Groups = groups;
            this.Box = bob;

        }

	}
}
