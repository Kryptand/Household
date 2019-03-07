using Kryptand.ChefMaster.Core.Disposal;
using Kryptand.ChefMaster.Core.SharedKernel.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kryptand.ChefMaster.Infrastructure.Disposal
{

	public sealed class GarbageCollectionDateRepository : IGarbageCollectionDateRepository
	{
		private readonly DisposalDbContext _dbContext;

		public GarbageCollectionDateRepository(DisposalDbContext dbContext) => _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

		public async Task Add(GarbageCollectionDate garbageCollectionDate)
		{
			if (garbageCollectionDate == null)
			{
				throw new ArgumentNullException(nameof(garbageCollectionDate));
			}
			await _dbContext.GarbageCollectionDates.AddAsync(garbageCollectionDate);
			await _dbContext.SaveChangesAsync();
		}

		public async Task Remove(Guid id)
		{
			if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}
			var itemToRemove = await _dbContext.GarbageCollectionDates.SingleOrDefaultAsync(a => a.Id == id);
			if (itemToRemove == null)
			{
				throw new ArgumentOutOfRangeException(nameof(itemToRemove));
			}
			_dbContext.GarbageCollectionDates.Remove(itemToRemove);
			await _dbContext.SaveChangesAsync();

		}
		public async Task<GarbageCollectionDate> FindById(Guid id)
		{
			if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}
			return await _dbContext.GarbageCollectionDates.SingleOrDefaultAsync(a => a.Id == id);

		}
		public async Task<IEnumerable<GarbageCollectionDate>> Find(ISpecification<GarbageCollectionDate> specification)
		{
			if (specification == null)
			{
				throw new ArgumentNullException(nameof(specification));
			}
			var query = _dbContext.GarbageCollectionDates.AsQueryable();
			return await query.Where(specification.Criteria).ToListAsync();
		}

		public async Task<IEnumerable<GarbageCollectionDate>> GetAll() => await _dbContext.GarbageCollectionDates.ToListAsync();
		public IQueryable<GarbageCollectionDate> GetAllAsQueryable() => _dbContext.GarbageCollectionDates.AsQueryable();
		public async Task Update(GarbageCollectionDate garbageCollectionDate)
		{
			if (garbageCollectionDate == null)
			{
				throw new ArgumentNullException(nameof(garbageCollectionDate));
			}
			var itemToUpdate = await _dbContext.GarbageCollectionDates.SingleOrDefaultAsync(a => a.Id == garbageCollectionDate.Id);
			if (itemToUpdate == null)
			{
				throw new ArgumentOutOfRangeException(nameof(itemToUpdate));
			}
			_dbContext.GarbageCollectionDates.Update(garbageCollectionDate);
			await _dbContext.SaveChangesAsync();
		}

	}
}
