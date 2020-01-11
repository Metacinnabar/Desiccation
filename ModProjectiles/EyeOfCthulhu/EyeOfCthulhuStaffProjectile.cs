using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.ModProjectiles.EyeOfCthulhu
{
	public class EyeOfCthulhuStaffProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			Main.projFrames[projectile.type] = 2;
			projectile.minionSlots = 2f;
			projectile.tileCollide = false;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			Main.projPet[projectile.type] = true;
			projectile.CloneDefaults(388);
			aiType = 388;
		}

		public override bool? CanCutTiles()
		{
			return true;
		}

		public override bool MinionContactDamage()
		{
			return true;
		}

		public override void AI()
		{
			projectile.velocity *= 0.98f;
			// Fix later.
			if (++projectile.frameCounter >= 8)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 2)
				{
					projectile.frame = 0;
				}
			}
		}
	}
}