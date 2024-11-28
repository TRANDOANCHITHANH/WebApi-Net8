using Microsoft.AspNetCore.Mvc;
using WebApi_Net8.Data;
using WebApi_Net8.Models;

namespace WebApi_Net8.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoaisController : ControllerBase
	{
		private readonly MyDbContext _context;

		public LoaisController(MyDbContext context)
		{
			_context = context;
		}
		[HttpGet]
		public IActionResult GetAll()
		{
			var dsLoai = _context.Loais.ToList();
			return Ok(dsLoai);
		}
		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var dsLoai = _context.Loais.SingleOrDefault(x => x.MaLoai == id);
			if (dsLoai != null)
			{
				return Ok(dsLoai);
			}
			else
			{
				return NotFound();
			}
			return Ok(dsLoai);
		}
		[HttpPost]
		public IActionResult Create(LoaiModel loaiModel)
		{
			try
			{
				var loai = new Loai
				{
					TenLoai = loaiModel.TenLoai
				};
				_context.Add(loai);
				_context.SaveChanges();
				return Ok(loai);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		[HttpPut("{id}")]
		public IActionResult UpdateById(int id, LoaiModel loaiModel)
		{
			var loai = _context.Loais.SingleOrDefault(l => l.MaLoai == id);
			if (loai != null)
			{
				loai.TenLoai = loaiModel.TenLoai;
				_context.SaveChanges();
				return NoContent();
			}
			else
			{
				return NotFound();
			}
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteById(int id)
		{
			try
			{
				var loai = _context.Loais.SingleOrDefault(l => l.MaLoai == id);
				if (loai == null)
				{
					return NotFound();
				}
				_context.Loais.Remove(loai);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
