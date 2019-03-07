using System;

namespace Kryptand.ChefMaster.Core.SharedKernel.Contracts
{
	public interface IBaseDomainEvent
	{
		DateTime DateOccurred { get; }
	}
}