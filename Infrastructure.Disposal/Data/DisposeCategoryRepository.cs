using Kryptand.ChefMaster.Core.Disposal;
using Kryptand.ChefMaster.Core.SharedKernel.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kryptand.ChefMaster.Infrastructure.Disposal
{

	public sealed class DisposeCategoryRepository : IDisposeCategoryRepository
	{
		private readonly DisposalDbContext _dbContext;

		public DisposeCategoryRepository(DisposalDbContext dbContext) => _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

		public async Task Add(DisposeCategory disposeCategory)
		{
			if (disposeCategory == null)
			{
				throw new ArgumentNullException(nameof(disposeCategory));
			}
			await _dbContext.DisposeCategories.AddAsync(disposeCategory);
			await _dbContext.SaveChangesAsync();
		}

		public async Task Remove(Guid id)
		{
			if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}
			var itemToRemove = await _dbContext.DisposeCategories.SingleOrDefaultAsync(a => a.Id == id);
			if (itemToRemove == null)
			{
				throw new ArgumentOutOfRangeException(nameof(itemToRemove));
			}
			_dbContext.DisposeCategories.Remove(itemToRemove);
			await _dbContext.SaveChangesAsync();

		}
		public async Task<DisposeCategory> FindById(Guid id)
		{
			if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}
			return await _dbContext.DisposeCategories.SingleOrDefaultAsync(a => a.Id == id);

		}
		public async Task<IEnumerable<DisposeCategory>> Find(ISpecification<DisposeCategory> specification)
		{
			if (specification == null)
			{
				throw new ArgumentNullException(nameof(specification));
			}
			var query =_dbContext.DisposeCategories.AsQueryable();
			return await query.Where(specification.Criteria).ToListAsync();
		}

		public async Task<IEnumerable<DisposeCategory>> GetAll() => await _dbContext.DisposeCategories.ToListAsync();

		public async Task Update(DisposeCategory disposeCategory)
		{
			if (disposeCategory == null)
			{
				throw new ArgumentNullException(nameof(disposeCategory));
			}
			var itemToUpdate = await _dbContext.DisposeCategories.SingleOrDefaultAsync(a => a.Id == disposeCategory.Id);
			if (itemToUpdate == null)
			{
				throw new ArgumentOutOfRangeException(nameof(itemToUpdate));
			}
			_dbContext.DisposeCategories.Update(disposeCategory);
			await _dbContext.SaveChangesAsync();
		}

	}
}
