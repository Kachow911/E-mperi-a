using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Minions.WoodSpirit
{
    public class WoodSpirit : ModProjectile
    {
    	
        public override void SetDefaults()
        {
            projectile.name = "Wood Spirit";
            projectile.width = 34;
            projectile.height = 48;
            projectile.netImportant = true;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.minionSlots = 1f;
            projectile.timeLeft = 18000;
            Main.projFrames[projectile.type] = 1;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.timeLeft *= 5;
            projectile.minion = true;
        }

        public override void AI()
        {
        	float num633 = 0f;
			float num634 = 0f;
			float num635 = 0f;
			float num636 = 0f;
			if (projectile.type == mod.ProjectileType("WoodSpirit"))
			{
				num633 = 700f;
				num634 = 800f;
				num635 = 1200f;
				num636 = 150f;
			}
			bool flag64 = projectile.type == mod.ProjectileType("WoodSpirit");
			Player player = Main.player[projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
			if (flag64)
			{
				if (player.dead)
				{
					modPlayer.wSpirit = false;
				}
				if (modPlayer.wSpirit)
				{
					projectile.timeLeft = 2;
				}
			}
			float num637 = 0.05f;
			for (int num638 = 0; num638 < 1000; num638++)
			{
				bool flag23 = (Main.projectile[num638].type == mod.ProjectileType("WoodSpirit"));
				if (num638 != projectile.whoAmI && Main.projectile[num638].active && Main.projectile[num638].owner == projectile.owner && flag23 && Math.Abs(projectile.position.X - Main.projectile[num638].position.X) + Math.Abs(projectile.position.Y - Main.projectile[num638].position.Y) < (float)projectile.width)
				{
					if (projectile.position.X < Main.projectile[num638].position.X)
					{
						projectile.velocity.X = (projectile.velocity.X - num637)*2/3;
					}
					else
					{
						projectile.velocity.X = (projectile.velocity.X + num637)*2/3;
					}
					if (projectile.position.Y < Main.projectile[num638].position.Y)
					{
						projectile.velocity.Y = (projectile.velocity.Y - num637)*2/3;
					}
					else
					{
						projectile.velocity.Y = (projectile.velocity.Y + num637)*2/3;
					}
				}
			}
			bool flag24 = false;
			if (projectile.ai[0] == 2f && projectile.type == mod.ProjectileType("WoodSpirit"))
			{
				projectile.ai[1] += 1f;
				projectile.extraUpdates = 1;
				if (projectile.ai[1] > 40f)
				{
					projectile.ai[1] = 1f;
					projectile.ai[0] = 0f;
					projectile.extraUpdates = 0;
					projectile.numUpdates = 0;
					projectile.netUpdate = true;
				}
				else
				{
					flag24 = true;
				}
			}
			if (flag24)
			{
				return;
			}
			Vector2 vector46 = projectile.position;
			bool flag25 = false;
			if (projectile.ai[0] != 1f && (projectile.type == mod.ProjectileType("WoodSpirit")))
			{
				projectile.tileCollide = false;
			}
			if (projectile.tileCollide && WorldGen.SolidTile(Framing.GetTileSafely((int)projectile.Center.X / 16, (int)projectile.Center.Y / 16)))
			{
				projectile.tileCollide = false;
			}
			for (int num645 = 0; num645 < 200; num645++)
			{
				NPC nPC2 = Main.npc[num645];
				if (nPC2.CanBeChasedBy(projectile, false))
				{
					float num646 = Vector2.Distance(nPC2.Center, projectile.Center);
					if (((Vector2.Distance(projectile.Center, vector46) > num646 && num646 < num633) || !flag25) && Collision.CanHitLine(projectile.position, projectile.width, projectile.height, nPC2.position, nPC2.width, nPC2.height))
					{
						num633 = num646;
						vector46 = nPC2.Center;
						flag25 = true;
					}
				}
			}
			float num647 = num634;
			if (flag25)
			{
				num647 = num635;
			}
			if (Vector2.Distance(player.Center, projectile.Center) > num647)
			{
				if (projectile.type == mod.ProjectileType("WoodSpirit"))
				{
					projectile.ai[0] = 1f;
				}
				projectile.tileCollide = false;
				projectile.netUpdate = true;
			}
			if (projectile.type == mod.ProjectileType("WoodSpirit") && flag25 && projectile.ai[0] == 0f)
			{
				Vector2 vector47 = vector46 - projectile.Center;
				float num648 = vector47.Length();
				vector47.Normalize();
				if (num648 > 200f)
				{
					float scaleFactor2 = 6f;
					if (projectile.type == mod.ProjectileType("WoodSpirit"))
					{
						scaleFactor2 = 8f;
					}
					vector47 *= scaleFactor2;
					projectile.velocity = (projectile.velocity * 40f + vector47) / 41f;
				}
				else
				{
					float num649 = 4f;
					vector47 *= -num649;
					projectile.velocity = (projectile.velocity * 40f + vector47) / 41f;
				}
			}
			else
			{
				bool flag26 = false;
				if (!flag26)
				{
					flag26 = (projectile.ai[0] == 1f && (projectile.type == mod.ProjectileType("WoodSpirit")));
				}
				float num650 = 6f;
				if (flag26)
				{
					num650 = 15f;
				}
				Vector2 center2 = projectile.Center;
				Vector2 vector48 = player.Center - center2 + new Vector2(0f, -60f);
				float num651 = vector48.Length();
				if (num651 > 200f && num650 < 8f)
				{
					num650 = 8f;
				}
				if (num651 < num636 && flag26 && !Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
				{
					if (projectile.type == mod.ProjectileType("WoodSpirit"))
					{
						projectile.ai[0] = 0f;
					}
					projectile.netUpdate = true;
				}
				if (num651 > 2000f)
				{
					projectile.position.X = Main.player[projectile.owner].Center.X - (float)(projectile.width / 2);
					projectile.position.Y = Main.player[projectile.owner].Center.Y - (float)(projectile.height / 2);
					projectile.netUpdate = true;
				}
				if (num651 > 70f)
				{
					vector48.Normalize();
					vector48 *= num650;
					projectile.velocity = (projectile.velocity * 40f + vector48) / 41f;
				}
				else if (projectile.velocity.X == 0f && projectile.velocity.Y == 0f)
				{
					projectile.velocity.X = -0.15f;
					projectile.velocity.Y = -0.05f;
				}
			}
			if (projectile.ai[1] > 0f && (projectile.type == mod.ProjectileType("WoodSpirit")))
			{
				projectile.ai[1] += (float)Main.rand.Next(1, 4);
			}
			if (projectile.ai[1] > 40f && projectile.type == mod.ProjectileType("WoodSpirit"))
			{
				projectile.ai[1] = 0f;
				projectile.netUpdate = true;
			}
			if (projectile.ai[0] == 0f && (projectile.type == mod.ProjectileType("WoodSpirit")))
			{
				if (projectile.type == mod.ProjectileType("WoodSpirit") && projectile.ai[1] == 0f && flag25 && num633 < 500f)
				{
					projectile.ai[1] += 1f;
					if (Main.myPlayer == projectile.owner)
					{
						projectile.ai[0] = 2f;
						Vector2 value20 = vector46 - projectile.Center;
						value20.Normalize();
						projectile.velocity = value20 * 2f;
						projectile.netUpdate = true;
						return;
					}
				}
			}
        }
    }
}