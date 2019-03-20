using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace itsmartplus.Models
{
	public class type
	{
		[Key]
		[MaxLength(10,ErrorMessage ="Not over 10 charecter.")]
		[Required(AllowEmptyStrings =false,ErrorMessage ="Please fill data.")]
		public string t_id { get; set; }

		[MaxLength(50, ErrorMessage = "Not over 50 charecter.")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "Please fill data.")]
		public string t_name { get; set; }


	}
}
