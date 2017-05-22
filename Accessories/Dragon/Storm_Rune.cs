using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Emperia.Accessories.Dragon
{
	public class Storm_Rune : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Storm Rune";
			item.width = 30;
			item.height = 48;
			item.value = 1000000;
			item.rare = 11;
			item.toolTip = "Increases summon damage and magic damage by 11% \nIncreases mana by 20 \nMagic weapons and minions have a chance to fire a lightning bolt";
			item.accessory = true;
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.minionDamage += 0.11f;
			player.magicDamage += 0.11f;
			player.statManaMax2 += 20;
			((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).Storm = true;
        }
	}
}