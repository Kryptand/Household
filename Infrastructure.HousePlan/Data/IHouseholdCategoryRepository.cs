using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kryptand.ChefMaster.Core.HousePlan;
using Kryptand.ChefMaster.Core.SharedKernel.Contracts;

namespace Kryptand.ChefMaster.Infrastructure.HousePlan
{
	public interface IHouseholdCategoryRepository
	{
		System.Threading.Tasks.Task Add(HouseholdCategory householdCategory);
		Task<IEnumerable<HouseholdCategory>> Find(ISpecification<HouseholdCategory> specification);
		Task<HouseholdCategory> FindById(Guid id);
		Task<IEnumerable<HouseholdCategory>> GetAll();
		System.Threading.Tasks.Task Remove(Guid id);
		System.Threading.Tasks.Task Update(HouseholdCategory householdCategory);
	}
}