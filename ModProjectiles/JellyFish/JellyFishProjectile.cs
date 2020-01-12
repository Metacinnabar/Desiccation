using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Desiccation.ModProjectiles.JellyFish
{
	public class JellyFishProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 100;
			projectile.height = 40;
			projectile.friendly = true;
			projectile.maxPenetrate = -1;
			projectile.melee = true;
			projectile.aiStyle = 40;
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

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			{

				float projectilespeedX = 0f;
				float projectilespeedY = 0f;
				float projectileknockBack = 4f;
				int projectiledamage = 20;
				{
					Projectile.NewProjectile(projectile.position.X, projectile.position.Y, projectilespeedX, projectilespeedY, mod.ProjectileType("LightningProjectile"), projectiledamage, projectileknockBack, projectile.owner, 0f, 0f);
				}
			}

		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Main.PlaySound(SoundID.Item27, projectile.position);
			return true;
		}
	}
}