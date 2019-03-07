using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Kryptand.ChefMaster.Infrastructure.HousePlan;
using Kryptand.ChefMaster.Core.HousePlan;

namespace Kryptand.ChefMaster.Web.HousePlan.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HouseHoldCategoriesController : ControllerBase
	{
		// GET: api/AmountUnit
		private readonly IHouseholdCategoryRepository _householdCategoryRepo;
		public HouseHoldCategoriesController(IHouseholdCategoryRepository householdCategoryRepo) => _householdCategoryRepo = householdCategoryRepo ?? throw new ArgumentNullException(nameof(householdCategoryRepo));
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var disposalLocations = await _householdCategoryRepo.GetAll();
			return Ok(disposalLocations);
		}

		// GET: api/AmountUnit/5
		[HttpGet("{id}", Name = "GetHouseholdCategory")]
		public async Task<IActionResult> GetById(Guid id)
		{
			if (id == null)
			{
				return BadRequest();
			}
			var item = await _householdCategoryRepo.FindById(id);
			if (item == null)
			{
				return NotFound();
			}
			return Ok(item);
		}

		// POST: api/AmountUnit
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] HouseholdCategory item)
		{
			if (item == null)
			{
				return BadRequest();
			}
			await _householdCategoryRepo.Add(item);
			return CreatedAtRoute("GetHouseholdCategory", new { Controller = "HouseholdCategories", id = item.Id }, item);
		}

		// PUT: api/AmountUnit/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] HouseholdCategory item)
		{
			if (item == null || id == null)
			{
				return BadRequest();
			}
			var contactObj = await _householdCategoryRepo.FindById(id);
			if (contactObj == null)
			{
				return NotFound();
			}
			await _householdCategoryRepo.Update(item);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			await _householdCategoryRepo.Remove(id);
			return NoContent();
		}
	}
}
