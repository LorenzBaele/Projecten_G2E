using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Models.Domain
{
    interface IModifierRepository
    {
		IEnumerable<Modifier> GetAll();
		Modifier GetBy(int id);
		
	}
}
