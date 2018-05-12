using DotNetG2E.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DotNetG2E.Data.Repositories
{
	public class BoBRepository : IBoBRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly DbSet<BoB> _bobs;

		public BoBRepository(ApplicationDbContext dbContext)
		{
			_context = dbContext;
			_bobs = dbContext.BoBs;
		}

		public IEnumerable<BoB> GetAll()
		{
			return _bobs.ToList();
		}

		public BoB GetBy(int id)
		{
			return _bobs
				.Include(b => b.Name)
				.Include(b => b.Description)
				.Include(b => b.Exercises)
				.Include(b => b.AccesCodes)
				.Include(b => b.Actions)
				.SingleOrDefault(b => b.BoBId == id);
		}

		public BoB GetByName(string name)
		{
			return _bobs
				.Include(b => b.Name)
				.Include(b => b.Description)
				.Include(b => b.Exercises)
				.Include(b => b.AccesCodes)
				.Include(b => b.Actions)
				.SingleOrDefault(b => b.Name == name);
		}
	}
}