using System;
using System.Collections.Generic;

namespace DotNetG2E.Models.Domain
{
	internal interface IExerciseRepository
	{
		IEnumerable<Exercise> GetAll();

		Exercise GetBy(int id);

		Exercise GetByName(String name);
	}
}