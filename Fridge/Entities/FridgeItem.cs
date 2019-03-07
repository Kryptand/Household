using Kryptand.ChefMaster.Core.Ingredients;
using Kryptand.ChefMaster.Core.SharedKernel;
using System;


namespace Kryptand.ChefMaster.Core.Fridge
{
	public class FridgeItem:BaseEntity
	{
		public Ingredient Ingredient { get; set; }
		public DateTime StorageLife { get; set; }
		public int Amount { get; set; }
		public AmountUnit Unit { get; set; }
	}
}
