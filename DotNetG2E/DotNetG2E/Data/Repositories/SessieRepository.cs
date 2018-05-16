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
            List<Sessie> filteredSessions = new List<Sessie>();
            foreach (Sessie s in _sessies)
            {
                if (s.IsActive)
                {
                    filteredSessions.Add(s);
                }
            }
            return filteredSessions;
        }

        public IEnumerable<Sessie> GetAll()
        {
            return _sessies.ToList();

        }

        public Sessie GetBy(int sessionCode)
        {
            return _sessies.SingleOrDefault(s => s.SessionCode == sessionCode);
        }

        public IEnumerable<Sessie> GetByFilter(String filter)
        {
            List<Sessie> filteredSessions = new List<Sessie>();
            foreach(Sessie s in _sessies)
            {
                if (s.Name.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    filteredSessions.Add(s);
                }
            }
            return filteredSessions;
        }

        public IEnumerable<Sessie> GetByFilterActive(string filter)
        {
            List<Sessie> filteredSessions = new List<Sessie>();
            foreach (Sessie s in _sessies)
            {
                if (s.Name.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 && s.IsActive)
                {
                    filteredSessions.Add(s);
                }
            }
            return filteredSessions;
        }

        public IEnumerable<Sessie> GetByFilterNotActive(string filter)
        {
            List<Sessie> filteredSessions = new List<Sessie>();
            foreach (Sessie s in _sessies)
            {
                if (s.Name.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 && !s.IsActive)
                {
                    filteredSessions.Add(s);
                }
            }
            return filteredSessions;
        }

        public IEnumerable<Sessie> GetNotActive()
        {
            List<Sessie> filteredSessions = new List<Sessie>();
            foreach (Sessie s in _sessies)
            {
                if (!s.IsActive)
                {
                    filteredSessions.Add(s);
                }
            }
            return filteredSessions;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }


    }
}
