using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Desiccation.ModProjectiles.JellyFish
{
	public class LightningProjectile : ModProjectile
	{

		public override void SetStaticDefaults()
        {
			Main.projFrames[projectile.type] = 4;
		}



		public override void SetDefaults()
		{
			projectile.width = 22;
			projectile.height = 22;
			projectile.friendly = true;
			projectile.maxPenetrate = -1;
			projectile.melee = true;
			projectile.aiStyle = 1;
		}

		public override void AI()
		{
			projectile.velocity *= 0.98f;
			// Loop through the 4 animation frames, spending 5 ticks on each.
			if (++projectile.frameCounter >= 5)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 4)
				{
					projectile.frame = 0;
				}
			}
		}
	}
}