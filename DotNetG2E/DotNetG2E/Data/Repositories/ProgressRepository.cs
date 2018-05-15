using DotNetG2E.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DotNetG2E.Data.Repositories
{
	public class ProgressRepository : IProgressRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly DbSet<Progress> _progress;

		public ProgressRepository(ApplicationDbContext dbContext)
		{
			_context = dbContext;
			_progress = dbContext.Progress;


		}
		public IEnumerable<Progress> GetAll()
		{
			return _progress.ToList();
		}

		public Progress GetBy(int groupId)
		{
			return _progress.Include(e => e.SolvedExercisesNumber)
				.Include(e => e.TotalExercisesNumber)
				.SingleOrDefault(e => e.GroupId == groupId);
			
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}
	}
}
