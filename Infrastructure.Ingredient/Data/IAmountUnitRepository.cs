using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kryptand.ChefMaster.Core.Ingredients;
using Kryptand.ChefMaster.Core.SharedKernel.Contracts;

namespace Kryptand.ChefMaster.Infrastructure.Ingredients
{
	public interface IAmountUnitRepository
	{
		Task Add(AmountUnit amountUnit);
		Task<AmountUnit> FindById(Guid id);
		Task<IEnumerable<AmountUnit>> Find(ISpecification<AmountUnit> specification);
		Task<IEnumerable<AmountUnit>> GetAll();
		Task Remove(Guid id);
		Task Update(AmountUnit amountUnit);
	}
}