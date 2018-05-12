using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Models.Domain
{
    public interface IActieRepository
    {
		IEnumerable<Actie> GetAll();
		Actie GetBy(int id);
	}
}
