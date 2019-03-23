using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using itsmartplus.Models;
using itsmartplus.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace itsmartplus.Controllers
{

	public class LoginController : Controller
	{
		ItSmartContext db;
		public LoginController(ItSmartContext _db)
		{
			db = _db;
		}
		public IActionResult mLogin()
		{
			TempData["error"] = "";
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[ActionName("mLogin")]
		public async Task<IActionResult> Chk_mLogin(string user, string pass)
		{
			var udat = await db.admintables.Where(m => m.ad_id.Equals(user) && m.ad_pass.Equals(pass)).FirstOrDefaultAsync();
			if (udat != null)
			{
				HttpContext.Session.SetString(user_pass.Name, udat.ad_name);
				HttpContext.Session.SetString(user_pass.password, udat.ad_pass);
				HttpContext.Session.SetString(user_pass.employee_ID, udat.ad_id);
				return RedirectToAction("mMainMenu");
			}
			else
			{
				
				TempData["error"] = @"<strong> Username </strong> or <strong> Password </strong> are invalid. &nbsp;";

				return View();
			}
		}


		[SessionTimeout]
		public IActionResult mMainMenu()
		{
			return View();
		}

		public IActionResult HelpDeskLogin()
		{

			return View();
		}
		[SessionTimeout]
		public IActionResult HelpDeskWelcome()
		{
			return View();

		}

		public IActionResult Logout()
		{
			HttpContext.Session.Remove(user_pass.employee_ID);
			HttpContext.Session.Remove(user_pass.Name);
			HttpContext.Session.Remove(user_pass.password);
			return RedirectToAction("mLogin");
		}

	}
}