using DotNetG2E.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Data.Repositories
{
	public class ExerciseRepository : IExerciseRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly DbSet<Exercise> _exercises;

		public ExerciseRepository(ApplicationDbContext dbContext)
		{
			_context = dbContext;
			_exercises = dbContext.Exercises;
		}
		public IEnumerable<Exercise> GetAll()
		{
			return _exercises.ToList();
		}

		public Exercise GetBy(int id)
		{
			return _exercises
				.Include(e => e.Name)
				.Include(e => e.Task)
				.Include(e => e.TimeLimit)
				.Include(e => e.Result)
				.Include(e => e.Modifiers)
				.Include(e => e.Goal)
				.Include(e => e.Feedback)
				.Include(e => e.Category)
				.SingleOrDefault(e => e.ExerciseId == id);
		}

		public Exercise GetByName(string name)
		{
			return _exercises
				.Include(e => e.Name)
				.Include(e => e.Task)
				.Include(e => e.TimeLimit)
				.Include(e => e.Result)
				.Include(e => e.Modifiers)
				.Include(e => e.Goal)
				.Include(e => e.Feedback)
				.Include(e => e.Category)
				.SingleOrDefault(e => e.Name == name);
		}
	}
}
