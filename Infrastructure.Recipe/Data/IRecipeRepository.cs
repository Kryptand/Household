using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kryptand.ChefMaster.Core.SharedKernel.Contracts;

namespace Kryptand.ChefMaster.Infrastructure.Recipe
{
	public interface IRecipeRepository
	{
		Task Add(Core.Recipes.Recipe recipe);
		Task<IEnumerable<Core.Recipes.Recipe>> Find(ISpecification<Core.Recipes.Recipe> specification);
		Task<Core.Recipes.Recipe> FindById(Guid id);
		Task<IEnumerable<Core.Recipes.Recipe>> GetAll();
		Task Remove(Guid id);
		Task Update(Core.Recipes.Recipe recipe);
	}
}