using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using itsmartplus.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace itsmartplus.Models
{
	public class Typeselect
	{
		public string t_id { get; set; }
		public string t_name { get; set; }

		public SelectList typeseleclist;

		public static SelectList TypeSelectList(ItSmartContext db)
		{
			var typedat = db.types.ToList();
			List<Typeselect> tpList = new List<Typeselect>();
			foreach (var item in typedat)
			{
				Typeselect tp = new Typeselect();
				tp.t_id = item.t_id;
				tp.t_name = item.t_id + " - " + item.t_name;
				tpList.Add(tp);
			}
			SelectList ls = new SelectList(tpList, "t_id", "t_name");
			return ls;
		}
	}
	public class Emselect
	{
		public string em_id { get; set; }
		public string em_name { get; set; }


		public static SelectList emSelectList(ItSmartContext db)
		{
			var emdat = db.employees.ToList();
			List<Emselect> emselects = new List<Emselect>();
			foreach (var item in emdat)
			{
				Emselect e = new Emselect();
				e.em_id = item.em_id;
				e.em_name = item.em_id + " - " + item.em_name + " - " + item.em_lastname;
				emselects.Add(e);
			}

			SelectList selectListItems = new SelectList(emselects, "em_id", "em_name");
			return selectListItems;

		}
	}
	public class Brandselect
	{
		public string b_id { get; set; }
		public string b_name { get; set; }


		public static SelectList brandSelectList(ItSmartContext db)
		{
			List<Brandselect> brandList = new List<Brandselect>();

			var bdat = db.brands.ToList();
			foreach(var item in bdat)
			{
				Brandselect bl = new Brandselect();
				bl.b_id = item.br_id;
				bl.b_name = item.br_id + " - " + item.br_name;
				brandList.Add(bl);
			}
			SelectList blselect = new SelectList(brandList, "b_id", "b_name");

			return blselect;
		}

	}
	public class category
	{
		[Key]
		[Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
		[MaxLength(30)]
		public string cat_id { get; set; }

		//Fix CatBrand
		//แก้ไข Catbrand แยกตารางออก เพื่อทำตารางยี่ห้อ
		//[Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
		//[MaxLength(10)]
		//public string cat_brand { get; set; }

		public string cat_name { get; set; }


		[Required(AllowEmptyStrings = false,ErrorMessage ="Required.")]
		[MaxLength(50)]
		public string cat_models { get; set; }

		[MaxLength(15)]
		public string cat_ip { get; set; }

		public DateTime cat_lastcheck { get; set; }
		public byte[] cat_image { get; set; }

		[MaxLength(50)]
		public string SerialNumber { get; set; }
		public string t_id { get; set; }
		[ForeignKey("t_id")]
		public virtual type Type { get; set; }

		public string br_id { get; set; }
		[ForeignKey("br_id")]
		public virtual brand Brand { get; set; }

		public string em_id { get; set; }
		[ForeignKey("em_id")]
		public virtual employee Employee { get; set; }

		public string ad_id { get; set; }
		[ForeignKey("ad_id")]
		public virtual admintable Admintable { get; set; }

		[NotMapped]
		public SelectList TypeSelectList { get; set; }

		[NotMapped]
		public SelectList EmSelectList { get; set; }

		[NotMapped]
		public SelectList BrandSelectList { get; set; }
	}
}
