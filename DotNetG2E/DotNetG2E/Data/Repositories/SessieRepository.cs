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



        public SessieRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _sessies = dbContext.Sessies;


        }
        public IEnumerable<Sessie> GetAll()
        {
            return _sessies.ToList();
        }

        public Sessie GetBy(int sessionCode)
        {
            return _sessies
                .Include(s => s.Name)
                .Include(s => s.Desc)
                .Include(s => s.IsActive)
                .Include(s => s.HasFeedback)
                .Include(s => s.IsDayEducation)
                .Include(s => s.DayStarted)
                .Include(s => s.Groups)
                .Include(s => s.Box)
                .SingleOrDefault(s => s.SessionCode == sessionCode);
        }

    }
}
