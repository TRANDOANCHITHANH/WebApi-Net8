﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_Net8.Data
{
	[Table("Loai")]
	public class Loai
	{
		[Key]
		public int MaLoai { get; set; }
		[Required]
		[MaxLength(255)]
		public string TenLoai { get; set; }
		public virtual ICollection<HangHoa> HangHoas { get; set; }
	}
}