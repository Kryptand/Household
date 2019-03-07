using System;
using System.Threading.Tasks;
using Kryptand.ChefMaster.Core.Ingredients;
using Kryptand.ChefMaster.Infrastructure.Ingredients;
using Microsoft.AspNetCore.Mvc;

namespace Ingredient.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class IngredientTypesController : ControllerBase
	{
		private readonly IIngredientTypeRepository _ingredientTypesRepository;
		public IngredientTypesController(IIngredientTypeRepository ingredientTypesRepository) => _ingredientTypesRepository = ingredientTypesRepository ?? throw new System.ArgumentNullException(nameof(ingredientTypesRepository));
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var contactList = await _ingredientTypesRepository.GetAll();
			return Ok(contactList);
		}
		// GET: api/Ingredient/5
		[HttpGet("{id}", Name = "GetIngredientType")]
		public async Task<IActionResult> GetById(Guid id)
		{
			if (id == null)
			{
				return BadRequest();
			}
			var item = await _ingredientTypesRepository.FindById(id);
			if (item == null)
			{
				return NotFound();
			}
			return Ok(item);
		}

		// POST: api/Ingredient
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] IngredientType item)
		{
			if (item == null)
			{
				return BadRequest();
			}
			await _ingredientTypesRepository.Add(item);
			return CreatedAtRoute("GetIngredientType", new { Controller = "IngredientTypes", id = item.Id }, item);
		}

		// PUT: api/Ingredient/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] IngredientType item)
		{
			if (item == null || id == null)
			{
				return BadRequest();
			}
			var contactObj = await _ingredientTypesRepository.FindById(id);
			if (contactObj == null)
			{
				return NotFound();
			}
			await _ingredientTypesRepository.Update(item);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			await _ingredientTypesRepository.Remove(id);
			return NoContent();
		}
	}
}
