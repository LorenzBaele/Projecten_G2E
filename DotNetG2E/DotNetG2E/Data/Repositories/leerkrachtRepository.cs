using DotNetG2E.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Data.Repositories
{

	public class LeerkrachtRepository : ILeerkrachtRepository
    {
		private readonly ApplicationDbContext _dbContext;
		private readonly DbSet<Leerkracht> _leerkrachten;

		public LeerkrachtRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
			_leerkrachten = dbContext.Leerkrachten;
		}

		public IEnumerable<Leerkracht> GetAll()
		{
			return _leerkrachten.ToList();
		}

		public Leerkracht GetBy(int leerkrachtsnummer)
		{
			return _leerkrachten.SingleOrDefault(g => g.LeerkrachtsNummer == leerkrachtsnummer);
		}

		public Leerkracht GetByEmail(string email)
		{
			return _leerkrachten.SingleOrDefault(g => g.Email == email);
		}

		public void saveChanges()
		{
			_dbContext.SaveChanges();
		}
	}
}
