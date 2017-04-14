using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Materials
{
	public class Fungoo : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Fungoo";
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			AddTooltip("You don't want to know what this is");
			item.value = 1000;
			item.rare = 3;
		}
	}
}