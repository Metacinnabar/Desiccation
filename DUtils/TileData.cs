using Microsoft.Xna.Framework;
using Terraria;

namespace Desiccation.DUtils
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
	}
}