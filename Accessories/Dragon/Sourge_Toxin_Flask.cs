using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Emperia.Accessories.Dragon
{
	public class Sourge_Toxin_Flask : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Scourge Toxin Flask";
			item.width = 30;
			item.height = 48;
			item.value = 1000000;
			item.rare = 11;
			item.toolTip = "Increases throwing damage and velocity by 8%";
			item.toolTip2 = "Damage over time debuffs are more effective";
			item.accessory = true;
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.thrownDamage += 0.08f;
			player.thrownVelocity += 0.08f;
			((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).Scourge = true;
        }
	}
}