using System;
using System.Threading.Tasks;
using Kryptand.ChefMaster.Infrastructure.Recipe;
using Microsoft.AspNetCore.Mvc;

namespace Recipe.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RecipesController : ControllerBase
	{
		// GET: api/Recipe
		private readonly IRecipeRepository _recipeRepository;
		public RecipesController(IRecipeRepository recipeRepository) => _recipeRepository = recipeRepository ?? throw new System.ArgumentNullException(nameof(recipeRepository));
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var Recipes = await _recipeRepository.GetAll();
			return Ok(Recipes);
		}
		// GET: api/AmountUnit/5
		[HttpGet("{id}", Name = "GetRecipe")]
		public async Task<IActionResult> GetById(Guid id)
		{
			if (id == null)
			{
				return BadRequest();
			}
			var item = await _recipeRepository.FindById(id);
			if (item == null)
			{
				return NotFound();
			}
			return Ok(item);
		}

		// POST: api/AmountUnit
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] Kryptand.ChefMaster.Core.Recipes.Recipe item)
		{
			if (item == null)
			{
				return BadRequest();
			}
			await _recipeRepository.Add(item);
			return CreatedAtRoute("GetRecipe", new { Controller = "Recipe", id = item.Id }, item);
		}

		// PUT: api/AmountUnit/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] Kryptand.ChefMaster.Core.Recipes.Recipe item)
		{
			if (item == null || id == null)
			{
				return BadRequest();
			}
			var foundRecipe = await _recipeRepository.FindById(id);
			if (foundRecipe == null)
			{
				return NotFound();
			}
			await _recipeRepository.Update(item);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			await _recipeRepository.Remove(id);
			return NoContent();
		}
	}
}

