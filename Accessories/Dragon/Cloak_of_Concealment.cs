using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Emperia.Accessories.Dragon
{
	public class Cloak_of_Concealment : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Cloak of Concealment";
			item.width = 30;
			item.height = 48;
			item.value = 1000000;
			item.rare = 11;
			item.toolTip = "Increased movement speed and immunity time";
			item.toolTip2 = "Grants stealth while not moving or taking damage";
			item.accessory = true;
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed += 0.2f;
			((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).longerInvince = true;
			player.shroomiteStealth = true;
        }
	}
}