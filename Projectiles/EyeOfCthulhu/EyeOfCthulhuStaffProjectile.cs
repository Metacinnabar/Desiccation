using Terraria.ModLoader;

namespace Desiccation.Projectiles.EyeOfCthulhu
{
	public class EyeOfCthulhuStaffProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.minionSlots = 2f;
			projectile.CloneDefaults(388);
		}
	}
}