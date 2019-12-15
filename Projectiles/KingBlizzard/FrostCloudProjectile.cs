using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.Projectiles.KingBlizzard
{
	internal class FrostCloudProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 4;
			projectile.height = 4;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.extraUpdates = 100;
			projectile.timeLeft = 200; // lowered from 300
			projectile.penetrate = -1;
			projectile.position = Main.MouseWorld;

		}

		public override string Texture => "Terraria/Projectile_" + ProjectileID.RainNimbus;

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			// If the player channels the weapon, do something. This check only works if item.channel is true for the weapon.
			if (player.channel)
			{
				float maxDistance = 18f; // This also sets the maximun speed the projectile can reach while following the cursor.
				Vector2 vectorToCursor = Main.MouseWorld - projectile.Center;
				float distanceToCursor = vectorToCursor.Length();

				// Here we can see that the speed of the projectile depends on the distance to the cursor.
				if (distanceToCursor > maxDistance)
				{
					distanceToCursor = maxDistance / distanceToCursor;
					vectorToCursor *= distanceToCursor;
				}

				int velocityXBy1000 = (int)(vectorToCursor.X * 1000f);
				int oldVelocityXBy1000 = (int)(projectile.velocity.X * 1000f);
				int velocityYBy1000 = (int)(vectorToCursor.Y * 1000f);
				int oldVelocityYBy1000 = (int)(projectile.velocity.Y * 1000f);

				// This code checks if the precious velocity of the projectile is different enough from its new velocity, and if it is, syncs it with the server and the other clients in MP.
				// We previously multiplied the speed by 1000, then casted it to int, this is to reduce its precision and prevent the speed from being synced too much.
				if (velocityXBy1000 != oldVelocityXBy1000 || velocityYBy1000 != oldVelocityYBy1000)
				{
					projectile.netUpdate = true;
				}
				projectile.velocity = vectorToCursor;
			}
		}
	}
}