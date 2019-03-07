using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kryptand.ChefMaster.Core.Disposal;
using Kryptand.ChefMaster.Core.SharedKernel.Contracts;

namespace Kryptand.ChefMaster.Infrastructure.Disposal
{
	public interface IDisposalLocationRepository
	{
		Task Add(DisposalLocation disposalLocation);
		Task<IEnumerable<DisposalLocation>> Find(ISpecification<DisposalLocation> specification);
		Task<DisposalLocation> FindById(Guid id);
		Task<IEnumerable<DisposalLocation>> GetAll();
		Task Remove(Guid id);
		Task Update(DisposalLocation disposalLocation);
	}
}