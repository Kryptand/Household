using Kryptand.ChefMaster.Core.Ingredients;
using Kryptand.ChefMaster.Core.SharedKernel.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kryptand.ChefMaster.Infrastructure.Ingredients
{
	public sealed class AmountUnitRepository : IAmountUnitRepository
	{
		private readonly IngredientDbContext _dbContext;

		public AmountUnitRepository(IngredientDbContext dbContext) => _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

		public async Task Add(AmountUnit amountUnit)
		{
			if (amountUnit == null)
			{
				throw new ArgumentNullException(nameof(amountUnit));
			}
			await _dbContext.Units.AddAsync(amountUnit);
			await _dbContext.SaveChangesAsync();
		}

		public async Task Remove(Guid id)
		{
			if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}
			var itemToRemove = await _dbContext.Units.SingleOrDefaultAsync(a => a.Id == id);
			if (itemToRemove == null)
			{
				throw new ArgumentOutOfRangeException(nameof(itemToRemove));
			}
			_dbContext.Units.Remove(itemToRemove);
			await _dbContext.SaveChangesAsync();

		}
		public async Task<AmountUnit> FindById(Guid id)
		{
			if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}
			return await _dbContext.Units.SingleOrDefaultAsync(a => a.Id == id);

		}
		public async Task<IEnumerable<AmountUnit>> Find(ISpecification<AmountUnit> specification)
		{
			if (specification == null)
			{
				throw new ArgumentNullException(nameof(specification));
			}
			var query = _dbContext.Units.AsQueryable();
			return await query.Where(specification.Criteria).ToListAsync();
		}

		public async Task<IEnumerable<AmountUnit>> GetAll() => await _dbContext.Units.ToListAsync();

		public async Task Update(AmountUnit amountUnit)
		{
			if (amountUnit == null)
			{
				throw new ArgumentNullException(nameof(amountUnit));
			}
			var itemToUpdate = await _dbContext.Units.SingleOrDefaultAsync(a => a.Id == amountUnit.Id);
			if (itemToUpdate == null)
			{
				throw new ArgumentOutOfRangeException(nameof(itemToUpdate));
			}
			itemToUpdate.UnitName = amountUnit.UnitName;
			await _dbContext.SaveChangesAsync();
		}
	}
}
