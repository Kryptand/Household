using Microsoft.EntityFrameworkCore;
using Kryptand.ChefMaster.Core.Disposal;

namespace Kryptand.ChefMaster.Infrastructure.Disposal
{
	public class DisposalDbContext:DbContext
	{


		public DisposalDbContext(DbContextOptions<DisposalDbContext> options)
			: base(options) { }

		public DbSet<DisposalLocation> DisposalLocations{ get; set; }
		public DbSet<DisposeCategory> DisposeCategories{ get; set; }
		public DbSet<GarbageCollectionDate> GarbageCollectionDates{ get; set; }
	}
}
