using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetG2E.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DotNetG2E.Data.Repositories
{
    public class SessieRepository : ISessieRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Sessie> _sessies;

        //untill database works 



        public SessieRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _sessies = dbContext.Sessies;
            

        }

        public IEnumerable<Sessie> GetActive()
        {
            IEnumerable<Sessie> filteredSessions = _sessies.Where(s => s.IsActive);
            return filteredSessions;
        }

        public IEnumerable<Sessie> GetAll()
        {
            return _sessies.ToList();

        }

        public Sessie GetBy(int sessionCode)
        {
			Sessie sessie = _sessies
				.Include(e => e.Box)
					.ThenInclude(e => e.Exercises)
						.ThenInclude(e => e.Modifiers)
				.Include(e => e.Box)
					.ThenInclude(e => e.Actions)
				.Include(e => e.Box)
					.ThenInclude(e => e.AccesCodes)
				.Include(e => e.Groups)
					.ThenInclude(e => e.Pupils)
				.SingleOrDefault(e => e.SessionCode == sessionCode);

			return sessie;

        }

        public IEnumerable<Sessie> GetByFilter(String sessionSearch)
        {
            IEnumerable<Sessie> filteredSessions = _sessies.Where(s => s.Name.IndexOf(sessionSearch, StringComparison.OrdinalIgnoreCase) >= 0);
            return filteredSessions;
        }

        public IEnumerable<Sessie> GetByFilterActive(string sessionSearch)
        {
            IEnumerable<Sessie> filteredSessions = _sessies.Where(s => s.Name.IndexOf(sessionSearch, StringComparison.OrdinalIgnoreCase) >= 0 && s.IsActive);
            return filteredSessions;
        }

        public IEnumerable<Sessie> GetByFilterNotActive(string sessionSearch)
        {
            IEnumerable<Sessie> filteredSessions = _sessies.Where(s => s.Name.IndexOf(sessionSearch, StringComparison.OrdinalIgnoreCase) >= 0 && !s.IsActive);
            return filteredSessions;
        }

        public IEnumerable<Sessie> GetNotActive()
        {
            IEnumerable<Sessie> filteredSessions = _sessies.Where(s => !s.IsActive);
            return filteredSessions;
        }
		public Sessie GetGroupByCode(int groupId, int sessionCode)
		{
			Sessie sessie = _sessies
				.Include(e => e.Box)
					.ThenInclude(e => e.Exercises)
						.ThenInclude(e => e.Modifiers)
				.Include(e => e.Box)
					.ThenInclude(e => e.Actions)
				.Include(e => e.Box)
					.ThenInclude(e => e.AccesCodes)
				.Include(e => e.Groups)
					.ThenInclude(e=> e.Pupils)
				.SingleOrDefault( e => e.SessionCode == sessionCode);
			
			return sessie;
			//return _sessies
			//	.Include(e => e.Box)
			//	.Include(e => e.Groups)
			//	.SingleOrDefault(e => e.SessionCode == sessionCode);
		}

		public void SaveChanges()
        {
            _context.SaveChanges();
        }


    }
}
