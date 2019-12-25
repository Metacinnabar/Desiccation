
using Microsoft.Xna.Framework;
using Terraria;

namespace Desiccation.DUtils
{
	internal static class RectangleData
	{
		/// <summary>
		/// Returns true if thr cursor is colliding with the qualifing rectangle
		/// </summary>
		/// <param name="rectangle">The rectangle.</param>
		/// <returns></returns>
		public static bool CountainsCursor(this Rectangle rectangle)
			=> rectangle.Contains(new Point(Main.mouseX, Main.mouseY)) ? true : false;

		public static void Draw(this Rectangle rectangle)
		{
			//TODO: Needs Testing
			//rectangle.Offset((int)-Main.screenPosition.X, (int)-Main.screenPosition.Y);
			Main.spriteBatch.Draw(Main.magicPixel, rectangle, Color.White);
		}
	}
}