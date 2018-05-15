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
			return _groups.ToList();
		}

		public IEnumerable<Group> getBlockedGroups(bool blocked)
		{
			return _groups.ToList().FindAll(e => e.Blocked == blocked);

		}

		public Group getById(int groupId)
		{
			return _groups.Include(e => e.Name)
				.Include(e => e.Pupils)
				.Include(e => e.Selected)
				.Include(e => e.Blocked)
				.SingleOrDefault(e => e.GroupId == groupId);
		}

		public IEnumerable<Group> getSelectedGroups(bool selected)
		{
			return _groups.ToList().FindAll(e => e.Selected == selected);
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}
	}
}
