using Terraria.ModLoader;

namespace Desiccation.ModProjectiles.DD2.Ogre
{
	public class EtherianJavelinProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.aiStyle = 2;
			projectile.friendly = true;
		}
	}
}