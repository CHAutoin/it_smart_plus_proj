using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using itsmartplus.Models;
using itsmartplus.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace itsmartplus.Controllers
{
	public class pmprinter
	{
		public string cause { get; set; }
	}

	public class Listpmprinter
	{
		public List<pmprinter> pmprintersList()
		{
			List<pmprinter> pmprinters = new List<pmprinter>();
			pmprinters.Add(new pmprinter { cause = "ลักษณะการพิมพ์" });
			pmprinters.Add(new pmprinter { cause = "อื่นๆ" });
			return pmprinters;
		}
	}
    public class pmController : Controller
    {
		ItSmartContext db;
		public pmController(ItSmartContext _db)
		{
			db = _db;
		}
        public IActionResult PMIndex()
        {
            return View();
        }

		public IActionResult ListPrinters()
		{
			return View();
		}

		public async Task<IActionResult> SelectListprinterbybrand(string pr)
		{
			var printerepsondat = await db.categories.Where(ep => ep.Brand.br_name.Contains(pr))
				.Include(m=>m.Employee)
				.Include(m=>m.Type)
				.Include(m=>m.Brand).ToListAsync();
			switch (pr)
			{
				case "epson":
					return View(printerepsondat);
				case "canon":
					return View(printerepsondat);
				case "hp":
					return View(printerepsondat);
				case "fuji":
					return View(printerepsondat);
				case "brother":
					return View(printerepsondat);
				default:
					return NotFound();
			}
		}

		public async Task<IActionResult> printer_detail(string prid,string type,string pr)
		{
			var prdat = await db.categories.Where(m => m.cat_id.Equals(prid) && m.Type.t_name.Equals(type))
				.Include(m => m.Employee)
				.Include(m => m.Type)
				.FirstOrDefaultAsync();
			pmViewModels pmmodels = new pmViewModels
			{
				category = prdat
			};
			

			return View(pmmodels);
		}

		public async Task<IActionResult> printer_pm(string prid,string prtype)
		{
			pmViewModels pmmodels = new pmViewModels
			{
				category = await db.categories.Where(m => m.cat_id.Equals(prid) && m.Type.t_name.Equals(prtype)).FirstOrDefaultAsync(),
				pm_Category_Detail = await db.pm_Categories_details.Where(m => m.cat_id.Equals(prid)).FirstOrDefaultAsync()
			};
			return View(pmmodels);
			//var prdat = db.categories.Where(m => m.cat_id.Equals(prid) && m.Type.t_name.Equals(prtype)).FirstOrDefault();
			//return View(prdat);

		}
    }
}