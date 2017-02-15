using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace Emperia.Bosses
{
	public class AntBoss : ModNPC
	{
        int phase = 1;
		int timerBurrow = 0;
		int timer = 0;
		public override void SetDefaults()
		{
			npc.name = "W-I-P";
			npc.displayName = "Antlion Boss";
			npc.width = 30;
			npc.height = 50;
			npc.damage = 30;
			npc.defense = 3;
			npc.lifeMax = 1500;
			npc.boss = true;
            npc.value = 200f;
			npc.knockBackResist = 0;
			npc.aiStyle = 3;
			Main.npcFrameCount[npc.type] = 6;
			aiType = 3;
			animationType = NPCID.WalkingAntlion;
		}
        public override void AI()
        {
			npc.TargetClosest(true);
			Player player = Main.LocalPlayer;
			if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                npc.velocity.Y = -50;
				timerBurrow = 0;
				timer = 0;
            }
			timerBurrow ++;
			timer++;
			
			if (player.position.X - 200 > npc.Center.X ) {
				npc.noTileCollide = true;
			}
			if (player.position.X + 200 < npc.Center.X) {
				npc.noTileCollide = true;	
			}
		
					if (npc.position.Y - 200 > player.position.Y) {
					 
					  npc.position.X = player.position.X;
					  npc.position.Y = player.position.Y + 100;
				      npc.velocity.Y -= 15;
		              
					}
					if (npc.position.Y <= player.position.Y) {
						
						npc.noTileCollide=false;
						
					}
			
			
		}

	}
}
