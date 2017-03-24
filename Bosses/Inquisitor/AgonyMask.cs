using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Bosses.Inquisitor
{
    public class AgonyMask : ModNPC
    {
		private enum Move
        {
            Chase,
            Tired,
        }
		  private int counter { get { return (int)npc.ai[0]; } set { npc.ai[0] = value; } }

        private Move move { get { return (Move)npc.ai[1]; } set { npc.ai[1] = (int)value; } }
        private Move prevMove;
        private Vector2 targetPosition;

        public override void SetDefaults()
        {
            npc.name = "Agony";
            npc.displayName = "Agony";
            npc.aiStyle = -1;
            npc.lifeMax = 3500;
            npc.damage = 23;
            npc.defense = 7;
            npc.knockBackResist = 0f;
            npc.width = 102;
            npc.height = 66;
            Main.npcFrameCount[npc.type] = 1;
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
			
            if (move == Move.Chase)
            {
				counter--;
			Player player = Main.player[npc.target];
				targetPosition = player.Center;
			   npc.velocity += Vector2.Normalize((targetPosition - npc.Center) * .3f);
			   npc.velocity *= 1.5f;
               npc.velocity.X = MathHelper.Clamp(npc.velocity.X, -2, 2);
               npc.velocity.Y = MathHelper.Clamp(npc.velocity.Y, -2, 2);
			   if (counter <= 0)
			   {
				   SetMove(Move.Tired, 30);
			   }
			}
			if (move == Move.Tired)
            {
			counter--;
			npc.velocity *= .5f;
			   if (counter <= 0)
			   {
				   SetMove(Move.Chase, 180);
			   }
			}
        }
		
        private void SetMove(Move toMove, int counter)
        {
            prevMove = move;
            move = toMove;
            this.counter = counter;
        }
    }
}

