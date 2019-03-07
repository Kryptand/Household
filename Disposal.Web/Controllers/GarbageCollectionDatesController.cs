using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Kryptand.ChefMaster.Infrastructure.Disposal;
using Kryptand.ChefMaster.Core.Disposal;
using System.Linq;

namespace Kryptand.ChefMaster.Web.Disposal.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GarbageCollectionDatesController : ControllerBase
	{
		// GET: api/AmountUnit
		private readonly IGarbageCollectionDateRepository _collectionDateRepo;
		public GarbageCollectionDatesController(IGarbageCollectionDateRepository collectionDateRepo) => _collectionDateRepo = collectionDateRepo ?? throw new ArgumentNullException(nameof(collectionDateRepo));
		[HttpGet]
		public async Task<IActionResult> GetAll(Guid? categoryId, Guid? disposalLocationId, DateTime? disposalDate)
		{
			if (categoryId == null && disposalLocationId == null && disposalDate == null)
			{
				var disposalLocations = await _collectionDateRepo.GetAll();
				return Ok(disposalLocations);
			}
			var garbageCollectionQueryable = _collectionDateRepo.GetAllAsQueryable();
			if (categoryId != null)
			{
				garbageCollectionQueryable.Where(x => x.DisposeCategoryId == categoryId);
			}
			if (disposalLocationId != null)
			{
				garbageCollectionQueryable.Where(x => x.DisposalLocationId == disposalLocationId);
			}
			if (disposalDate != null)
			{
				garbageCollectionQueryable.Where(x => x.Date == disposalDate);
			}
			return Ok(garbageCollectionQueryable.ToAsyncEnumerable());
		}

		// GET: api/AmountUnit/5
		[HttpGet("{id}", Name = "GetGarbageCollectionDate")]
		public async Task<IActionResult> GetById(Guid id)
		{
			if (id == null)
			{
				return BadRequest();
			}
			var item = await _collectionDateRepo.FindById(id);
			if (item == null)
			{
				return NotFound();
			}
			return Ok(item);
		}

		// POST: api/AmountUnit
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] GarbageCollectionDate item)
		{
			if (item == null)
			{
				return BadRequest();
			}
			await _collectionDateRepo.Add(item);
			return CreatedAtRoute("GetGarbageCollectionDate", new { Controller = "GarbageCollectionDates", id = item.Id }, item);
		}

		// PUT: api/AmountUnit/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] GarbageCollectionDate item)
		{
			if (item == null || id == null)
			{
				return BadRequest();
			}
			var contactObj = await _collectionDateRepo.FindById(id);
			if (contactObj == null)
			{
				return NotFound();
			}
			await _collectionDateRepo.Update(item);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			await _collectionDateRepo.Remove(id);
			return NoContent();
		}
	}
}
