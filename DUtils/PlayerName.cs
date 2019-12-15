using Microsoft.Xna.Framework;
using Terraria;
using static Terraria.Main;

namespace Desiccation.DUtils
{
	/// <summary>
	/// This partial classs contains information getters related to the main player or server players' names.
	/// </summary>
	internal static partial class PlayerData
	{
		/// <summary>
		/// Gets the local player's name.
		/// </summary>
		public static string MyName
			=> MyPlayer.name;

		/// <summary>
		/// Gets the width and height of the local player's name.
		/// This information may be useful for user interface elements.
		/// </summary>
		public static Vector2 MyNameSize
			=> fontMouseText.MeasureString(MyName);

		/// <summary>
		/// Gets the width of the local player's name in pixels.
		/// This information may be useful for user interface elements.
		/// </summary>
		public static int MyNameWidth
			=> (int)MyNameSize.X;

		/// <summary>
		/// Gets the height of the local player's name in pixels.
		/// This information may be useful for user interface elements.
		/// </summary>
		public static int MyNameHeight
			=> (int)MyNameSize.Y;

		/// <summary>
		/// Gets the name of a player.
		/// </summary>
		/// <param name="P">The player.</param>
		/// <returns>Players name in String format.</returns>
		public static string PlayerName(Player P)
		{
			return P.name;
		}

		/// <summary>
		/// Gets the size ofa player's name.
		/// </summary>
		/// <param name="P">The Player</param>
		/// <returns>A vector2 containing the width and height of the player's name in pixels.</returns>
		public static Vector2 PlayerNameSize(Player P)
		{
			return fontMouseText.MeasureString(P.name);
		}
	}
}
