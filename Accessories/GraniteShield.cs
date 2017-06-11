using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Emperia.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class GraniteShield : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Granite Shield");
			Tooltip.SetDefault("Made of real rock");
		}
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = 1000;
			item.rare = 2;
			item.accessory = true;
			item.defense = 4;
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GraniteBar", 6); 	
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}