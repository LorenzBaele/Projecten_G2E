using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Models.Domain
{
    interface IBoBRepository
    {
		IEnumerable<BoB> GetAll();
		BoB GetBy(int id);
		BoB GetByName(String name);
	}
}
