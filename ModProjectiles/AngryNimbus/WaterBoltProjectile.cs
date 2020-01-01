using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Desiccation.ModProjectiles.AngryNimbus
{
	public class WaterBoltProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Water Bolt Porjectile");
		}

		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.alpha = 255;
			projectile.timeLeft = 180;
			projectile.penetrate = -1;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.aiStyle = 14;
		}

		public override void AI()
		{
			Dust.NewDust(projectile.Center - new Vector2(2, 2), 0, 0, 68, 0, 0, 100, Color.Blue);
		}
	}
}