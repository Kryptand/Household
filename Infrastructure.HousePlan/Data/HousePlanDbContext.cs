using Microsoft.EntityFrameworkCore;
using Kryptand.ChefMaster.Core.HousePlan;

namespace Kryptand.ChefMaster.Infrastructure.HousePlan
{
	public class HousePlanDbContext : DbContext
	{
		public HousePlanDbContext(DbContextOptions<HousePlanDbContext> options)
			: base(options) { }

		public DbSet<HouseholdCategory> HouseholdCategories { get; set; }
		public DbSet<Task> Tasks { get; set; }
		public DbSet<User> Users { get; set; }

	}
}
