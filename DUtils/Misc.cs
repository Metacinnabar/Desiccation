using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace Desiccation.DUtils
{
	internal static class Misc
	{
		public static bool ChristmasDay
		{
			get
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
		}

		public static bool HalloweenDay
		{
			get
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
		}

		/// <summary>
		/// Sends a message to the chat. Examples: Chat("message") would send to everone on the server. Chat("message", false) would send just to the player.
		/// </summary>
		/// <param name="message"></param>
		/// <param name="multiplayer">If true, sends to whole server.</param>
		/// <param name="r">r color</param>
		/// <param name="g">g color</param>
		/// <param name="b">b color</param>
		public static void Chat(string message, bool multiplayer = true, byte r = 255, byte g = 255, byte b = 255)
		{
			if (NetData.Singleplayer)
			{
				Main.NewText(message, r, g, b);
			}
			else if (NetData.Multiplayer)
			{
				if (multiplayer)
				{
					NetMessage.BroadcastChatMessage(NetworkText.FromLiteral(message), new Color(r, g, b));
				}
				else
				{
					Main.NewText(message, r, g, b);
				}
			}
		}

		public static float CenterStringXOnScreen(string text, DynamicSpriteFont font) => (Main.screenWidth / 2f) - font.MeasureString(text).X / 2;

		public static bool RandomFrom1OutOf(int number)
		{
			if (Main.rand.Next(1, number) == number)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		#region Bools
		public static bool IsInventoryOpen => Main.playerInventory;
		public static bool Crimson => WorldGen.crimson;
		public static bool Corruption => !WorldGen.crimson;
		#endregion
	}
}