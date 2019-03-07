namespace Kryptand.ChefMaster.Core.SharedKernel.Contracts
{
	public interface IHandle<T> where T : IBaseDomainEvent
    {
        void Handle(T domainEvent);
    }
}