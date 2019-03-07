using Kryptand.ChefMaster.Core.Fridge;
using Kryptand.ChefMaster.Core.SharedKernel.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kryptand.ChefMaster.Infrastructure.Fridge
{

	public sealed class FridgeRepository : IFridgeRepository
	{
		private readonly FridgeDbContext _dbContext;

		public FridgeRepository(FridgeDbContext dbContext) => _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

		public async Task Add(FridgeItem fridgeItem)
		{
			if (fridgeItem == null)
			{
				throw new ArgumentNullException(nameof(fridgeItem));
			}
			await _dbContext.FridgeItems.AddAsync(fridgeItem);
			await _dbContext.SaveChangesAsync();
		}

		public async Task Remove(Guid id)
		{
			if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}
			var itemToRemove = await _dbContext.FridgeItems.SingleOrDefaultAsync(a => a.Id == id);
			if (itemToRemove == null)
			{
				throw new ArgumentOutOfRangeException(nameof(itemToRemove));
			}
			_dbContext.FridgeItems.Remove(itemToRemove);
			await _dbContext.SaveChangesAsync();

		}
		public async Task<FridgeItem> FindById(Guid id)
		{
			if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}
			return await _dbContext.FridgeItems.SingleOrDefaultAsync(a => a.Id == id);

		}
		public async Task<IEnumerable<FridgeItem>> Find(ISpecification<FridgeItem> specification)
		{
			if (specification == null)
			{
				throw new ArgumentNullException(nameof(specification));
			}
			var query = _dbContext.FridgeItems.AsQueryable();
			return await query.Where(specification.Criteria).ToListAsync();
		}

		public async Task<IEnumerable<FridgeItem>> GetAll() => await _dbContext.FridgeItems.ToListAsync();

		public async Task Update(FridgeItem fridgeItem)
		{
			if (fridgeItem == null)
			{
				throw new ArgumentNullException(nameof(fridgeItem));
			}
			var itemToUpdate = await _dbContext.FridgeItems.SingleOrDefaultAsync(a => a.Id == fridgeItem.Id);
			if (itemToUpdate == null)
			{
				throw new ArgumentOutOfRangeException(nameof(itemToUpdate));
			}
			_dbContext.FridgeItems.Update(fridgeItem);
			await _dbContext.SaveChangesAsync();
		}

	}
}
