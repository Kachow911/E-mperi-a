using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Items
{
	public class RuinedChest : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Ruined Chest";
			item.width = 26;
			item.height = 22;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 500;
			item.createTile = mod.TileType("RuinedChest");
		}
	}
}