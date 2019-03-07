using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kryptand.ChefMaster.Core.Disposal;
using Kryptand.ChefMaster.Core.SharedKernel.Contracts;

namespace Kryptand.ChefMaster.Infrastructure.Disposal
{
	public interface IDisposeCategoryRepository
	{
		Task Add(DisposeCategory disposeCategory);
		Task<IEnumerable<DisposeCategory>> Find(ISpecification<DisposeCategory> specification);
		Task<DisposeCategory> FindById(Guid id);
		Task<IEnumerable<DisposeCategory>> GetAll();
		Task Remove(Guid id);
		Task Update(DisposeCategory disposeCategory);
	}
}