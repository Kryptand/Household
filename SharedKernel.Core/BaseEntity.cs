using System;

namespace Kryptand.ChefMaster.Core.SharedKernel
{
	// This can be modified to BaseEntity<TId> to support multiple key types (e.g. Guid)
	public abstract class BaseEntity : IBaseEntity
	{
        public Guid Id { get; set; }

     
    }
}