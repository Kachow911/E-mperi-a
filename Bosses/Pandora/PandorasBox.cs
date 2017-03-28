using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Bosses.Pandora
{
    public class PandorasBox : ModNPC
    {
        private const int frameTimer = 5;

        public override void SetDefaults()
        {
            npc.name = "Pandoras Box";
            npc.displayName = "Pandora's Box";
            npc.aiStyle = -1;
            npc.lifeMax = 250;
            npc.damage = 0;
            npc.defense = 7;
            npc.knockBackResist = 0f;
            npc.width = 40;
            npc.height = 40;
            Main.npcFrameCount[npc.type] = 13;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;

            npc.dontTakeDamage = true;

            npc.netAlways = true;
        }

        public override void AI()
        {
            Lighting.AddLight(npc.Center + new Vector2(-64, 0), 0.392f, 0.675f, 0.0784f);
            Lighting.AddLight(npc.Center + new Vector2(0, -64), 0.094f, 0.816f, 0.863f);
            Lighting.AddLight(npc.Center + new Vector2(64, 0), 0.682f, 0.157f, 0.071f);
            Lighting.AddLight(npc.Center + new Vector2(0, 64), 0.604f, 0, 0.604f);
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;
            npc.frame.Y = frameHeight * (int)(npc.frameCounter / frameTimer);

            if (npc.frameCounter >= 12 * frameTimer)
                npc.frameCounter = 0;
        }

        public override bool CheckActive()
        {
            return false;   //ALWAYS active.
        }
    }
}
