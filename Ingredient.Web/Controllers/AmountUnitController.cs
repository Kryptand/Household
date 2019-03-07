using Microsoft.AspNetCore.Mvc;
using Kryptand.ChefMaster.Infrastructure.Ingredients;
using Kryptand.ChefMaster.Core.Ingredients;
using System.Threading.Tasks;
using System;

namespace Ingredient.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AmountUnitController : ControllerBase
	{
		// GET: api/AmountUnit
		private readonly IAmountUnitRepository _amountRepo;
		public AmountUnitController(IAmountUnitRepository amountUnitRepository) => _amountRepo = amountUnitRepository ?? throw new System.ArgumentNullException(nameof(amountUnitRepository));
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var contactList = await _amountRepo.GetAll();
			return Ok(contactList);
		}
		// GET: api/AmountUnit/5
		[HttpGet("{id}", Name = "GetAmountUnit")]
		public async Task<IActionResult> GetById(Guid id)
		{
			if (id == null)
			{
				return BadRequest();
			}
			var item = await _amountRepo.FindById(id);
			if (item == null)
			{
				return NotFound();
			}
			return Ok(item);
		}

		// POST: api/AmountUnit
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] AmountUnit item)
		{
			if (item == null)
			{
				return BadRequest();
			}
			await _amountRepo.Add(item);
			return CreatedAtRoute("GetAmountUnit", new { Controller = "AmountUnit", id = item.Id }, item);
		}

		// PUT: api/AmountUnit/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] AmountUnit item)
		{
			if (item == null||id==null)
			{
				return BadRequest();
			}
			var contactObj = await _amountRepo.FindById(id);
			if (contactObj == null)
			{
				return NotFound();
			}
			await _amountRepo.Update(item);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			await _amountRepo.Remove(id);
			return NoContent();
		}
	}
}
