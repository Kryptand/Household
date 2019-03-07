using Microsoft.EntityFrameworkCore;
using Kryptand.ChefMaster.Core.Recipes;
namespace Kryptand.ChefMaster.Infrastructure.Recipe
{
	public class RecipeDbContext : DbContext
	{


		public RecipeDbContext(DbContextOptions<RecipeDbContext> options)
			: base(options) { }

		public DbSet<Kryptand.ChefMaster.Core.Recipes.Recipe> Recipes { get; set; }
		public DbSet<RecipeImage> RecipeImages { get; set; }

	}
}

