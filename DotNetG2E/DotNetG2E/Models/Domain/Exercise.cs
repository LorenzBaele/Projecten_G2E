using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Models.Domain
{
	public class Exercise
	{
		public int ExerciseId { get;  set; }
		public String Name { get;  set; }
		public String Task { get; set; }
		public String Result { get;  set; }
		public String Feedback { get;  set; }
		public String Goal { get;  set; }
		public String Category { get;  set; }
		public int TimeLimit { get;  set; }
		public IEnumerable<Modifier> Modifiers { get;  set; }
		public int BoBId { get; set; }
		public BoB BoB { get;  set; }

		public Exercise()
		{

		}

		public Exercise(String name, String task, String result, String feedback, String goal, String category, int timeLimit, IEnumerable<int> modifier)
		{

		}
	}
}
