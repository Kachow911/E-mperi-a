﻿using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Bosses.Mushor
{
    public class MushMinionShootNoExplosion : ModNPC
    {
        public bool hasSpawned = false;
		public int timerP2 = 0;
		public bool shotYet = false;

        public override void SetDefaults()
        {
            npc.name = "Angry Mushroom";
            npc.displayName = "Angry Mushroom";
            npc.aiStyle = -1;
            npc.lifeMax = 150;
            npc.damage = 23;
            npc.defense = 7;
            npc.knockBackResist = 0f;
            npc.width = 102;
            npc.height = 66;
            Main.npcFrameCount[npc.type] = 15;
            npc.value = Item.buyPrice(0, 0, 0, 0);
            npc.npcSlots = 0f;
            npc.boss = false;
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

        public override void AI()
        {
			npc.TargetClosest(true);
			/*
			 About the ai for people editing it	
			 the move patterns are stored in npc.ai[2]
			add other stuff later
			*/
		     Player player = Main.player[npc.target];
            if (!hasSpawned)
            {
                npc.ai[0] = 0;
                hasSpawned = true;
            }
            //These are not 100% set yet, im defining variables.
            float speed = 4f;

            // sets targeting
			double npcFlyToY = player.Center.Y - 150;
            double npcFlyToX = player.Center.X;
	        if (!player.active || player.dead)
            {
               npc.TargetClosest(false);
               player = Main.player[npc.target];
            }
         
            
            if (npc.ai[0] == 0)
            {
                //reserved
                npc.ai[0] = 1;
                npc.ai[2] = 1; //attack pattern stuff
            }
			 if (npc.ai[2] == 2)
            {
                timerP2++;
            }
            npc.velocity.X = 0f;
            npc.velocity.Y = 0f;
			// tests if its flown to the correct place
            if ((double)npc.Center.X > (double)player.Center.X - 50)
			{
				if ((double)npc.Center.X < (double)player.Center.X + 50)
			    {
				    if ((double)npc.Center.Y < (double)player.Center.Y + 50)
			        {
				        if ((double)npc.Center.Y > (double)player.Center.Y - 200)
			            {
							if (npc.ai[2] == 1)
							{
					            npc.ai[2] = 2;
								timerP2 = 0;
							}
							
						}
						if ((double)npc.Center.Y > (double)player.Center.Y - 50)
			            {
							if (npc.ai[2] == 1)
							{
					            npc.ai[2] = 2;
							}
							else if (npc.ai[2] == 4)
							{
							    npc.ai[2] = 5;
							}
			            }		
			        }	
			    }	
			}
				
            if (npc.ai[2] == 1) //normal movement pattern
            {
                if ((double)npc.Center.Y < npcFlyToY)
                {
                    npc.velocity.Y = speed;
                }
                if ((double)npc.Center.Y > npcFlyToY)
                {
                    npc.velocity.Y = -speed;
                }
                if ((double)npc.Center.X < npcFlyToX)
                {
                    npc.velocity.X = speed;
                }
                if ((double)npc.Center.X > npcFlyToX)
                {
                    npc.velocity.X = -speed;
                }
            }
			if (npc.ai[2] == 2) // speeds up and heads up actually and does a move
			{
				if (!shotYet)
				{
					Vector2 direction = Main.player[npc.target].Center - npc.Center;
					direction.Normalize();
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X * 10f, direction.Y * 10f, 329, 15, 1, Main.myPlayer, 0, 0);
				}
				if (timerP2 > 120)
				{
					npc.ai[2] = 1;
					timerP2 = 0;
				}
				
				
			}
			if (npc.ai[2] == 3) //a move
		    {
				
			}
        }
    }
}

