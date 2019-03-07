using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kryptand.ChefMaster.Core.SharedKernel.Contracts;

namespace Kryptand.ChefMaster.Infrastructure.Ingredients
{
	public interface IIngredientRepository
	{
		Task Add(Core.Ingredients.Ingredient ingredient);
		Task<Core.Ingredients.Ingredient> FindById(Guid id);
		Task<IEnumerable<Core.Ingredients.Ingredient>> Find(ISpecification<Core.Ingredients.Ingredient> specification);
		Task<IEnumerable<Core.Ingredients.Ingredient>> GetAll();
		IQueryable<Core.Ingredients.Ingredient> GetAllAsQueryable();
		Task Remove(Guid id);
		Task Update(Core.Ingredients.Ingredient ingredient);
	}
}