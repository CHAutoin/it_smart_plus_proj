using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace itsmartplus.Models
{
	public class pm_category_detail
	{
		[Key]
		public int pm_id { get; set; }

		[MaxLength(100)]
		public string pmdetail { get; set; }  
		public bool pm_normal { get; set; } 
		public bool pm_update { get; set; } 
		public bool pm_repair { get; set; } 
		public bool pm_spare { get; set; } 
		public bool pm_equip { get; set; } 
		[MaxLength(250)]
		public string remark { get; set; } 

		public string pm_genid { get; set; } 
		[ForeignKey("pm_genid")]
		public virtual pm_category Pm_Category { get; set; }
		public string cat_id { get; set; } 
		[ForeignKey("cat_id")]
		public virtual category Category { get; set; }
	}
}
