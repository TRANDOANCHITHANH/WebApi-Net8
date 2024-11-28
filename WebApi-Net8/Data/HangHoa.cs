using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_Net8.Data
{
	[Table("HangHoa")]
	public class HangHoa
	{
		[Key]
		public Guid Id { get; set; }
		[Required]
		[MaxLength(100)]
		public string TenHh { get; set; }
		[Range(0, double.MaxValue)]
		public double DonGia { get; set; }
		public string MoTa { get; set; }
		public byte GiamGia { get; set; }
		public int? MaLoai { get; set; }
		[ForeignKey("MaLoai")]
		public Loai loai { get; set; }
	}
}
