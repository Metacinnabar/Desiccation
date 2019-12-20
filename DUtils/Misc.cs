using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

		public static bool Singleplayer
			=> Main.netMode == NetmodeID.SinglePlayer;

		public static bool Multiplayer
			=> Main.netMode != NetmodeID.SinglePlayer;

		public static Texture2D BlankTexture
	=> ModContent.GetTexture("Desiccation/UI/Textures/Blank");

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
		public static bool CountainsMouse(this Rectangle rectangle)
		{
			return rectangle.Contains(new Point(Main.mouseX, Main.mouseY)) ? true : false;
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
			if (Singleplayer)
			{
				Main.NewText(message, r, g, b);
			}
			else if (Multiplayer)
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

		public static void UIInfoMessage_Show(string text, int gotoMenu)
		{
			Type Interface = typeof(ModLoader).Assembly.GetType("Terraria.ModLoader.UI.Interface");
			Type UIInfoMessage = typeof(ModLoader).Assembly.GetType("Terraria.ModLoader.UI.UIInfoMessage");
			FieldInfo infoMessage = Interface.GetField("infoMessage", BindingFlags.Static | BindingFlags.NonPublic);
			UIElement infoMessageValue = (UIElement)infoMessage.GetValue(null);
			MethodInfo Show = UIInfoMessage.GetMethod("Show", BindingFlags.Instance | BindingFlags.NonPublic);
			if (Show != null)
			{
				Show.Invoke(infoMessageValue, new object[5]
				{
					text, gotoMenu, null, "", null
				});
			}
		}

		public static bool IsPlayerServerOwner(Player player)
		{
			for (int plr = 0; plr < Main.maxPlayers; plr++)
			{
				Console.WriteLine(Netplay.Clients[plr].Socket.GetRemoteAddress());
				if (Netplay.Clients[plr].State == 10 && Main.player[plr] == player && Netplay.Clients[plr].Socket.GetRemoteAddress().IsLocalHost())
				{
					return true;
				}
			}
			return false;
		}

		public static bool IsPlayerName(string name)
		{
			if (PlayerData.MyName == name)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

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
	}
}