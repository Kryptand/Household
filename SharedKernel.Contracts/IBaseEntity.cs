using System;

namespace Kryptand.ChefMaster.Core.SharedKernel
{
	public interface IBaseEntity
	{
		Guid Id { get; set; }
	}
}