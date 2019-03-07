using Kryptand.ChefMaster.Core.SharedKernel.Contracts;
using System;

namespace Kryptand.ChefMaster.Core.SharedKernel
{
    public abstract class BaseDomainEvent : IBaseDomainEvent
	{
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}