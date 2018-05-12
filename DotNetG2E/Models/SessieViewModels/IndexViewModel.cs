using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Models.SessieViewModels
{
    public class IndexViewModel
    {
		public IEnumerable<SessieViewModel> Sessions { get; set; }

		public IndexViewModel()
		{

		}
	}
}
