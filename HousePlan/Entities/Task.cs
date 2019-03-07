using Kryptand.ChefMaster.Core.SharedKernel;
using System;
using System.Collections.Generic;


namespace Kryptand.ChefMaster.Core.HousePlan
{
	public class Task:BaseEntity
	{

	public DateTime DueAt { get; set; }
	public bool Done { get; set; }
	public DateTime DoneAt{ get; set; }
		public Guid CategoryId { get; set; }
		public Task Category { get; set; }
	public virtual ICollection<User> Users{ get; set; }
	}
}
