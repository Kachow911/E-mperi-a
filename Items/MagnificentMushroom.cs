using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Emperia.Bosses.Mushor;

namespace Emperia.Items
{
    public class MagnificentMushroom : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Magnificent Mushroom";
            item.width = 36;
            item.height = 36;
            item.maxStack = 999;
            AddTooltip("These forest shrooms may only heal you for 5, but they don't have a reset. Can only be used in the twilight forest ( not implemented yet )");
            item.rare = 5;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.UseSound = SoundID.Item44;
            item.consumable = true;
        }

        public override bool UseItem(Player player)
        {
           player.statLife += 5;
		   player.HealEffect(5);
		   return true;
        }
    }
}
