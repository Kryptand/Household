using Kryptand.ChefMaster.Core.HousePlan;
using Kryptand.ChefMaster.Core.SharedKernel.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kryptand.ChefMaster.Infrastructure.HousePlan
{

	public sealed class UserRepository : IUserRepository
	{
		private readonly HousePlanDbContext _dbContext;

		public UserRepository(HousePlanDbContext dbContext) => _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

		public async System.Threading.Tasks.Task Add(User user)
		{
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}
			await _dbContext.Users.AddAsync(user);
			await _dbContext.SaveChangesAsync();
		}

		public async System.Threading.Tasks.Task Remove(Guid id)
		{
			if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}
			var itemToRemove = await _dbContext.Users.SingleOrDefaultAsync(a => a.Id == id);
			if (itemToRemove == null)
			{
				throw new ArgumentOutOfRangeException(nameof(itemToRemove));
			}
			_dbContext.Users.Remove(itemToRemove);
			await _dbContext.SaveChangesAsync();

		}
		public async System.Threading.Tasks.Task<User> FindById(Guid id)
		{
			if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}
			return await _dbContext.Users.SingleOrDefaultAsync(a => a.Id == id);

		}
		public async System.Threading.Tasks.Task<IEnumerable<User>> Find(ISpecification<User> specification)
		{
			if (specification == null)
			{
				throw new ArgumentNullException(nameof(specification));
			}
			var query = _dbContext.Users.AsQueryable();
			return await query.Where(specification.Criteria).ToListAsync();
		}

		public async System.Threading.Tasks.Task<IEnumerable<User>> GetAll() => await _dbContext.Users.ToListAsync();

		public async System.Threading.Tasks.Task Update(User user)
		{
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}
			var itemToUpdate = await _dbContext.Users.SingleOrDefaultAsync(a => a.Id == user.Id);
			if (itemToUpdate == null)
			{
				throw new ArgumentOutOfRangeException(nameof(itemToUpdate));
			}
			_dbContext.Users.Update(user);
			await _dbContext.SaveChangesAsync();
		}

	}
}
