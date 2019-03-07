using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kryptand.ChefMaster.Core.Ingredients;
using Kryptand.ChefMaster.Core.SharedKernel.Contracts;

namespace Kryptand.ChefMaster.Infrastructure.Ingredients
{
	public interface IIngredientTypeRepository
	{
		Task Add(IngredientType ingredientType);
		Task<IngredientType> FindById(Guid id);
		Task<IEnumerable<IngredientType>> Find(ISpecification<IngredientType> specification);
		Task<IEnumerable<IngredientType>> GetAll();
		Task Remove(Guid id);
		Task Update(IngredientType ingredientType);
	}
}