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
        private Sessie sessie1 = new Sessie("Wiskunde", "Moeilijk", new DateTime(1862, 12, 19), true, true);
        private Sessie sessie2 = new Sessie("Aardrijkskunde", "Makkelijk", new DateTime(1862, 12, 19), true, true);
        private List<Sessie> sessies = new List<Sessie>();
        

        public SessieRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _sessies = dbContext.Sessies;

            //untill database works 
            sessie1.IsActive = true;

            sessies.Add(this.sessie1);
            sessies.Add(this.sessie2);
        }
        public IEnumerable<Sessie> GetAll()
        {
            //return _sessies.ToList();
            //untill database works 
            return sessies;
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
