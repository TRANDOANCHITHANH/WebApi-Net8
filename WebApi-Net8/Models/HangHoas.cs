﻿namespace WebApi_Net8.Models
{
	public class HangHoaVM
	{
		public string TenHangHoa { get; set; }
		public double DonGia { get; set; }
	}
	public class HangHoas : HangHoaVM
	{
		public Guid MaHangHoa { get; set; }
	}

}