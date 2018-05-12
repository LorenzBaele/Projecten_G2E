using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetG2E.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DotNetG2E.Data.Repositories
{
	public class GroupRepository : IGroupRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly DbSet<Group> _groups;

		public GroupRepository(ApplicationDbContext dbContext)
		{
			_context = dbContext;
			_groups = dbContext.Groups;
		}
		public IEnumerable<Group> GetAll()
		{
			throw new NotImplementedException();
		}

		public Group getBy(string name)
		{
			throw new NotImplementedException();
		}
	}
}
