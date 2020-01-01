using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.ModProjectiles.Developer.Nobody
{
	public class NobodysBulletProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nobody's Bullet");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5; //The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[projectile.type] = 0; //The recording mode
		}

		public override void SetDefaults()
		{
			projectile.damage = 100;
			projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.ranged = true;
			projectile.penetrate = 5;
			projectile.timeLeft = 600;
			projectile.alpha = 255; //The transparency of the projectile, 255 for completely transparent.
			projectile.light = 0.5f; //How much light emit around the projectile
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
			projectile.extraUpdates = 1; //Set to above 0 if you want the projectile to update multiple time in a frame
			aiType = ProjectileID.Bullet;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			//If collide with tile, reduce the penetrate.
			//So the projectile can reflect at most 5 times
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
			else
			{
				Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
				Main.PlaySound(SoundID.Item10, projectile.position);
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = -oldVelocity.Y;
				}
			}
			return false;
		}

		//Note, you can use this with an NPC to shoot at a Player also
		//For every npc slot in Main.npc

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			//Redraw the projectile with the color not influenced by light
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}

		public override void Kill(int timeLeft)
		{
			// This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item10, projectile.position);
		}

		public override void AI()
		{
			for (int i = 0; i < 200; i++)
			{
				//Enemy NPC variable being set
				NPC target = Main.npc[i];

				//Getting the shooting trajectory
				float shootToX = target.position.X + target.width * 0.5f - projectile.Center.X;
				float shootToY = target.position.Y - projectile.Center.Y;
				float distance = (float)System.Math.Sqrt(shootToX * shootToX + shootToY * shootToY);

				//If the distance between the projectile and the live target is active
				if (distance < 480f && !target.friendly && target.active)
				{
					if (projectile.ai[0] > 4f) //Assuming you are already incrementing this in AI outside of for loop
					{
						//Dividing the factor of 3f which is the desired velocity by distance
						distance = 3f / distance;

						//Multiplying the shoot trajectory with distance times a multiplier if you so choose to
						shootToX *= distance * 5;
						shootToY *= distance * 5;

						//Shoot projectile and set ai back to 0
						Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, 14, 100, 0, Main.myPlayer, 0f, 0f); //Spawning a projectile\

						Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 11); //Bullet noise
						projectile.ai[1] = 0f;
					}
				}
			}
			projectile.ai[0] += 2f;
		}
	}
}