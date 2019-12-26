using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.Projectiles.KingBlizzard
{
	public class HailstormDaggerProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 30;
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.penetrate = 3;
			projectile.coldDamage = true;
			projectile.alpha = 0;
		}

		private bool rotChanged = false;

		public override void AI()
		{
			if (!rotChanged)
			{
				projectile.rotation = projectile.DirectionTo(Main.MouseWorld).ToRotation() - MathHelper.PiOver2;
				rotChanged = true;
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Main.PlaySound(SoundID.Item27, projectile.position);
			return true;
		}
	}
}