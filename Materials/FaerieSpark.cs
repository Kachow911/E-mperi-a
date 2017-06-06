using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Materials
{
	public class FaerieSpark : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "FaerieSpark";
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			AddTooltip("Magic straight from the old world");
			item.value = 1000;
			item.rare = 3;
		}
	}
}