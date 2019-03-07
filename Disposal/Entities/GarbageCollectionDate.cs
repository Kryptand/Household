using Kryptand.ChefMaster.Core.SharedKernel;
using System;

namespace Kryptand.ChefMaster.Core.Disposal
{
	public class GarbageCollectionDate : BaseEntity
	{
		public DateTime Date { get; set; }
		public Guid DisposeCategoryId { get; set; }
		public DisposeCategory Category { get; set; }
		public Guid DisposalLocationId { get; set; }
		public DisposalLocation Location {get;set;}
	}
}
