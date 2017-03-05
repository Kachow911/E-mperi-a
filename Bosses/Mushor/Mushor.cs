using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Bosses.Mushor
{
    public class Mushor : ModNPC
    {
        public bool hasSpawned = false;
		public int timerP2 = 0;
		public int timerP3 = 0;
		public float rot = 0f;
		private const int minion1CountLeft = 1;
		private const int minion2CountLeft = 2;
		public bool didADo = false;
		public bool didADoRot = false;

        public override void SetDefaults()
        {
            npc.name = "Mushor";
            npc.displayName = "Mushor";
            npc.aiStyle = -1;
            npc.lifeMax = 6500;
            npc.damage = 50;
            npc.defense = 13;
            npc.knockBackResist = 0f;
            npc.width = 102;
            npc.height = 66;
            Main.npcFrameCount[npc.type] = 1;
            npc.value = Item.buyPrice(1, 50, 0, 0);
            npc.npcSlots = 1f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1; //57 //20
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[24] = true;

            npc.netAlways = true;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 9000;
            npc.damage = 60;
        }

        public override void AI()
        {
			/*
			 About the ai for people editing it	
			 the move patterns are stored in npc.ai[2]
			add other stuff later
			*/
            if (!hasSpawned)
            {
                npc.ai[0] = 0;
                hasSpawned = true;
            }
            //These are not 100% set yet, im defining variables.
            bool speedBoost1 = (double)npc.life <= (double)npc.lifeMax * 0.8; // this'll be a minor speed increase
            bool speedBoost2 = (double)npc.life <= (double)npc.lifeMax * 0.5; //this is a medium increase
            bool phaseCheck2 = (double)npc.life <= (double)npc.lifeMax * 0.4; //check for phase 2.
            float speed = 5f;

            Player player = Main.player[npc.target];
            if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                player = Main.player[npc.target];
            }
            // sets targeting
			
			if (npc.ai[2] == 2) {
				timerP2++;
			}
            if (npc.ai[2] == 3) {
				timerP3++;
			}
            int playerLife = player.statLifeMax2;
            //actual speed increase here
            if (playerLife > 400)
            {
                speed += 1f;
            }
            if (speedBoost1)
            {
                speed += 1f;
            }
            if (speedBoost2)
            {
                speed += 1f;
            }
			if (npc.ai[2] == 2) 
			{
			    speed += 2f;	
			}
            
            if (npc.ai[0] == 0)
            {
                //reserved
                npc.ai[0] = 1;
                npc.ai[2] = 1; //attack pattern stuff
            }
            npc.velocity.X = 0f;
            npc.velocity.Y = 0f;
			// tests if its flown to the correct place
            if ((double)npc.Center.X > (double)player.Center.X - 100)
			{
				if ((double)npc.Center.X < (double)player.Center.X + 100)
			    {
				    if ((double)npc.Center.Y < (double)player.Center.Y + 100)
			        {
				        if ((double)npc.Center.Y > (double)player.Center.Y - 100)
			            {
							
							if (npc.ai[2] == 1)
							{
					            npc.ai[2] = 2;
							}
							
							
						}
			        }	
			    }	
			}
			 if ((double)npc.Center.X > (double)player.Center.X - 20)
			{
				if ((double)npc.Center.X < (double)player.Center.X + 20)
			    {
				    if ((double)npc.Center.Y < (double)player.Center.Y + 20)
			        {
				        if ((double)npc.Center.Y > (double)player.Center.Y - 20)
			            {
							
							if (npc.ai[2] == 1)
							{
					            npc.ai[2] = 2;
							}
							if (npc.ai[2] == 4)
							{
					            npc.ai[2] = 5;
							}
							
						}
			        }	
			    }	
			}
				
            if (npc.ai[2] == 1) //normal movement pattern
            {
                Vector2 direction = Main.player[npc.target].Center - npc.Center;
			    direction.Normalize();
			    npc.velocity.Y = direction.Y * speed;
			    npc.velocity.X = direction.X * speed;
            }
			if (npc.ai[2] == 2) //spawns minions
		    {
				if(!didADo) {
                NPC.NewNPC((int)npc.position.X + Main.rand.Next(-200, 200), (int)npc.position.Y, mod.NPCType("MushMinionShootNoExplosionTest1"));
                for (int i = 0; i < minion2CountLeft; i++)
                {
                    NPC.NewNPC((int)npc.position.X + Main.rand.Next(-200, 200), (int)npc.position.Y, mod.NPCType("MushorMinionExplode"));   //if you want this to spawn a different amount put in another for loop
                }
				didADo = true;
                }
                npc.ai[2] = 3;
				timerP3 = 0;
			}
			if (npc.ai[2] == 3) {
				npc.alpha+=2;
				if (npc.alpha == 180) 
				{
					npc.alpha = 0;
					npc.position.Y -= 200;
					npc.ai[2] = 4;
				}
			}
			if (npc.ai[2] == 4) {
				if(!didADoRot) 
				{
				rot = npc.rotation;
				didADoRot = true;
                }
				 Vector2 direction = Main.player[npc.target].Center - npc.Center;
			    direction.Normalize();
			    npc.velocity.Y = direction.Y * speed * 2.5f;
			    npc.velocity.X = direction.X * speed * 2.5f;
				npc.rotation++;
			}
			if (npc.ai[2] == 5) {
				 Vector2 direction = Main.player[npc.target].Center - npc.Center;
			    direction.Normalize();
				npc.rotation = rot;
			}
        }
    }
}

