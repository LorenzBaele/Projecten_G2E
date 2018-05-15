using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Models.Domain
{
    interface IGroupRepository
    {
		IEnumerable<Group> GetAll();
		Group getById(int groupId);
		IEnumerable<Group> getSelectedGroups(bool selected);
		IEnumerable<Group> getBlockedGroups(bool blocked);
		void SaveChanges();
	}
}
