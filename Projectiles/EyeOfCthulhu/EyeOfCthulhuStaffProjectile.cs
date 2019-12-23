using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

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
			aiType = (388);
        }
			public override bool? CanCutTiles()
			{
			return true;
			
			}

		public override bool MinionContactDamage()
	    {
			return true;       
        }
	}
}