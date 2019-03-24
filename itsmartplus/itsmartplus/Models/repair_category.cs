using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore;
namespace itsmartplus.Models
{
	public class repair_category
	{
		[Key]
		public string rep_id { get; set; }
		public string rep_date { get; set; }


		[ForeignKey("ad_id")]
		public virtual admintable Admintable { get; set; }
		public string ad_id { get; set; }

		[ForeignKey("supp_id")]
		public virtual supplier Supplier { get; set; }
		public string supp_id { get; set; }
	}
}