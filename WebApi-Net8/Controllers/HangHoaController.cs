using Microsoft.AspNetCore.Mvc;
using WebApi_Net8.Models;

namespace WebApi_Net8.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HangHoaController : ControllerBase
	{
		public static List<HangHoas> hangHoas = new List<HangHoas>();
		[HttpGet]
		public IActionResult GetAll()
		{
			return Ok(hangHoas);
		}
		[HttpGet("{id}")]
		public IActionResult GetById(string id)
		{
			try
			{
				var hanghoa = hangHoas.SingleOrDefault(p => p.MaHangHoa == Guid.Parse(id));
				if (hanghoa == null)
				{
					return NotFound();
				}
				return Ok(hanghoa);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		[HttpPost]
		public IActionResult Create(HangHoaVM hangHoaVM)
		{
			var hanghoa = new HangHoas
			{
				MaHangHoa = Guid.NewGuid(),
				TenHangHoa = hangHoaVM.TenHangHoa,
				DonGia = hangHoaVM.DonGia
			};
			hangHoas.Add(hanghoa);
			return Ok(new
			{
				Success = true,
				Data = hanghoa
			});
		}
		[HttpPut("{id}")]
		public IActionResult Edit(string id, HangHoas hangHoaEdit)
		{
			try
			{
				var hanghoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
				if (hanghoa == null)
				{
					return NotFound();
				}
				if (id != hanghoa.MaHangHoa.ToString())
				{
					return BadRequest();
				}
				hanghoa.TenHangHoa = hangHoaEdit.TenHangHoa;
				hanghoa.DonGia = hangHoaEdit.DonGia;
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		[HttpDelete("{id}")]
		public IActionResult Delete(string id)
		{
			try
			{
				var hangHoadel = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
				if (hangHoadel == null)
				{
					return NotFound();
				}
				hangHoas.Remove(hangHoadel);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}