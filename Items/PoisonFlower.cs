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
    public class PoisonFlower : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Poisonous Flower";
            item.width = 36;
            item.height = 36;
            item.maxStack = 999;
            AddTooltip("Don't eat it");
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
        }

        public override bool UseItem(Player player)
        {
            Mod mod = ModLoader.GetMod("Emperia");
			MyPlayer modPlayer = p.GetModPlayer<MyPlayer>(mod);
			modPlayer.isBloom = true;
            Main.NewText("Flora not seen for millenia begins to stir...");
            Main.PlaySound(SoundID.Roar, player.position, 0);

            return true;
        }
    }
}
