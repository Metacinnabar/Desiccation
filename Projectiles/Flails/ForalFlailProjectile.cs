using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Desiccation.Projectiles.Flails
{
	public class ForalFlailProjectile : ModProjectile
	{


		public override void SetDefaults()
		{
			projectile.width = 28;
			projectile.height = 28;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.aiStyle = 15;
			projectile.scale = 2.1f;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			//TODO: Rewrite this horride redcode.
			Texture2D texture = ModContent.GetTexture("Desiccation/Projectiles/Flails/ForalFlailProjectile_Chain");
			Vector2 projectileCenter = projectile.Center;
			Vector2 mountedCenter = Main.player[projectile.owner].MountedCenter;
			Rectangle? sourceRectangle = new Rectangle?(); //Useless?
			Vector2 rotationOrigin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
			float textureHeight = texture.Height;
			Vector2 vector2 = mountedCenter - projectileCenter; //Name this varible
			float rotation = (float)Math.Atan2(vector2.Y, vector2.X) - 1.57f;
			bool flag = true; //Name this varible

			if ((float.IsNaN(projectileCenter.X) && float.IsNaN(projectileCenter.Y)) || (float.IsNaN(vector2.X) && float.IsNaN(vector2.Y)))
			{
				flag = false;
			}

			while (flag)
			{
				if (vector2.Length() < textureHeight + 1.0)
				{
					flag = false;
				}
				else
				{
					Color color = projectile.GetAlpha(Lighting.GetColor((int)projectileCenter.X / 16, (int)(projectileCenter.Y / 16.0)));

					vector2.Normalize();
					projectileCenter += vector2 * textureHeight;
					vector2 = mountedCenter - projectileCenter;

					Main.spriteBatch.Draw(texture, projectileCenter - Main.screenPosition, sourceRectangle, color, rotation, rotationOrigin, 1.2f, SpriteEffects.None, 0);
				}
			}

			return true;
		}
	}
}