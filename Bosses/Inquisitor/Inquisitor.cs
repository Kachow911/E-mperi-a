using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Bosses.Inquisitor
{
    public class Inquisitor : ModNPC
    {
        private enum Move
        {
            Alpha,
            Teleport,
            Shoot,
            Chase
        }

        private int counter { get { return (int)npc.ai[0]; } set { npc.ai[0] = value; } }
        private float rotate { get { return npc.ai[3]; } set { npc.ai[3] = value; } }
        private Move move { get { return (Move)npc.ai[1]; } set { npc.ai[1] = (int)value; } }
        private Move prevMove;
        private Vector2 targetPosition;
		private Vector2 rotatePosition;
        private bool initialize = false;
        private int side { get { return (int)npc.ai[2]; } set { npc.ai[2] = value; } }

        public override void SetDefaults()
        {
            npc.name = "The Inquisitor";
            npc.displayName = "The Inquisitor";
            npc.aiStyle = -1;
            npc.lifeMax = 14500;
            npc.damage = 150;
            npc.defense = 40;
            npc.knockBackResist = 0f;
            npc.width = 102;
            npc.height = 66;
			npc.alpha = 0;
            Main.npcFrameCount[npc.type] = 1;
            npc.value = Item.buyPrice(0, 20, 0, 0);
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
            npc.lifeMax = 16000;
            npc.damage = 175;
        }

        public override void AI()
        {
			if (!initialize) {
				counter = 51;
				initialize = true;
			}
            Player player = Main.player[npc.target];
            if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                player = Main.player[npc.target];
            }

            if (move == Move.Alpha)
            {
			counter--;
               npc.alpha+=5;
			   if (counter <= 0) 
			   {
			        npc.alpha = 0;
                    SetMove(Move.Alpha, 45);
					Vector2 rotatePosition = Vector2.Transform(new Vector2(-1 * 200, 0), Matrix.CreateRotationZ(MathHelper.ToRadians(rotate))) + player.Center;
					rotate += 45f;
					npc.Center = rotatePosition;
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
