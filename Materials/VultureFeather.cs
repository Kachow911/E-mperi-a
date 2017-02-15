using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Materials
{
	public class VultureFeather : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Vulture Feather";
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			AddTooltip("Plucked from the corpse of a vulture");
			item.value = 1000;
			item.rare = 3;
		}
	}
}