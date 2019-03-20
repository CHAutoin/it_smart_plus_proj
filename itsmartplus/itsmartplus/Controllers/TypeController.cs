using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itsmartplus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace itsmartplus.Controllers
{
	public class TypeController : Controller
	{
		ItSmartContext db;

		public TypeController(ItSmartContext _db)
		{
			db = _db;
		}
		public async Task<IActionResult> TypeIndex(string search, string sortorder)
		{
			ViewData["idsort"] = String.IsNullOrEmpty(sortorder) ? "idsort" : "";
			ViewData["namesort"] = String.IsNullOrEmpty(sortorder) ? "namesort" : "";
			ViewData["currentSearch"] = search;
			var typedatList = await db.types.ToListAsync();

			if (!String.IsNullOrEmpty(search))
			{
				typedatList = typedatList.Where(md => md.t_id.Contains(search) || md.t_name.Contains(search)).ToList();
			}
			switch (sortorder)
			{
				case ("idsort"):
					typedatList = typedatList.OrderByDescending(md => md.t_id).ToList();
					break;

				case ("namesort"):
					typedatList = typedatList.OrderByDescending(md => md.t_name).ToList();
					break;
			}
			return View(typedatList);
		}

		[HttpGet]
		public IActionResult TypeAdd()
		{
			//type tp = new type();
			//return View(tp);
			return View();
		}

		[HttpPost]
		[ActionName("TypeAdd")]
		public async Task<IActionResult> TypeAddConfirm(type tp)
		{
			if (!ModelState.IsValid)
			{
				//type t = new type();
				//return View("TypeAdd",t);
				return View();
			}

			db.types.Add(tp);
			await db.SaveChangesAsync();
			return RedirectToAction(nameof(TypeIndex));
		}

		[HttpGet]
		public async Task<IActionResult> TypeEdit(string t_id)
		{
			var dat = from a in db.types
					  where a.t_id.Equals(t_id)
					  select a;
			if(dat == null)
			{
				return NotFound();
			}
			type t = await dat.FirstOrDefaultAsync();
			return View(t);
		}

		[ActionName("TypeEdit")]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<IActionResult> TypeEditConfirm(type typemodel)
		{
			if (!ModelState.IsValid)
			{
				return View(typemodel);
			}
			db.Update(typemodel);
			await db.SaveChangesAsync();
			return RedirectToAction(nameof(TypeIndex));
		}

		[HttpGet]
		public async Task<IActionResult> TypeDel(string t_id)
		{
			var dat = from a in db.types
					  where a.t_id.Equals(t_id)
					  select a;
			return View(await dat.FirstOrDefaultAsync());
		}

		[HttpPost]
		[ActionName("TypeDel")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> TypeDelCon(type t)
		{
			var typedat = db.types.Where(m => m.t_id.Equals(t.t_id));
			db.types.Remove(await typedat.FirstOrDefaultAsync());
			await db.SaveChangesAsync();
			return RedirectToAction(nameof(TypeIndex));
		}
	}
}