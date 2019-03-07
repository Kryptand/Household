using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Kryptand.ChefMaster.Infrastructure.Disposal;
using Kryptand.ChefMaster.Core.Disposal;

namespace Kryptand.ChefMaster.Web.Disposal.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DisposalLocationsController : ControllerBase
	{
		// GET: api/AmountUnit
		private readonly IDisposalLocationRepository _disposalLocationRepo;
		public DisposalLocationsController(IDisposalLocationRepository disposalLocationRepo) => _disposalLocationRepo = disposalLocationRepo ?? throw new ArgumentNullException(nameof(disposalLocationRepo));
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var disposalLocations = await _disposalLocationRepo.GetAll();
			return Ok(disposalLocations);
		}
		// GET: api/AmountUnit/5
		[HttpGet("{id}", Name = "GetDisposalLocation")]
		public async Task<IActionResult> GetById(Guid id)
		{
			if (id == null)
			{
				return BadRequest();
			}
			var item = await _disposalLocationRepo.FindById(id);
			if (item == null)
			{
				return NotFound();
			}
			return Ok(item);
		}

		// POST: api/AmountUnit
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] DisposalLocation item)
		{
			if (item == null)
			{
				return BadRequest();
			}
			await _disposalLocationRepo.Add(item);
			return CreatedAtRoute("GetDisposalLocation", new { Controller = "GetDisposalLocations", id = item.Id }, item);
		}

		// PUT: api/AmountUnit/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] DisposalLocation item)
		{
			if (item == null || id == null)
			{
				return BadRequest();
			}
			var contactObj = await _disposalLocationRepo.FindById(id);
			if (contactObj == null)
			{
				return NotFound();
			}
			await _disposalLocationRepo.Update(item);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			await _disposalLocationRepo.Remove(id);
			return NoContent();
		}
	}
}
