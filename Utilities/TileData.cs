using Microsoft.Xna.Framework;
using Terraria;

namespace Desiccation.Utilities
{
	internal static class TileData
	{
		/// <summary>
		/// Checks to see if the player's hitbox will collide with a solid tile/stairs
		/// </summary>
		/// <param name="P">The plyayer</param>
		/// <returns>return true if touching, else returns false</returns>
		public static bool SolidTileCollision(Player P)
		{
			foreach (Point x in P.TouchedTiles)
			{
				if ((Main.tile[x.X, x.Y]).active())
				{
					return true;
				}
			}
			return false;
		}

		public static bool IsPlatform(int type)
		{
			return Main.tileSolid[type] && Main.tileSolidTop[type];
		}

		/// <summary>
		/// Gets the tale's rectangle. Thx aqua
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public static Rectangle GetTileRectangle(int x, int y)
			=> new Rectangle(x * 16, y * 16, 16, 16);
	}
}