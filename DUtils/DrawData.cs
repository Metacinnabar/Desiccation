using Microsoft.Xna.Framework;
using ReLogic.Graphics;
using Terraria;

namespace Desiccation.DUtils
{
	/// <summary>
	/// Used for drawing related data, rectangle related data, and vector2 related data
	/// </summary>
	internal static class DrawData
	{
		/// <summary>
		/// Returns true if thr cursor is colliding with the qualifing rectangle
		/// </summary>
		/// <param name="rectangle">The rectangle.</param>
		/// <returns></returns>
		public static bool ContainsCursor(this Rectangle rectangle)
			=> rectangle.Contains(new Point(Main.mouseX, Main.mouseY)) ? true : false;

		public static void Draw(this Rectangle rectangle)
		{
			//TODO: Needs Testing
			//rectangle.Offset((int)-Main.screenPosition.X, (int)-Main.screenPosition.Y);
			Main.spriteBatch.Draw(Main.magicPixel, rectangle, Color.White);
		}

		public static float CenterStringXOnScreen(string text, DynamicSpriteFont font)
			=> (Main.screenWidth / 2f) - font.MeasureString(text).X / 2;
	}
}