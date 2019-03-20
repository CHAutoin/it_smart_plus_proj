using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace itsmartplus.Models
{
	public class employee
	{
		[Key]
		[Required(ErrorMessage = "Required.")]
		[MaxLength(10,ErrorMessage ="Max 10 characters.")]
		public string em_id { get; set; }
		[Required(ErrorMessage ="Required.")]
		[MaxLength(50, ErrorMessage = "Max 10 characters.")]
		public string em_name { get; set; }
		[Required(ErrorMessage = "Required.")]
		[MaxLength(50, ErrorMessage = "Max 10 characters.")]
		public string em_lastname { get; set; }
		public byte[] em_img { get; set; }

	}
}
