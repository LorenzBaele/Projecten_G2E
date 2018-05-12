using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Models.Domain
{
    public class Leerkracht
    {
		public int LeerkrachtsNummer { get; set; }
        public String UserName { get;  set; }
		public String Surname { get; set; }
		public String Email { get; set; }

		public ICollection<Sessie> Sessies { get; set; }

		public Leerkracht()
		{
			Sessies = new List<Sessie>();
		}

		public IEnumerable<Sessie> GetSessies()
		{
			return Sessies;
		}
    }
}
