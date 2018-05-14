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
        public IEnumerable<Sessie> GetAll()
        {
            return _sessies.ToList();

        }

        public Sessie GetBy(int sessionCode)
        {
            return _sessies.SingleOrDefault(s => s.SessionCode == sessionCode);

            

        }


    }
}
