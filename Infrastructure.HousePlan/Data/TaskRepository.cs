using Kryptand.ChefMaster.Core.SharedKernel.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kryptand.ChefMaster.Infrastructure.HousePlan
{

	public sealed class TaskRepository : ITaskRepository
	{
		private readonly HousePlanDbContext _dbContext;

		public TaskRepository(HousePlanDbContext dbContext) => _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

		public async System.Threading.Tasks.Task Add(Core.HousePlan.Task task)
		{
			if (task == null)
			{
				throw new ArgumentNullException(nameof(task));
			}
			await _dbContext.Tasks.AddAsync(task);
			await _dbContext.SaveChangesAsync();
		}

		public async System.Threading.Tasks.Task Remove(Guid id)
		{
			if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}
			var itemToRemove = await _dbContext.Tasks.SingleOrDefaultAsync(a => a.Id == id);
			if (itemToRemove == null)
			{
				throw new ArgumentOutOfRangeException(nameof(itemToRemove));
			}
			_dbContext.Tasks.Remove(itemToRemove);
			await _dbContext.SaveChangesAsync();

		}
		public async Task<Core.HousePlan.Task> FindById(Guid id)
		{
			if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}
			return await _dbContext.Tasks.SingleOrDefaultAsync(a => a.Id == id);

		}
		public async Task<IEnumerable<Core.HousePlan.Task>> Find(ISpecification<Core.HousePlan.Task> specification)
		{
			if (specification == null)
			{
				throw new ArgumentNullException(nameof(specification));
			}
			var query = _dbContext.Tasks.AsQueryable();
			return await query.Where(specification.Criteria).ToListAsync();
		}

		public async Task<IEnumerable<Core.HousePlan.Task>> GetAll() => await _dbContext.Tasks.ToListAsync();
		public IQueryable<Core.HousePlan.Task> GetAllAsQueryable() => _dbContext.Tasks.AsQueryable();
		public async System.Threading.Tasks.Task Update(Core.HousePlan.Task task)
		{
			if (task == null)
			{
				throw new ArgumentNullException(nameof(task));
			}
			var itemToUpdate = await _dbContext.Tasks.SingleOrDefaultAsync(a => a.Id == task.Id);
			if (itemToUpdate == null)
			{
				throw new ArgumentOutOfRangeException(nameof(itemToUpdate));
			}
			_dbContext.Tasks.Update(task);
			await _dbContext.SaveChangesAsync();
		}

	}
}
