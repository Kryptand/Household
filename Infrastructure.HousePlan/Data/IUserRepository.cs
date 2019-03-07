using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kryptand.ChefMaster.Core.HousePlan;
using Kryptand.ChefMaster.Core.SharedKernel.Contracts;

namespace Kryptand.ChefMaster.Infrastructure.HousePlan
{
	public interface IUserRepository
	{
		System.Threading.Tasks.Task Add(User user);
		Task<IEnumerable<User>> Find(ISpecification<User> specification);
		Task<User> FindById(Guid id);
		Task<IEnumerable<User>> GetAll();
		System.Threading.Tasks.Task Remove(Guid id);
		System.Threading.Tasks.Task Update(User user);
	}
}