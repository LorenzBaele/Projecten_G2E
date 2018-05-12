using DotNetG2E.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Data.Repositories
{
    public class ModifierRepository
    {
		private readonly ApplicationDbContext _context;
		private readonly DbSet<Modifier> _modifiers;

		public ModifierRepository(ApplicationDbContext dbContext)
		{
			_context = dbContext;
			_modifiers = dbContext.Modifiers;
		}
	}
}
