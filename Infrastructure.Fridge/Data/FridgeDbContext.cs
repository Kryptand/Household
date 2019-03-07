using Microsoft.EntityFrameworkCore;
using Kryptand.ChefMaster.Core.Fridge;

namespace Kryptand.ChefMaster.Infrastructure.Fridge
{
	public class FridgeDbContext:DbContext
	{


		public FridgeDbContext(DbContextOptions<FridgeDbContext> options)
			: base(options) { }

		public DbSet<FridgeItem> FridgeItems{ get; set; }

	}
}
