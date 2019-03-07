namespace Kryptand.ChefMaster.Core.SharedKernel.Contracts
{
	public interface IDomainEventDispatcher
	{
		void Dispatch(IBaseDomainEvent domainEvent);
	}
}
