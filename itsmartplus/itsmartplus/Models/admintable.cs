using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace itsmartplus.Models
{
	public class admintable
	{
		[Key]
		[MaxLength(10,ErrorMessage = "Not over 10 characters.")]
		[Required(ErrorMessage = "The ID field is required.")]
		public string ad_id { get; set; }

		[MaxLength(50, ErrorMessage = "Not over 50 characters.")]
		[Required(ErrorMessage = "The Password field is required.")]
		public string ad_pass { get; set; }

		[MaxLength(50, ErrorMessage = "Not over 50 characters.")]
		[Required(ErrorMessage = "The Name field is required.")]
		public string ad_name { get; set; }

		[MaxLength(50, ErrorMessage = "Not over 50 characters.")]
		[Required(ErrorMessage = "The Lastname field is required.")]
		public string ad_lastname { get; set; }

	}
}
