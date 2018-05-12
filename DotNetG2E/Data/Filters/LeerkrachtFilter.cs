using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetG2E.Models.Domain;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DotNetG2E.Data.Filters
{
    public class LeerkrachtFilter : ActionFilterAttribute
    {
		private readonly ILeerkrachtRepository _leerkrachtRepository;
		public LeerkrachtFilter(ILeerkrachtRepository leerkrachtRepository)
		{
			_leerkrachtRepository = leerkrachtRepository;
		}

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			//oefening 8
			context.ActionArguments["leerkracht"] = context.HttpContext.User.Identity.IsAuthenticated ? _leerkrachtRepository.GetByEmail(context.HttpContext.User.Identity.Name) : null;
			base.OnActionExecuting(context);
		}
	}
}
