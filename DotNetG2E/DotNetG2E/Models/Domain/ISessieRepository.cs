using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Models.Domain
{
    public interface ISessieRepository
    {
		IEnumerable<Sessie> GetAll();
        Sessie GetBy(int sessionCode);
        void SaveChanges();
        IEnumerable<Sessie> GetByFilter(string filter);
        IEnumerable<Sessie> GetByFilterActive(string sessionSearch);
        IEnumerable<Sessie> GetByFilterNotActive(string sessionSearch);
        IEnumerable<Sessie> GetActive();
        IEnumerable<Sessie> GetNotActive();
		Sessie GetGroupByCode(int groupId, int sessionCode);
	}
}
