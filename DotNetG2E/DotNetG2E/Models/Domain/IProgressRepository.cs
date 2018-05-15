using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Models.Domain
{
    public interface IProgressRepository
    {
		IEnumerable<Progress> GetAll();
		Progress GetBy(int groupId);
		void SaveChanges();
	}
}
