using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Materials
{
	public class IceShard : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Frozen Shard";
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			AddTooltip("It belongs to the ice biome");
			item.value = 1000;
			item.rare = 3;
		}
	}
}