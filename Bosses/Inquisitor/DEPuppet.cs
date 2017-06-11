using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Bosses.Inquisitor
{
    public class DEPuppet : ModNPC
    {
		public bool hasSpawned = false;
		private Vector2 travelToPosition;
		private int counter = 120;
		private Vector2 shootToPosition;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Demolitions Expert Puppet");
			Main.npcFrameCount[npc.type] = 1;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 5000;
            npc.damage = 20;
            npc.defense = 40;
            npc.knockBackResist = 0f;
            npc.width = 24;
            npc.height = 38;
            npc.alpha = 0;
            npc.value = Item.buyPrice(0, 20, 0, 0);
            npc.lavaImmune = true;
            npc.noGravity = false;
            npc.noTileCollide = false;
            npc.HitSound = SoundID.NPCHit1; //57 //20
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[24] = true;

            npc.netAlways = true;
        }
		public override void AI()
        {
			Player player = Main.player[npc.target];
			npc.TargetClosest(true);
			if (!hasSpawned)
            {
                npc.ai[2] = 1;
                hasSpawned = true;
            }
			if (npc.ai[2] == 1)
			{
				npc.noTileCollide = true;
				SmoothMoveToPosition(player.Center + new Vector2(Main.rand.Next(-100, 100), 0), .3f, 4);

				counter--;
				if (counter <= 0)
				{
					npc.ai[2] = 2;
					counter = 30;
					Vector2 position = Main.player[npc.target].Center - npc.Center;
					position.Normalize();
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, position.X * 10f, position.Y * 10f, 102, 20, 1, Main.myPlayer, 0, 0);
				}
			}
			else if (npc.ai[2] == 2)
			{
				counter--;
				if (counter <= 0)
				{
					npc.ai[2] = 1;
					counter = 120;
				}
			}
		}
		private void SmoothMoveToPosition(Vector2 toPosition, float addSpeed, float maxSpeed, float slowRange = 64, float slowBy = .95f)
        {
            if (Math.Abs((toPosition - npc.Center).Length()) >= slowRange)
            {
                npc.velocity += Vector2.Normalize((toPosition - npc.Center) * addSpeed);
                npc.velocity.X = MathHelper.Clamp(npc.velocity.X, -maxSpeed, maxSpeed);
                npc.velocity.Y = MathHelper.Clamp(npc.velocity.Y, -maxSpeed, maxSpeed);
            }
            else
            {
                npc.velocity *= slowBy;
            }
        }
		private void ShootAtPosition(Vector2 position, float speed, int type, int damage)
		{
			Projectile.NewProjectile(npc.Center.X, npc.Center.Y, position.X * speed, position.Y * speed, type, damage, 1, Main.myPlayer, 0, 0);
		}
    }
}
