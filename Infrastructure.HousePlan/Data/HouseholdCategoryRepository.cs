using Kryptand.ChefMaster.Core.HousePlan;
using Kryptand.ChefMaster.Core.SharedKernel.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kryptand.ChefMaster.Infrastructure.HousePlan
{

	public sealed class HouseholdCategoryRepository : IHouseholdCategoryRepository
	{
		private readonly HousePlanDbContext _dbContext;

		public HouseholdCategoryRepository(HousePlanDbContext dbContext) => _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

		public async System.Threading.Tasks.Task Add(HouseholdCategory householdCategory)
		{
			if (householdCategory == null)
			{
				throw new ArgumentNullException(nameof(householdCategory));
			}
			await _dbContext.HouseholdCategories.AddAsync(householdCategory);
			await _dbContext.SaveChangesAsync();
		}

		public async System.Threading.Tasks.Task Remove(Guid id)
		{
			if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}
			var itemToRemove = await _dbContext.HouseholdCategories.SingleOrDefaultAsync(a => a.Id == id);
			if (itemToRemove == null)
			{
				throw new ArgumentOutOfRangeException(nameof(itemToRemove));
			}
			_dbContext.HouseholdCategories.Remove(itemToRemove);
			await _dbContext.SaveChangesAsync();

		}
		public async Task<HouseholdCategory> FindById(Guid id)
		{
			if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}
			return await _dbContext.HouseholdCategories.SingleOrDefaultAsync(a => a.Id == id);

		}
		public async Task<IEnumerable<HouseholdCategory>> Find(ISpecification<HouseholdCategory> specification)
		{
			if (specification == null)
			{
				throw new ArgumentNullException(nameof(specification));
			}
			var query = _dbContext.HouseholdCategories.AsQueryable();
			return await query.Where(specification.Criteria).ToListAsync();
		}

		public async Task<IEnumerable<HouseholdCategory>> GetAll() => await _dbContext.HouseholdCategories.ToListAsync();

		public async System.Threading.Tasks.Task Update(HouseholdCategory householdCategory)
		{
			if (householdCategory == null)
			{
				throw new ArgumentNullException(nameof(householdCategory));
			}
			var itemToUpdate = await _dbContext.HouseholdCategories.SingleOrDefaultAsync(a => a.Id == householdCategory.Id);
			if (itemToUpdate == null)
			{
				throw new ArgumentOutOfRangeException(nameof(itemToUpdate));
			}
			_dbContext.HouseholdCategories.Update(householdCategory);
			await _dbContext.SaveChangesAsync();
		}

	}
}
