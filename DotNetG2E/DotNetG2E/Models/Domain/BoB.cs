using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Models.Domain
{
	public class BoB
	{
		public int BoBId { get; private set; }
		public String Name { get; private set; }
		public String Description { get; private set; }
		public IEnumerable<Actie> Actions { get; private set; }
		public IEnumerable<AccesCode> AccesCodes { get; private set; }
		public IEnumerable<Exercise> Exercises { get; private set; }
		public int SessieCode { get; set; }
		

		public BoB()
		{

		}

		public BoB(String name, String description)
		{
			name = Name;
			description = Description;

		}

		public BoB(String name, String description, IEnumerable<Actie> actions, IEnumerable<AccesCode> accesCodes, IEnumerable<Exercise> exercises)
		{
			name = Name;
			description = Description;
			actions = Actions;
			accesCodes = AccesCodes;
			exercises = Exercises;
		}
	}
}
