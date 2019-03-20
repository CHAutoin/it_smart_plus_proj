using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace itsmartplus
{
	public class SessionTimeoutAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			//HttpContext ct = context.HttpContext;
			//string a = ct.Session.GetString(user_pass.employee_ID);
			//string b = ct.Session.GetString(user_pass.Name);
			//if (ct.Session.GetString(user_pass.employee_ID) == null || ct.Session.GetString(user_pass.Name) == null)
			//{
			//	context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "mLogin", controller = "Login" }));
			//}
			//base.OnActionExecuting(context);

			HttpContext ctx = context.HttpContext;
			if (ctx.Session.GetString(user_pass.employee_ID) == null)
			{
				context.Result = new RedirectResult("~/Login/mLogin");
				return;
			}
			base.OnActionExecuting(context);
		}
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			base.OnActionExecuted(context);
		}
	}
}
