using Kryptand.ChefMaster.Core.Ingredients;
using Kryptand.ChefMaster.Core.SharedKernel.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kryptand.ChefMaster.Infrastructure.Ingredients
{
	public class IngredientTypeRepository : IIngredientTypeRepository
	{
	private readonly IngredientDbContext _dbContext;

	public IngredientTypeRepository(IngredientDbContext dbContext) => _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

	public async Task Add(IngredientType ingredientType)
	{
		if (ingredientType == null)
		{
			throw new ArgumentNullException(nameof(ingredientType));
		}
		await _dbContext.IngredientTypes.AddAsync(ingredientType);
		await _dbContext.SaveChangesAsync();
	}

	public async Task Remove(Guid id)
	{
		if (id == null)
		{
			throw new ArgumentNullException(nameof(id));
		}
		var itemToRemove = await _dbContext.IngredientTypes.SingleOrDefaultAsync(a => a.Id == id);
		if (itemToRemove == null)
		{
			throw new ArgumentOutOfRangeException(nameof(itemToRemove));
		}
		_dbContext.IngredientTypes.Remove(itemToRemove);
		await _dbContext.SaveChangesAsync();

	}
		public async Task<IngredientType> FindById(Guid id)
		{
			if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}
			return await _dbContext.IngredientTypes.SingleOrDefaultAsync(a => a.Id == id);

		}
		public async Task<IEnumerable<IngredientType>> Find(ISpecification<IngredientType> specification)
	{
		if (specification == null)
		{
			throw new ArgumentNullException(nameof(specification));
		}
		var query = _dbContext.IngredientTypes.AsQueryable();
		return await query.Where(specification.Criteria).ToListAsync();
	}

	public async Task<IEnumerable<IngredientType>> GetAll() => await _dbContext.IngredientTypes.ToListAsync();

	public async Task Update(IngredientType ingredientType)
	{
		if (ingredientType == null)
		{
			throw new ArgumentNullException(nameof(ingredientType));
		}
		var itemToUpdate = await _dbContext.IngredientTypes.SingleOrDefaultAsync(a => a.Id == ingredientType.Id);
		if (itemToUpdate == null)
		{
			throw new ArgumentOutOfRangeException(nameof(itemToUpdate));
		}
		itemToUpdate.Type = ingredientType.Type;
		await _dbContext.SaveChangesAsync();
	}
}
}
