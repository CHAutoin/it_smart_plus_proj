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
		[Display(Name ="ID")]
		public string supp_id { get; set; }

		[Range(1, 255, ErrorMessage = "Range 1-255.")]
		[Display(Name = "Name")]
		public string supp_name { get; set; }
		[MaxLength(255,ErrorMessage ="Max length 255.")]
		[Display(Name = "Address")]
		public string supp_addr { get; set; }
		[Phone]
		[Display(Name = "Tel")]
		public string supp_phone { get; set; }
		[Display(Name = "Mobile")]
		public string supp_mobile { get; set; }
		[EmailAddress(ErrorMessage = "Please enter email address.")]
		[Display(Name = "E-mail")]
		public string supp_mail { get; set; }
		[Display(Name = "Fax")]
		public string supp_fax { get; set; }
		[Display(Name = "Tax ID")]
		//Tax Identification Number
		public string supp_tin { get; set; }
	}
}
