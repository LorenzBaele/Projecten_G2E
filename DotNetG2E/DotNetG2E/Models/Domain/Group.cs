using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Models.Domain
{
	public class Group
	{
		public int GroupId { get; private set; }
		
		public String Name { get; private set; }
		public IEnumerable<Pupil> Pupils { get; private set; }
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
