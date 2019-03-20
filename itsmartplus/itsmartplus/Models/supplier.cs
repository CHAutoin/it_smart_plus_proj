using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace itsmartplus.Models
{
	public class supplier
	{
		[Key]
		public string supp_id { get; set; }

		[Range(1,255,ErrorMessage ="Range 1-255.")]
		public string supp_name { get; set; }
		public string supp_addr { get; set; }
		[Phone]
		public string supp_phone { get; set; }
		public string supp_mobile { get; set; }
		[EmailAddress(ErrorMessage ="Please enter email address.")]
		public string supp_mail { get; set; }

		public string supp_fax { get; set; }
		public string supp_tin { get; set; }
	}
}
