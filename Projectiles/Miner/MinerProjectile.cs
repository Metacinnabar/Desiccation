using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Desiccation.Projectiles.Miner
{
	public class MinerProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 22;
			projectile.height = 22;
			projectile.friendly = true;
			projectile.maxPenetrate = -1;
			projectile.melee = true;
		}

		public override void AI()
		{
			float rotationsPerSecond = 3f;
			projectile.rotation += MathHelper.ToRadians(rotationsPerSecond * 360f / 60f);
		}
	}
}