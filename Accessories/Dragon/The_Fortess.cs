using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Emperia.Accessories.Dragon
{
	public class The_Fortess : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "The Fortress";
			item.width = 24;
			item.height = 28;
			item.value = 1000000;
			item.rare = 11;
			item.accessory = true;
			item.defense = 8;
			AddTooltip("Reduced movement speed \nTaking damage temporarily grants you 'Slag Skin'");
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed -= 0.2f;
			((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).Fortress = true;
        }
	}
}