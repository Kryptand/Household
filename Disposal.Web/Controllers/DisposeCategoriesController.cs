using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Kryptand.ChefMaster.Infrastructure.Disposal;
using Kryptand.ChefMaster.Core.Disposal;

namespace Kryptand.ChefMaster.Web.Disposal.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DisposeCategoriesController : ControllerBase
	{
		// GET: api/AmountUnit
		private readonly IDisposeCategoryRepository _disposeCategoryRepo;
		public DisposeCategoriesController(IDisposeCategoryRepository disposeCategoryRepo) => _disposeCategoryRepo = disposeCategoryRepo ?? throw new ArgumentNullException(nameof(disposeCategoryRepo));
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var disposalLocations = await _disposeCategoryRepo.GetAll();
			return Ok(disposalLocations);
		}

		// GET: api/AmountUnit/5
		[HttpGet("{id}", Name = "GetDisposeCategory")]
		public async Task<IActionResult> GetById(Guid id)
		{
			if (id == null)
			{
				return BadRequest();
			}
			var item = await _disposeCategoryRepo.FindById(id);
			if (item == null)
			{
				return NotFound();
			}
			return Ok(item);
		}

		// POST: api/AmountUnit
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] DisposeCategory item)
		{
			if (item == null)
			{
				return BadRequest();
			}
			await _disposeCategoryRepo.Add(item);
			return CreatedAtRoute("GetDisposeCategory", new { Controller = "DisposeCategories", id = item.Id }, item);
		}

		// PUT: api/AmountUnit/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] DisposeCategory item)
		{
			if (item == null || id == null)
			{
				return BadRequest();
			}
			var contactObj = await _disposeCategoryRepo.FindById(id);
			if (contactObj == null)
			{
				return NotFound();
			}
			await _disposeCategoryRepo.Update(item);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			await _disposeCategoryRepo.Remove(id);
			return NoContent();
		}
	}
}
