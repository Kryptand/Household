using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kryptand.ChefMaster.Core.Disposal;
using Kryptand.ChefMaster.Core.SharedKernel.Contracts;

namespace Kryptand.ChefMaster.Infrastructure.Disposal
{
	public interface IGarbageCollectionDateRepository
	{
		Task Add(GarbageCollectionDate garbageCollectionDate);
		Task<IEnumerable<GarbageCollectionDate>> Find(ISpecification<GarbageCollectionDate> specification);
		Task<GarbageCollectionDate> FindById(Guid id);
		Task<IEnumerable<GarbageCollectionDate>> GetAll();
		IQueryable<GarbageCollectionDate> GetAllAsQueryable();
		Task Remove(Guid id);
		Task Update(GarbageCollectionDate garbageCollectionDate);
	}
}