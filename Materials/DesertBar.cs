using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Materials
{
	public class DesertBar : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Desert Bar";
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			AddTooltip("Forged with all of the elements of a desert");
			item.value = 1000;
			item.rare = 3;
		}

	public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AntlionMandible, 1);
			recipe.AddIngredient(ItemID.Cactus, 2);
			recipe.AddIngredient(ItemID.SandBlock, 10);
			recipe.AddTile(TileID.Furnaces);  
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}