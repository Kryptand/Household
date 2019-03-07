using Kryptand.ChefMaster.Core.Disposal;
using Kryptand.ChefMaster.Core.SharedKernel.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kryptand.ChefMaster.Infrastructure.Disposal
{

	public sealed class DisposalLocationRepository : IDisposalLocationRepository
	{
		private readonly DisposalDbContext _dbContext;

		public DisposalLocationRepository(DisposalDbContext dbContext) => _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

		public async Task Add(DisposalLocation disposalLocation)
		{
			if (disposalLocation == null)
			{
				throw new ArgumentNullException(nameof(disposalLocation));
			}
			await _dbContext.DisposalLocations.AddAsync(disposalLocation);
			await _dbContext.SaveChangesAsync();
		}

		public async Task Remove(Guid id)
		{
			if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}
			var itemToRemove = await _dbContext.DisposalLocations.SingleOrDefaultAsync(a => a.Id == id);
			if (itemToRemove == null)
			{
				throw new ArgumentOutOfRangeException(nameof(itemToRemove));
			}
			_dbContext.DisposalLocations.Remove(itemToRemove);
			await _dbContext.SaveChangesAsync();

		}
		public async Task<DisposalLocation> FindById(Guid id)
		{
			if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}
			return await _dbContext.DisposalLocations.SingleOrDefaultAsync(a => a.Id == id);

		}
		public async Task<IEnumerable<DisposalLocation>> Find(ISpecification<DisposalLocation> specification)
		{
			if (specification == null)
			{
				throw new ArgumentNullException(nameof(specification));
			}
			var query = _dbContext.DisposalLocations.AsQueryable();
			return await query.Where(specification.Criteria).ToListAsync();
		}

		public async Task<IEnumerable<DisposalLocation>> GetAll() => await _dbContext.DisposalLocations.ToListAsync();

		public async Task Update(DisposalLocation disposalLocation)
		{
			if (disposalLocation == null)
			{
				throw new ArgumentNullException(nameof(disposalLocation));
			}
			var itemToUpdate = await _dbContext.DisposalLocations.SingleOrDefaultAsync(a => a.Id == disposalLocation.Id);
			if (itemToUpdate == null)
			{
				throw new ArgumentOutOfRangeException(nameof(itemToUpdate));
			}
			_dbContext.DisposalLocations.Update(disposalLocation);
			await _dbContext.SaveChangesAsync();
		}

	}
}
