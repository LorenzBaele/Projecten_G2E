using DotNetG2E.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Data.Repositories
{
	public class ActieRepository : IActieRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly DbSet<Actie> _acties;

		public ActieRepository(ApplicationDbContext dbContext)
		{
			_context = dbContext;
			_acties = dbContext.Acties;
		}
		public IEnumerable<Actie> GetAll()
		{
			return _acties.ToList();
		}

		public Actie GetBy(int id)
		{
			return _acties
				.Include(a => a.Name)
				.SingleOrDefault(a => a.ActieId == id);
		}
	}
}
