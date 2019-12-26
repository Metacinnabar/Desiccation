using System;
using Terraria;
using Terraria.ID;

namespace Desiccation.DUtils
{
	internal static class NetData
	{
		public static bool Singleplayer => Main.netMode == NetmodeID.SinglePlayer;

		public static bool Multiplayer => Main.netMode != NetmodeID.SinglePlayer;

		/// <summary>
		/// Checks to see if the player is the current server host. Thanks jopojelly.
		/// </summary>
		/// <param name="player"></param>
		/// <returns></returns>
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
	}
}