﻿using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Bosses.Mushor
{
    public class MushorMinionExplodeDummy : ModNPC
    {
        private const float frameTimer = 2.375f;

        private const float damageDistance = 64;

        public override void SetDefaults()
        {
            npc.name = "Angery Mushroom";
            npc.displayName = "Angery Mushroom";
            npc.aiStyle = -1;
            npc.lifeMax = 1;
            npc.damage = 23;
            npc.defense = 7;
            npc.knockBackResist = 0f;
            npc.width = 80;
            npc.height = 80;
            Main.npcFrameCount[npc.type] = 7;
            npc.value = Item.buyPrice(0, 0, 0, 0);
            npc.npcSlots = 0f;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1; //57 //20
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[24] = true;

            npc.netAlways = true;
        }

        public override void AI()
        {
            npc.velocity = new Vector2(npc.ai[1], npc.ai[2]);

            npc.ai[0]--;
            for (int i = 0; i < Main.player.Length; i++)
            {
                Player player = Main.player[i];
                if (npc.Distance(player.Center) < damageDistance)
                {
                    player.Hurt(Terraria.DataStructures.PlayerDeathReason.ByNPC(npc.whoAmI), npc.damage, 0);
                }
            }

            float x = Main.rand.NextFloat() * npc.width;
            float y = Main.rand.NextFloat() * npc.height;

            Vector2 random = new Vector2(-5, 0).RotatedByRandom(MathHelper.ToRadians(360));
            Dust.NewDust(new Vector2(npc.Hitbox.X + x, npc.Hitbox.Y + y), Main.rand.Next(1, 7), Main.rand.Next(1, 7), 20, random.X, random.Y);

            if (npc.ai[0] <= 0)
            {
                npc.life = 0;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;
            npc.frame.Y = frameHeight * (int)(npc.frameCounter / frameTimer);

            if (npc.frameCounter >= 6 * frameTimer)
                npc.frameCounter = 0;
        }
    }
}
