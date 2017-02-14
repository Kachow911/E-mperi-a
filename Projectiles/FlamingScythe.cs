using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Projectiles
{
	public class FlamingScythe : ModProjectile
	{
		

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.FlamingScythe);
			projectile.name = "Flaming Scythe";
			projectile.penetrate = 3;
			projectile.friendly = true;
			projectile.hostile = false;
		}

	}
}