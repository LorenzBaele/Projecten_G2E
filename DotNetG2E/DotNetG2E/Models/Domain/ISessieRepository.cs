using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Models.Domain
{
    public interface ISessieRepository
    {
		IEnumerable<Sessie> GetAll();
        Sessie GetBy(int SessionCode);

    }
}
