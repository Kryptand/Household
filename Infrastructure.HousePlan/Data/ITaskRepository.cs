using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kryptand.ChefMaster.Core.SharedKernel.Contracts;

namespace Kryptand.ChefMaster.Infrastructure.HousePlan
{
	public interface ITaskRepository
	{
		System.Threading.Tasks.Task Add(Core.HousePlan.Task task);
		Task<IEnumerable<Core.HousePlan.Task>> Find(ISpecification<Core.HousePlan.Task> specification);
		Task<Core.HousePlan.Task> FindById(Guid id);
		Task<IEnumerable<Core.HousePlan.Task>> GetAll();
		IQueryable<Core.HousePlan.Task> GetAllAsQueryable();
		System.Threading.Tasks.Task Remove(Guid id);
		System.Threading.Tasks.Task Update(Core.HousePlan.Task task);
	}
}