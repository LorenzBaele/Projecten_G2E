using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Models.Domain
{
    public interface ILeerkrachtRepository
    {
		Leerkracht GetBy(int leerkrachtsnummer);
		Leerkracht GetByEmail(String email);
		IEnumerable<Leerkracht> GetAll();
		void saveChanges();
    }
}
