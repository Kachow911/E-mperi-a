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
    public class EnchantedBullet : ModProjectile
    {
        NPC bounceTarget { get { return Main.npc[(int)projectile.ai[0]]; } set { projectile.ai[0] = value.whoAmI; } }
        int bounces { get { return (int)projectile.ai[1]; } set { projectile.ai[1] = value; } }

        bool hitanything;
        public override void SetDefaults()
        {
            projectile.name = "Enchanted Bullet";
            projectile.width = 12;
            projectile.height = 8;
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

            projectile.GetModInfo<EnchantedInfo>(mod).enchantedSpawned = true;

            bounces = 3;
        }

        public override void PostAI()
        {
            Vector2 vel = Vector2.Normalize(-projectile.velocity) * 2;
            Dust.NewDust(projectile.Center, Main.rand.Next(1, 7), Main.rand.Next(1, 7), 20, vel.X, vel.Y);

            if (projectile.timeLeft <= 1)
            {
                Bounce(projectile.velocity);
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            hitanything = true;
            bounceTarget = target;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Bounce(oldVelocity);
            return false;
        }

        private void Bounce(Vector2 oldVelocity)
        {
            bounces--;

            if (bounces <= 0 || bounceTarget == null || hitanything == false)
            {
                projectile.Kill();
                //return false;
            }

            float len = oldVelocity.Length();
            //Vector2 direction = Vector2.Normalize(Main.player[projectile.owner].Center - projectile.Center);
            Vector2 direction = Vector2.Normalize(bounceTarget.Center - projectile.Center);

            projectile.velocity = direction * len;

            projectile.timeLeft = 600;
        }
    }
}
