using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation
{
	public class DesiccationGlobalProjectile : GlobalProjectile
	{
		public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
		{
			if (projectile.type == ProjectileID.EbonsandBallGun || projectile.type == ProjectileID.CrimsandBallGun)
			{
				target.AddBuff(BuffID.Weak, 420);
			}
			if (projectile.type == ProjectileID.PearlSandBallGun)
			{
				target.AddBuff(BuffID.Slow, 420);
			}
		}
	}
}