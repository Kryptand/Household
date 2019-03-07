using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Kryptand.ChefMaster.Infrastructure.Fridge;
using Kryptand.ChefMaster.Core.Fridge;

namespace Ingredient.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FridgeItemsController : ControllerBase
	{
		// GET: api/Fridgeitem
		private readonly IFridgeRepository _fridgeRepository;
		public FridgeItemsController(IFridgeRepository fridgeRepository) => _fridgeRepository = fridgeRepository ?? throw new System.ArgumentNullException(nameof(fridgeRepository));
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var fridgeItems = await _fridgeRepository.GetAll();
			return Ok(fridgeItems);
		}
		// GET: api/FridgeItems/5
		[HttpGet("{id}", Name = "GetFridgeItem")]
		public async Task<IActionResult> GetById(Guid id)
		{
			if (id == null)
			{
				return BadRequest();
			}
			var item = await _fridgeRepository.FindById(id);
			if (item == null)
			{
				return NotFound();
			}
			return Ok(item);
		}

		// POST: api/FridgeItems
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] FridgeItem item)
		{
			if (item == null)
			{
				return BadRequest();
			}
			await _fridgeRepository.Add(item);
			return CreatedAtRoute("GetFridgeItem", new { Controller = "FridgeItems", id = item.Id }, item);
		}

		// PUT: api/FridgeItems/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] FridgeItem item)
		{
			if (item == null || id == null)
			{
				return BadRequest();
			}
			var contactObj = await _fridgeRepository.FindById(id);
			if (contactObj == null)
			{
				return NotFound();
			}
			await _fridgeRepository.Update(item);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			await _fridgeRepository.Remove(id);
			return NoContent();
		}
	}
}
