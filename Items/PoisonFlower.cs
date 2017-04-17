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
            AddTooltip("Summons the bloom");
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
            return player.ZoneJungle;
        }

        public override bool UseItem(Player player)
        {
            Mod mod = ModLoader.GetMod("Emperia");
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
			if (!modPlayer.isBloom)
			{
			modPlayer.isBloom = true;
			modPlayer.points = 0;
            Main.NewText("Flora not seen for millenia begins to stir...");
            Main.PlaySound(SoundID.Roar, player.position, 0);

            return true;
			}
			return false;
        }
    }
}
