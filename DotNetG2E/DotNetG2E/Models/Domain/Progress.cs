using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Models.Domain
{
    public class Progress
    {
		//Wordt geset wanneer de sessie gestart wordt, kan eventueel gewoon via code gedaan worden ipv db?
		public int TotalExercisesNumber { get; set; }

		public int SolvedExercisesNumber { get; set; }
		public int GroupId { get; set; }

		public Progress()
		{

		}
	}
}
