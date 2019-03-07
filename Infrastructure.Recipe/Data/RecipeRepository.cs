using Kryptand.ChefMaster.Core.SharedKernel.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kryptand.ChefMaster.Infrastructure.Recipe
{
	public sealed class RecipeRepository : IRecipeRepository
	{
		private readonly RecipeDbContext _dbContext;

		public RecipeRepository(RecipeDbContext dbContext) => _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

		public async Task Add(Kryptand.ChefMaster.Core.Recipes.Recipe recipe)
		{
			if (recipe == null)
			{
				throw new ArgumentNullException(nameof(recipe));
			}
			await _dbContext.Recipes.AddAsync(recipe);
			await _dbContext.SaveChangesAsync();
		}

		public async Task Remove(Guid id)
		{
			if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}
			var itemToRemove = await _dbContext.Recipes.SingleOrDefaultAsync(a => a.Id == id);
			if (itemToRemove == null)
			{
				throw new ArgumentOutOfRangeException(nameof(itemToRemove));
			}
			_dbContext.Recipes.Remove(itemToRemove);
			await _dbContext.SaveChangesAsync();

		}
		public async Task<Kryptand.ChefMaster.Core.Recipes.Recipe> FindById(Guid id)
		{
			if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}
			return await _dbContext.Recipes.SingleOrDefaultAsync(a => a.Id == id);

		}
		public async Task<IEnumerable<Kryptand.ChefMaster.Core.Recipes.Recipe>> Find(ISpecification<Kryptand.ChefMaster.Core.Recipes.Recipe> specification)
		{
			if (specification == null)
			{
				throw new ArgumentNullException(nameof(specification));
			}
			var query = _dbContext.Recipes.AsQueryable();
			return await query.Where(specification.Criteria).ToListAsync();
		}

		public async Task<IEnumerable<Kryptand.ChefMaster.Core.Recipes.Recipe>> GetAll() => await _dbContext.Recipes.Include(x=>x.Ingredients).Include(y=>y.RecipeSteps).Include(z=>z.RecipeImages).ToListAsync();

		public async Task Update(Kryptand.ChefMaster.Core.Recipes.Recipe recipe)
		{
			if (recipe == null)
			{
				throw new ArgumentNullException(nameof(recipe));
			}
			var itemToUpdate = await _dbContext.Recipes.SingleOrDefaultAsync(a => a.Id == recipe.Id);
			if (itemToUpdate == null)
			{
				throw new ArgumentOutOfRangeException(nameof(itemToUpdate));
			}
			_dbContext.Recipes.Update(recipe);
			await _dbContext.SaveChangesAsync();
		}

	}
}
