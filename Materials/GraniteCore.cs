using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Materials
{
	public class GraniteCore : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Granite Core";
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 1000;
			item.rare = 3;
		}
	}
}