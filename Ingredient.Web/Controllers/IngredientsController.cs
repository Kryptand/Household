using System;
using System.Threading.Tasks;
using Kryptand.ChefMaster.Infrastructure.Ingredients;
using Microsoft.AspNetCore.Mvc;

namespace Ingredient.Web.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
		private readonly IIngredientRepository _ingredientsRepository;
		public IngredientsController(IIngredientRepository ingredientRepository) => _ingredientsRepository = ingredientRepository ?? throw new System.ArgumentNullException(nameof(ingredientRepository));
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var contactList = await _ingredientsRepository.GetAll();
			return Ok(contactList);
		}
		// GET: api/Ingredient/5
		[HttpGet("{id}", Name = "GetIngredient")]
		public async Task<IActionResult> GetById(Guid id)
		{
			if (id == null)
			{
				return BadRequest();
			}
			var item = await _ingredientsRepository.FindById(id);
			if (item == null)
			{
				return NotFound();
			}
			return Ok(item);
		}

		// POST: api/Ingredient
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] Kryptand.ChefMaster.Core.Ingredients.Ingredient item)
		{
			if (item == null)
			{
				return BadRequest();
			}
			await _ingredientsRepository.Add(item);
			return CreatedAtRoute("GetIngredient", new { Controller = "Ingredient", id = item.Id }, item);
		}

		// PUT: api/Ingredient/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] Kryptand.ChefMaster.Core.Ingredients.Ingredient item)
		{
			if (item == null || id == null)
			{
				return BadRequest();
			}
			var contactObj = await _ingredientsRepository.FindById(id);
			if (contactObj == null)
			{
				return NotFound();
			}
			await _ingredientsRepository.Update(item);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			await _ingredientsRepository.Remove(id);
			return NoContent();
		}
	}
}
