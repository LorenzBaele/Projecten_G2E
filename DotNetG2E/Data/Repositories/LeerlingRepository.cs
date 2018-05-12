using DotNetG2E.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Data.Repositories
{
    public class LeerlingRepository
    {
		private readonly ApplicationDbContext _context;
		private readonly DbSet<Leerling> _leerlingen;

		public LeerlingRepository(ApplicationDbContext dbContext)
		{
			_context = dbContext;
			_leerlingen = dbContext.Leerlingen;
		}
	}
}
