using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Models.Domain
{
    public class Actie
    {
		public int ActieId { get; set; }
		public String Name { get;  set; }
		public int BoBId { get; set; }
		public BoB BoB { get; set; }
		public Actie()
		{

		}

		public Actie(String name)
		{
			Name = name;
		}
    }
}
