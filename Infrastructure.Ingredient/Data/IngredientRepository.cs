using Kryptand.ChefMaster.Core.SharedKernel.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kryptand.ChefMaster.Infrastructure.Ingredients
{
	public class IngredientRepository : IIngredientRepository
	{
		private readonly IngredientDbContext _dbContext;

		public IngredientRepository(IngredientDbContext dbContext) => _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

		public async Task Add(Core.Ingredients.Ingredient ingredient)
		{
			if (ingredient == null)
			{
				throw new ArgumentNullException(nameof(ingredient));
			}
			await _dbContext.Ingredients.AddAsync(ingredient);
			await _dbContext.SaveChangesAsync();
		}
		public async Task<Core.Ingredients.Ingredient> FindById(Guid id)
		{
			if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}
			return await _dbContext.Ingredients.SingleOrDefaultAsync(a => a.Id == id);

		}
		public async Task Remove(Guid id)
		{
			if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}
			var itemToRemove = await _dbContext.Ingredients.SingleOrDefaultAsync(a => a.Id == id);
			if (itemToRemove == null)
			{
				throw new ArgumentOutOfRangeException(nameof(itemToRemove));
			}
			_dbContext.Ingredients.Remove(itemToRemove);
			await _dbContext.SaveChangesAsync();

		}
		public async Task<IEnumerable<Core.Ingredients.Ingredient>> Find(ISpecification<Core.Ingredients.Ingredient> specification)
		{
			if (specification == null)
			{
				throw new ArgumentNullException(nameof(specification));
			}
			var query = _dbContext.Ingredients.AsQueryable();
			return await query.Where(specification.Criteria).ToListAsync();
		}

		public async Task<IEnumerable<Core.Ingredients.Ingredient>> GetAll() => await _dbContext.Ingredients.Include(x=>x.IngredientType).ToListAsync();
		public IQueryable<Core.Ingredients.Ingredient> GetAllAsQueryable() => _dbContext.Ingredients.Include(x => x.IngredientType).AsQueryable();

		public async Task Update(Core.Ingredients.Ingredient ingredient)
		{
			if (ingredient == null)
			{
				throw new ArgumentNullException(nameof(ingredient));
			}
			var itemToUpdate = await _dbContext.Ingredients.SingleOrDefaultAsync(a => a.Id == ingredient.Id);
			if (itemToUpdate == null)
			{
				throw new ArgumentOutOfRangeException(nameof(itemToUpdate));
			}

			_dbContext.Ingredients.Update(ingredient);
			await _dbContext.SaveChangesAsync();
		}
	}
}
