using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Emperia.Projectiles
{
    public class EnchantedBall : ModProjectile
    {
        private Point tileCoordPos { get { return new Point((int)(projectile.position.X / 16), (int)(projectile.position.Y / 16)); } }
        public override void SetDefaults()
        {
            projectile.name = "Enchanted Ball";
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.penetrate = 2;
            projectile.timeLeft = 200;
            projectile.light = 0.75f;
            projectile.extraUpdates = 1;
            projectile.ignoreWater = true;

            projectile.hide = true;
        }

        public override bool Autoload(ref string name, ref string texture)
        {
            texture = "Terraria/MagicPixel";
            return true;
        }

        public override bool PreKill(int timeLeft)
        {
            for (int i = 0; i < Main.rand.Next(6, 12); i++)
            {
                float x = Main.rand.NextFloat() * projectile.width;
                float y = Main.rand.NextFloat() * projectile.height;

                Vector2 random = new Vector2(-5, 0).RotatedByRandom(MathHelper.ToRadians(360));
                Dust.NewDust(new Vector2(projectile.Hitbox.X + x, projectile.Hitbox.Y + y), Main.rand.Next(1, 7), Main.rand.Next(1, 7), 20, random.X, random.Y);
            }
            return true;
        }

        public override void AI()
        {
            for (int i = 0; i < Main.rand.Next(4); i++)
            {
                float x = Main.rand.NextFloat() * projectile.width;
                float y = Main.rand.NextFloat() * projectile.height;

                Vector2 vel = Vector2.Normalize(-projectile.velocity) * 2;

                Dust.NewDust(new Vector2(projectile.Hitbox.X + x, projectile.Hitbox.Y + y), Main.rand.Next(1, 7), Main.rand.Next(1, 7), 20, vel.X, vel.Y);
            }

            projectile.velocity.Y = 0;
            bool foundbelow = false;
            for (int i = 0; i < 16; i++)
            {
                Tile below = Framing.GetTileSafely(tileCoordPos.X, tileCoordPos.Y + i);

                if (below.active() && below.collisionType > 0)
                {
                    if (i == 0) //if it's inside the tile
                    {
                        bool foundabove = false;
                        for (int j = 1; j <= 3; j++)
                        {
                            Tile above = Framing.GetTileSafely(tileCoordPos.X, tileCoordPos.Y - j);

                            if (!above.active())
                            {
                                projectile.position.Y = (tileCoordPos.Y - j) * 16;
                                foundabove = true;
                                break;
                            }
                        }

                        if (!foundabove)
                            projectile.Kill();
                    }
                    else
                    {
                        projectile.position.Y = (tileCoordPos.Y + i - 1) * 16;
                        foundbelow = true;
                        break;
                    }
                }
            }
            if (!foundbelow)
                projectile.Kill();
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (target.life <= 0)
            {   //this might not work too well
                Main.player[projectile.owner].AddBuff(mod.BuffType<Buffs.Enchanted>(), Buffs.Enchanted.stackDuration);
            }
        }
    }
}
