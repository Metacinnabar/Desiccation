using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Desiccation.Projectiles.EyeProjectile
{
	public class EyeProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{

		}
		public override void SetDefaults()
		{
			projectile.CloneDefaults(388);
		}

	}

}