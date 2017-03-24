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
    public class RottenMushroom : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Rotten Mushroom";
            item.width = 36;
            item.height = 36;
            item.maxStack = 999;
            AddTooltip("Ugh, it smells horrible.");
            item.rare = 3;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.UseSound = SoundID.Item44;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            //return NPC.downedBoss3;
            return player.ZoneGlowshroom;
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType<Mushor>());
            Main.NewText("Fungal spores drift down from above...");
            Main.PlaySound(SoundID.Roar, player.position, 0);

            return true;
        }
    }
}
