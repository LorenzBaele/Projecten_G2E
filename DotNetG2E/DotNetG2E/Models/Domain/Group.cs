using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Models.Domain
{
	public class Group
	{
		public int GroupId { get; set; }
		
		public String Name { get;  set; }
		public IEnumerable<Pupil> Pupils { get;  set; }
		public Boolean Selected { get; set; }
		public Boolean Blocked { get; set; }
										   //public int SessionCode { get; set; }
		public Session_Group SessionGroup { get; internal set; }

		public Group()
		{

		}

		public Group(String name, IEnumerable<Pupil> pupils)
		{
			name = Name;
			pupils = Pupils;
		}
	}
}
