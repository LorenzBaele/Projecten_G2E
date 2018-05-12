using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Models.Domain
{
	public class Exercise
	{
		public int ExerciseId { get; private set; }
		public String Name { get; private set; }
		public String Task { get; private set; }
		public String Result { get; private set; }
		public String Feedback { get; private set; }
		public String Goal { get; private set; }
		public String Category { get; private set; }
		public int TimeLimit { get; private set; }
		public IEnumerable<Modifier> Modifiers { get; private set; }
		public int BoBId { get; set; }
		public BoB BoB { get; private set; }

		public Exercise()
		{

		}

		public Exercise(String name, String task, String result, String feedback, String goal, String category, int timeLimit, IEnumerable<int> modifier)
		{

		}
	}
}
