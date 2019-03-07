using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kryptand.ChefMaster.Core.SharedKernel.Contracts;

namespace Kryptand.ChefMaster.Infrastructure.Recipe
{
	public interface IRecipeRepository
	{
		Task Add(Kryptand.ChefMaster.Core.Recipes.Recipe recipe);
		Task<IEnumerable<Kryptand.ChefMaster.Core.Recipes.Recipe>> Find(ISpecification<Kryptand.ChefMaster.Core.Recipes.Recipe> specification);
		Task<Kryptand.ChefMaster.Core.Recipes.Recipe> FindById(Guid id);
		Task<IEnumerable<Kryptand.ChefMaster.Core.Recipes.Recipe>> GetAll();
		Task Remove(Guid id);
		Task Update(Kryptand.ChefMaster.Core.Recipes.Recipe recipe);
	}
}