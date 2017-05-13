using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.NPCs
{
    public class TreeMan : ModNPC
    {
		public int phase = 1;
		public int counter = 120;
        public override void SetDefaults()
        {
            npc.name = "Ebonfire Eruptor";
            npc.displayName = "Ebonfire Eruptor";
            npc.aiStyle = -1;
            npc.lifeMax = 6500;
            npc.damage = 32;
            npc.defense = 7;
            npc.knockBackResist = 0f;
            npc.width = 60;
            npc.height = 66;
            npc.value = Item.buyPrice(0, 15, 0, 0);
            npc.npcSlots = 0f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1; //57 //20
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[24] = true;
			Main.npcFrameCount[npc.type] = 4;
            npc.netAlways = true;
        }
		 public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;
        }
		 public override void AI()
        {
			npc.rotation = npc.velocity.X * 0.025f;
						npc.TargetClosest(true);
						Player player = Main.player[npc.target];
			if (phase == 1)
			{
			counter--;
			Vector2 move = Main.player[npc.target].Center - npc.Center;
			npc.velocity = move * .04f;
				if (counter <= 0)
				{
					if (Main.rand.Next(2) == 0)
					{	
						phase = 2;
					}
					else
					{
						phase = 3;
					}
					counter = 20;
				}
			}
			else if (phase == 2)
			{
				counter--;
              float num2 = 10f;
              Vector2 vector2 = new Vector2(npc.position.X + (float) npc.width * 0.5f, (float) ((double) npc.position.Y + (double) npc.height));
              float num3 = Main.player[npc.target].position.X + (float) Main.player[npc.target].width * 0.5f - vector2.X;
              float num4 = Main.player[npc.target].position.Y - vector2.Y - Math.Abs(num3) * 0.3f;
              float num5 = num2 + Math.Abs(num3) * 0.004f;
              if ((double) num5 > 14.0)
                num5 = 14f;
              float num6 = num3 + (float) Main.rand.Next(-50, 51);
              float num7 = num4 - (float) Main.rand.Next(50, 201);
              float num8 = (float) Math.Sqrt((double) num6 * (double) num6 + (double) num7 * (double) num7);
              float num9 = num5 / num8;
              float num10 = num6 * num9;
              float num11 = num7 * num9;
              float SpeedX = num10 * (float) (1.0 + (double) Main.rand.Next(-30, 31) * 0.00999999977648258);
              float SpeedY = num11 * (float) (1.0 + (double) Main.rand.Next(-30, 31) * 0.00999999977648258);
              Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, mod.ProjectileType("EbonFire"), 40, 0.0f, Main.myPlayer, 0.0f, 0.0f);
			  if (counter <= 0)
				{
					phase = 1;
					counter = 120;
				}
			}
			else if (phase == 3)
			{
	
                        
			}
		}
    }
    
}
