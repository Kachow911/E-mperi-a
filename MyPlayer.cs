using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Emperia.Weapons.Enchanted;
using Emperia.Projectiles;

namespace Emperia
{
    public class MyPlayer : ModPlayer
    {
        public bool wSpirit = false;
        public bool enchanted = false;
		public bool ShadowDrone = false;
        public bool spored = false;
		public bool longerInvince = false;
		public bool isBloom = false;
        public int enchantedStacks;
		public int points = 0;
		public int rofIncrease = 0;

        public override void ResetEffects()
        {
            wSpirit = false;
            enchanted = false;
			longerInvince = false;
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

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            EnchantedInfo info = proj.GetModInfo<EnchantedInfo>(mod);
            if (info.givesEnchanted || info.givesMinorEnchanted)
            {
                if (target.life <= 0)   //if we kill the target
                {   //if minor enchanted, 1 sec of enchanted buff added. otherwise full 4 secs
                    player.AddBuff(mod.BuffType<Buffs.Enchanted>(), info.givesMinorEnchanted ? Buffs.Enchanted.minorStackDuration : Buffs.Enchanted.stackDuration);
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
			if (longerInvince == true)
			{
				player.immuneTime = (int)(player.immuneTime * 1.3);
			}
		}
    }
}