using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Items
{
	public class RuinedKey : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Overgrown Key";
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			AddTooltip("Unlocks a Ruined Chest in the overgrown dungeon");
			item.value = 100000;
			item.rare = 3;
		}
	}
}