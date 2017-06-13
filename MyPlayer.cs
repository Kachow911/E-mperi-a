using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Emperia.Projectiles;

namespace Emperia
{
    public class MyPlayer : ModPlayer
    {
        public bool wSpirit = false;
        public bool enchanted = false;
		public bool canSpore = true;
		public bool sporeFriend = false;
		public bool Fortress = false;
		public bool ShadowDrone = false;
        public bool spored = false;
		public bool longerInvince = false;
		public bool isBloom = false;
		public bool Scourge = false;
		public bool Storm = false;
        public int enchantedStacks;
		public int points = 0;
		public int rofIncrease = 0;
		int counter = 0;

        public override void ResetEffects()
        {
            wSpirit = false;
            enchanted = false;
			Fortress = false;
			Storm = false;
			sporeFriend = false;
			longerInvince = false;
			Scourge = false;
			ShadowDrone = false;
            enchantedStacks = 0;
			rofIncrease = 0;
            spored = false;
        }

        public override void PostUpdate()
        {
            if (enchanted)
            {
                for (int i = 0; i < Main.rand.Next(enchantedStacks) + 1; i++)
                {
                    float x = Main.rand.NextFloat() * player.Hitbox.Width;
                    float y = Main.rand.NextFloat() * player.Hitbox.Height;
                    Dust.NewDust(new Vector2(player.Hitbox.Location.X + x, player.Hitbox.Location.Y + y), 4, 4, 20);
                }
            }

            if (spored)
            {
                player.jump = 0;
                //player.velocity.Y = Math.Abs(player.velocity.Y);
            }
        }

		public override void UpdateBiomeVisuals()
		{
			//player.ManageSpecialBiomeVisuals("Emperia:Bloom", true, player.Center);
		}
		
		public override void PreUpdate()
		{
			if (Scourge)
			{
				for (int i = 0; i < Main.npc.Length; i++)
				{
					if (Main.npc[i].lifeRegen <= 0)
					{
						Main.npc[i].lifeRegen = (int)(Main.npc[i].lifeRegen * 1.5);
					}
				}
			}
		}
		
       

        public override void UpdateBadLifeRegen()
        {
            if (spored)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 4;
            }
        }
		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			canSpore = true;
            for (int i = 0; i < Main.projectile.Length; i++)
            {
				if (Main.projectile[i].type == mod.ProjectileType("Spore"))
				{
					canSpore = true;
				}
			}
			if (sporeFriend) {
                    if(canSpore)
					{
						if(Main.rand.Next(5) == 0)
						{
			            for (int i = 0; i < 10; i++)
                        {
							Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("Spore"), 14, 0, player.whoAmI, ai1: 36 * i);
                        }
						}
					}
			}
			if (longerInvince == true)
			{
				player.immuneTime = (int)(player.immuneTime * 1.3);
			}
			
			if (Fortress == true)
			{
				player.AddBuff(mod.BuffType("Slag_Skin"), 240, false);
			}
		}
    }
}