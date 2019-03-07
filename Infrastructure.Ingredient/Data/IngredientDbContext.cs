using Kryptand.ChefMaster.Core.Ingredients;
using Microsoft.EntityFrameworkCore;

namespace Kryptand.ChefMaster.Infrastructure.Ingredients
{
	public class IngredientDbContext:DbContext
	{


		public IngredientDbContext(DbContextOptions<IngredientDbContext> options)
			: base(options) { }
		public DbSet<AmountUnit> Units { get; set; }
		public DbSet<IngredientType> IngredientTypes{ get; set; }
		public DbSet<Core.Ingredients.Ingredient> Ingredients{ get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<IngredientType>()
				.HasIndex(b => b.Type);
			modelBuilder.Entity<Core.Ingredients.Ingredient>().HasIndex(i => i.Name);
		}
	}
}
