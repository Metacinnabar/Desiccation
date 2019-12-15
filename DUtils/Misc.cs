using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;

namespace Desiccation.DUtils
{
	/// <summary>
	/// Misc utils.
	/// </summary>
	internal static partial class Misc
	{
		/// <summary>
		/// Used for generating random numbers.
		/// </summary>
		/// <param name="MinNumber"></param>
		/// <param name="MaxNumber"></param>
		/// <returns>Returns an random integer from >= min to < max.</returns>
		public static int RandomInt(int MinNumber, int MaxNumber)
		{
			return Main.rand.Next(MinNumber, MaxNumber);
		}

		/// <summary>
		/// Blends the two colors with the given bias towards "toColor". Made by direwolf420
		/// </summary>
		/// <param name="fromColor">The original color.</param>
		/// <param name="toColor">The color being blended towards.</param>
		/// <param name="fadePercent">The percent bias towards "toColor". Range[0, 1]</param>
		public static Color FadeBetween(Color fromColor, Color toColor, float fadePercent)
		{
			return fadePercent == 0f ? fromColor : new Color(fromColor.ToVector4() * (1f - fadePercent) + toColor.ToVector4() * fadePercent);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="rectangle">The rectangle.</param>
		/// <returns></returns>
		public static bool CountainsMouse(Rectangle rectangle)
		{
			return rectangle.Contains(new Point(Main.mouseX, Main.mouseY)) ? true : false;
		}

		/// <summary>
		/// The menuMode for your mods config.
		/// </summary>
		public const int UIModConfig = 10024;

		/// <summary>
		/// Checks if the date of the user's computer is the 25th of December.
		/// </summary>
		/// <returns>Returns true if it's the 25th of December on the user's current date of their computer.</returns>
		public static bool ChristmasDay()
		{
			DateTime now = DateTime.Now;
			int day = now.Day;
			int month = now.Month;
			bool xMas;
			if (day == 25 && month == 12)
			{
				xMas = true;
			}
			else
			{
				xMas = false;
			}
			return xMas;
		}

		/// <summary>
		/// Checks if the date of the user's computer is the 31st of October.
		/// </summary>
		/// <returns>Returns true if it's the 31st of October on the user's current date of their computer.</returns>
		public static bool HalloweenDay()
		{
			bool halloween;
			DateTime now = DateTime.Now;
			int day = now.Day;
			int month = now.Month;
			if (day == 31 && month == 10)
			{
				halloween = true;
			}
			else
			{
				halloween = false;
			}
			return halloween;
		}

		/// <summary>
		/// Checks if the netmode is singleplayer.
		/// </summary>
		/// <returns>Returns true if the netmode is singleplayer.</returns>
		public static bool Singleplayer()
		{
			return Main.netMode == NetmodeID.SinglePlayer;
		}

		/// <summary>
		/// Checks if the netmode isn't singleplayer.
		/// </summary>
		/// <returns>Returns true if the netmode isn't singleplayer.</returns>
		public static bool Multiplayer()
		{
			return Main.netMode != NetmodeID.SinglePlayer;
		}

		/// <summary>
		/// Sends a message to the chat. Examples: Chat("message") would send to everone on the server. Chat("message", false) would send just to the player.
		/// </summary>
		/// <param name="message"></param>
		/// <param name="multiplayer">If true, sends to whole server.</param>
		/// <param name="r"></param>
		/// <param name="g"></param>
		/// <param name="b"></param>
		public static void Chat(string message, bool multiplayer = true, byte r = 255, byte g = 255, byte b = 255)
		{
			switch (Main.netMode)
			{
				case NetmodeID.SinglePlayer:
					Main.NewText(message, r, g, b);
					break;
				case NetmodeID.MultiplayerClient:
					switch (multiplayer)
					{
						case true:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral(message), new Color(r, g, b));
							break;
						case false:
							Main.NewText(message, r, g, b);
							break;
					}
					break;
				case NetmodeID.Server:
					switch (multiplayer)
					{
						case true:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral(message), new Color(r, g, b));
							break;
						case false:
							Main.NewText(message, r, g, b);
							break;
					}
					break;
			}
		}

		/// <summary>
		/// Call with the provided params to swap the main menu backgrounds.
		/// </summary>
		/// <param name="newFrontBackgroudID"></param>
		/// <param name="newMiddleBackgroundID"></param>
		/// <param name="newBackBackgroundID"></param>
		public static void MainMenuBackgroundSwap(int newFrontBackgroudID, int newMiddleBackgroundID, int newBackBackgroundID)
		{
			Main.backgroundTexture[173] = Main.backgroundTexture[newFrontBackgroudID];
			Main.backgroundTexture[172] = Main.backgroundTexture[newMiddleBackgroundID];
			Main.backgroundTexture[171] = Main.backgroundTexture[newBackBackgroundID];
		}

		/// <summary>
		/// Loads specifc backgrounds
		/// </summary>
		/// <param name="loadbgNumbers">The backgrounds to load.</param>
		public static void LoadBackgrounds(List<int> loadbgNumbers)
		{
			if (!Main.dedServ)
			{
				foreach (int loadbgNumber in loadbgNumbers)
				{
					Main.instance.LoadBackground(loadbgNumber);
				}
			}
		}
	}
}

