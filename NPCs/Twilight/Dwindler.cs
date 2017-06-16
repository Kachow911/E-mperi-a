using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.NPCs.Twilight
{
    public class Dwindler : ModNPC
    {
		public int StealthTimer = 120;
		public bool Jump = false;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dwindler");
			Main.npcFrameCount[npc.type] = 1;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = 3;
            npc.lifeMax = 432;
            npc.damage = 15;
            npc.defense = 7;
            npc.knockBackResist = 0f;
            npc.width = 60;
            npc.height = 66;
            npc.value = Item.buyPrice(0, 0, 15, 0);
            npc.npcSlots = 0f;
            npc.lavaImmune = true;
            npc.noTileCollide = false;
            npc.HitSound = SoundID.NPCHit1; //57 //20
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[24] = true;
            npc.netAlways = true;
        }
		
		 public override void AI()
        {
			//Stealth Effects
			StealthTimer--;
			if (StealthTimer <= 0)
			{
				if (npc.alpha < 200)
					npc.alpha++;
			}
			//Done
			
			//Teleport
			if (npc.alpha == 200 && Main.rand.Next(10) == 0)
			{
				npc.alpha = 0;
				if (Main.rand.Next(2) == 0)
					npc.position.Y -= Main.rand.Next(50, 250);

			}
			// Done
			if (npc.velocity.Y < 0 && Jump)
			{
				npc.velocity.Y *= 2;
				Jump = false;
			}
			if (npc.velocity.Y >= 0)
			{
				Jump = true;
			}
		}
    }
    
}
