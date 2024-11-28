using System.ComponentModel.DataAnnotations;

namespace WebApi_Net8.Models
{
	public class LoaiModel
	{
		[Required]
		[MaxLength(255)]
		public string TenLoai { get; set; }
	}
}
