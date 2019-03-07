using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kryptand.ChefMaster.Core.Fridge;
using Kryptand.ChefMaster.Core.SharedKernel.Contracts;

namespace Kryptand.ChefMaster.Infrastructure.Fridge
{
	public interface IFridgeRepository
	{
		Task Add(FridgeItem fridgeItem);
		Task<IEnumerable<FridgeItem>> Find(ISpecification<FridgeItem> specification);
		Task<FridgeItem> FindById(Guid id);
		Task<IEnumerable<FridgeItem>> GetAll();
		Task Remove(Guid id);
		Task Update(FridgeItem fridgeItem);
	}
}