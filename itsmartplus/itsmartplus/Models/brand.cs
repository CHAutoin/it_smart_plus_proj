using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace itsmartplus.Models
{
	public class brand
	{
		[Key]
		[Required(ErrorMessage ="Required.")]
		public string br_id { get; set; }
		[Required(ErrorMessage = "Required.")]
		public string br_name { get; set; }
	}
}
