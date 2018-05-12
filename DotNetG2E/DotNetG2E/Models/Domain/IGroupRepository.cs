using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetG2E.Models.Domain
{
    interface IGroupRepository
    {
		IEnumerable<Group> GetAll();
		Group getBy(String name);
    }
}
