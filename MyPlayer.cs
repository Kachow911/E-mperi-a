using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia
{
    public class MyPlayer : ModPlayer
    {
        public bool wSpirit = false;
        public bool enchanted = false;
        public int enchantedStacks;

        public override void ResetEffects()
        {
            wSpirit = false;
            enchanted = false;
            enchantedStacks = 0;
        }

        public override void PostUpdate()
        {
            if (enchanted)
            {
                for (int i = 0; i < Main.rand.Next(enchantedStacks); i++)
                {
                    float x = Main.rand.NextFloat() * player.Hitbox.Width;
                    float y = Main.rand.NextFloat() * player.Hitbox.Height;
                    Dust.NewDust(new Vector2(player.Hitbox.Location.X + x, player.Hitbox.Location.Y + y), 4, 4, 20);
                }
            }
        }
    }
}