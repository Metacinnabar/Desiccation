using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.Global
{
	public class DesiccationGlobalProjectile : GlobalProjectile
	{
		public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
		{
			if (ModContent.GetInstance<DesiccationGlobalConfig>().SandgunProjectileChanges)
			{
				switch (projectile.type)
				{
					case ProjectileID.EbonsandBallGun:
						target.AddBuff(BuffID.Weak, 420);
						break;

					case ProjectileID.CrimsandBallGun:
						target.AddBuff(BuffID.Bleeding, 420);
						break;

					case ProjectileID.PearlSandBallGun:
						target.AddBuff(BuffID.Slow, 420);
						break;
				}
			}
		}
	}
}