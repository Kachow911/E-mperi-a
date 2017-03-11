using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

using Emperia.Weapons.Enchanted;

namespace Emperia.Projectiles
{
    public class EnchantedArrow : ModProjectile
    {
        private const float explodeRadius = 64;
        private NPC target { get { return Main.npc[(int)projectile.ai[0]]; } set { projectile.ai[0] = value.whoAmI; } }

        private Vector2 collidePos;
        public override void SetDefaults()
        {
            projectile.name = "Enchanted Bullet";
            projectile.width = 18;
            projectile.height = 38;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 5;
            projectile.timeLeft = 600;
            projectile.alpha = 255;
            projectile.light = 0.5f;
            projectile.extraUpdates = 1;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            aiType = ProjectileID.Bullet;

            projectile.GetModInfo<EnchantedInfo>(mod).givesMinorEnchanted = true;
        }

        public override void AI()
        {
            if (aiType == -1)
            {
                projectile.velocity.Y += .25f;

                Dust.NewDust(projectile.Center, Main.rand.Next(1, 7), Main.rand.Next(1, 7), 20);
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            //if (aiType == -1)
                //return false;
            return true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (aiType != -1)
            {
                aiType = -1;
                this.target = target;
            }
            else
            {
                Explode();
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (aiType == -1)
                Explode();
            return true;
        }

        private void Explode()
        {
            for (int i = 0; i < Main.npc.Length; i++)
            {
                if (projectile.Distance(Main.npc[i].Center) < explodeRadius)
                    Main.npc[i].StrikeNPC(projectile.damage, 0, 0);
            }

            for (int i = 0; i < 360; i++)
            {
                Vector2 vec = Vector2.Transform(new Vector2(-explodeRadius, 0), Matrix.CreateRotationZ(MathHelper.ToRadians(i)));

                Dust.NewDust(projectile.Center + vec, Main.rand.Next(1, 7), Main.rand.Next(1, 7), 20);

                if (i % 2 == 0)
                {
                    vec.Normalize();
                    Dust.NewDust(projectile.Center, Main.rand.Next(1, 7), Main.rand.Next(1, 7), 20, vec.X * 2, vec.Y * 2);
                }
            }

            Main.PlaySound(SoundID.Item, projectile.Center, 14);    //bomb explosion sound
            Main.PlaySound(SoundID.Item, projectile.Center, 21);    //swishy sound
        }
    }
}
