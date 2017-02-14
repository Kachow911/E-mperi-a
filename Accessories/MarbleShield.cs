using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Emperia.Accessories
{
	public class MarbleShield : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Shield);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Marble Shield";
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
			recipe.AddIngredient(null, "MarbleBar", 6); 	
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}