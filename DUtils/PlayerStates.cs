using Terraria;

namespace Desiccation.DUtils
{
	internal static partial class PlayerData
	{
		/// <summary>
		/// Checks if the player is colliding with a liquid.
		/// </summary>
		/// <param name="P">The Player</param>
		/// <returns>True if the specified player is in a liquid, false if not.</returns>
		public static bool IsPlayerWet(Player P)
		{
			return P.wet;
		}

		/// <summary>
		/// Allows you to set the wet state of the player.
		/// </summary>
		/// <param name="P">The player</param>
		/// <param name="IsWet">If you want the player to be wet.</param>
		public static void SetPlayerWet(Player P, bool IsWet)
		{
			P.wet = IsWet;
		}

		/// <summary>
		/// Checks if the player is colliding with liquid honey.
		/// </summary>
		/// <param name="P">The player.</param>
		/// <returns>True if the player is in liquid honey, false if not.</returns>
		public static bool IsPlayerHoneyWet(Player P)
		{
			return P.honeyWet;
		}

		/// <summary>
		/// Allows you to set if the player is flagged for being in liquid honey.
		/// </summary>
		/// <param name="P">The Player</param>
		/// <param name="IsHoneyWet">If the player is in liquid honey.</param>
		public static void SetPlayerHoneyWet(Player P, bool IsHoneyWet)
		{
			P.honeyWet = IsHoneyWet;
		}

		/// <summary>
		/// Checks to see if the player is colliding with lava.
		/// </summary>
		/// <param name="P">The player.</param>
		/// <returns>True if the player is colliding with lava, otherwise false.</returns>
		public static bool IsPlayerLavaWet(Player P)
		{
			return P.lavaWet;
		}

		/// <summary>
		/// Lets you flag the player for being in lava.
		/// </summary>
		/// <param name="P">The player.</param>
		/// <param name="IsLavaWet">If the player is flagged for lava collision.</param>
		public static void SetPlayerLavaWet(Player P, bool IsLavaWet)
		{
			P.lavaWet = IsLavaWet;
		}

		public static bool IsPlayerHoneyWetAndWet(Player P)
		{
			return P.wet && P.honeyWet;
		}

		/// <summary>
		/// Checks if the specified player has the merman buff.
		/// </summary>
		/// <param name="P">The player.</param>
		/// <returns>True if the player is a Merman, false if not.</returns>
		public static bool IsPlayerIsMerman(Player P)
		{
			return P.merman;
		}

		/// <summary>
		/// Lets you toggle the flag for being a merman on a specified player.
		/// </summary>
		/// <param name="P">The player.</param>
		/// <param name="IsMerman"></param>
		/// <returns></returns>
		public static bool SetPlayerMerman(Player P, bool IsMerman)
		{
			return P.merman = IsMerman;
		}

		/// <summary>
		/// Checks if the player is on the surface and not in any biome. Thanks Aqua.
		/// </summary>
		/// <param name="P">The player.</param>
		/// <returns>Returns true if player isn't in any biome and on the surface.</returns>
		public static bool IsPlayerInForest(Player P)
		{
			return !P.ZoneJungle && !P.ZoneDungeon && !P.ZoneCorrupt && !P.ZoneCrimson && !P.ZoneHoly && !P.ZoneSnow && !P.ZoneUndergroundDesert && !P.ZoneGlowshroom && !P.ZoneMeteor && P.ZoneOverworldHeight;
		}
	}
}