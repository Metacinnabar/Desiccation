using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.Projectiles.EyeOfCthulhu
{
	public class EyeOfCthulhuStaffProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
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
			projectile.frameCounter++;
			if (projectile.frameCounter >= 65)
			{
				projectile.frameCounter = 0;
				projectile.frame++;
				if (projectile.frame >= Main.projFrames[projectile.type])
				{
					projectile.frame = 2;
				}
			}
		}
	}
}