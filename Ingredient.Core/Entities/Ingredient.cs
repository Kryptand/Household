using Kryptand.ChefMaster.Core.SharedKernel;

namespace Kryptand.ChefMaster.Core.Ingredients
{
	public class Ingredient : BaseEntity
	{
		public string Name { get; set; }
		
		public System.Guid IngredientTypeId {get;set;}
		public IngredientType IngredientType { get; set; }
	}
}
