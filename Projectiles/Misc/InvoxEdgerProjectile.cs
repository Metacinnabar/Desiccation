using Terraria.ModLoader;

namespace Desiccation.Projectiles.Misc
{
	public class InvoxEdgerProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("InvoxEdgerProjectile");
		}
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 54;
			projectile.aiStyle = 20;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.tileCollide = false;
			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
		}
	}
}
