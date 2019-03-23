using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace itsmartplus.Models
{
	public class pm_category
	{
		[Key]
		public string pm_genid { get; set; }

		public DateTime pm_date { get; set; }

		public string ad_id { get; set; }
		[ForeignKey("ad_id")]
		public virtual admintable Admintable { get; set; }


	}
}
