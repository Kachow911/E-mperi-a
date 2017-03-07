using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Bosses.Mushor
{
    public class Mushor2 : ModNPC
    {
        private enum Move
        {
            Centering,
            Spores,
            Adds,
            Bombing
        }

        private int counter { get { return (int)npc.ai[0]; } set { npc.ai[0] = value; } }

        private Move move { get { return (Move)npc.ai[1]; } set { npc.ai[1] = (int)value; } }
        private Move prevMove;
        private Vector2 targetPosition;

        private int side { get { return (int)npc.ai[2]; } set { npc.ai[2] = value; } }

        public override void SetDefaults()
        {
            npc.name = "Mushor";
            npc.displayName = "Mushor v2";
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
            Player player = Main.player[npc.target];
            if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                player = Main.player[npc.target];
            }

            if (move == Move.Centering)
            {
                targetPosition = player.Center + new Vector2(0, -196);

                npc.velocity += Vector2.Normalize((targetPosition - npc.Center) * .2f);
                npc.velocity.X = MathHelper.Clamp(npc.velocity.X, -4, 4);
                npc.velocity.Y = MathHelper.Clamp(npc.velocity.Y, -4, 4);

                if (npc.Distance(targetPosition) < 16)
                {
                    if (prevMove == Move.Centering || prevMove == Move.Bombing)
                    {
                        SetMove(Move.Spores, 240);

                        //move = Move.Spores;
                        //counter = 240;    //4 sec
                    }
                    else if (prevMove == Move.Spores)
                    {
                        SetMove(Move.Adds, 600);
                        //move = Move.Adds;
                        //counter = 600;
                    }
                    else if (prevMove == Move.Adds)
                    {
                        SetMove(Move.Bombing, 600);
                        //move = Move.Bombing;
                        //counter = 600;
                        side = Main.rand.Next(2); 
                    }
                    //prevMove = Move.Centering;
                }
            }
            else if (move == Move.Spores)
            {
                counter--;
                npc.velocity *= .95f;   //velocity is 95% of what it was last frame

                Rectangle rect = new Rectangle((int)npc.Center.X - 80, (int)npc.position.Y + npc.height, 160, 512);

                if (rect.Contains(player.Center.ToPoint()))
                {
                    //player.Hurt(Terraria.DataStructures.PlayerDeathReason.ByNPC(npc.type), 1, 0); //todo spores debuff player.velocity.Y = Math.Abs(player.velocity.Y); and dot
                    player.AddBuff(mod.BuffType<Buffs.Spored>(), 1800); //30 sec
                }

                float x = Main.rand.NextFloat() * rect.Width;
                float y = Main.rand.NextFloat() * rect.Height;

                Tile atTile = Framing.GetTileSafely((int)((rect.X + x) / 16), (int)((rect.Y + y) / 16));

                if (!atTile.active())
                    Dust.NewDust(new Vector2(rect.X + x, rect.Y + y), Main.rand.Next(1, 7), Main.rand.Next(1, 7), 20);

                if (counter <= 0)
                {
                    SetMove(Move.Centering, 0);

                    //move = Move.Centering;
                    //prevMove = Move.Spores;
                }
            }
            else if (move == Move.Adds)
            {
                counter--;

                targetPosition = player.Center + new Vector2(0, 0);

                npc.velocity += Vector2.Normalize((targetPosition - npc.Center) * .1f);
                npc.velocity.X = MathHelper.Clamp(npc.velocity.X, -1.5f, 1.5f);
                npc.velocity.Y = MathHelper.Clamp(npc.velocity.Y, -1.5f, 1.5f);

                if (counter % 30 == 0)
                {   //every 16 ticks
                    if (Main.netMode != 1)
                    {
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, Main.rand.Next(4) == 0 ?
                            mod.NPCType<MushorMinionExplode>() : mod.NPCType<MushMinionShootNoExplosionTest1>());
                    }
                }

                if (counter <= 0)
                {
                    SetMove(Move.Centering, 0);

                    //move = Move.Centering;
                    //prevMove = Move.Adds;
                }
            }
            else if (move == Move.Bombing)
            {
                counter--;

                targetPosition = player.Center + new Vector2(side == 0 ? -256 : 256, -196);

                npc.velocity += Vector2.Normalize((targetPosition - npc.Center) * .2f);
                npc.velocity.X = MathHelper.Clamp(npc.velocity.X, -4, 4);
                npc.velocity.Y = MathHelper.Clamp(npc.velocity.Y, -4, 4);

                if (counter % 30 == 0)
                {
                    if (Main.netMode != 1)
                    {
                        float x = 0;
                        x = (Main.rand.NextFloat() * 4 - 6) + 4;    //between 4 and 6
                        x *= Main.rand.Next(2) == 0 ? -1 : 1;
                        Projectile.NewProjectile(npc.Center, new Vector2(x, -8), mod.ProjectileType<Projectiles.ExplodeMushroom>(), 20, 0);
                    }
                }

                if (counter <= 0)
                {
                    SetMove(Move.Centering, 0);
                    //move = Move.Centering;
                    //prevMove = Move.Bombing;
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
