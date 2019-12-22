using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection;
using Terraria;
using Terraria.ModLoader;

namespace Desiccation.DUtils
{
	/// <summary>
	/// Contains information to alter or read information related to the player.
	/// </summary>
	internal static class PlayerData
	{
		/// <summary>
		/// Reference to the current player, yourself.
		/// </summary>
		public static Player MyPlayer
			=> Main.LocalPlayer;

		/// <summary>
		/// Reference to Thorium's ModPlayer class.
		/// </summary>
		public static ModPlayer ThoriumPlayer
			=> Mods.Thorium.GetPlayer("ThoriumPlayer");

		#region Player Gender
		/// <summary>
		/// The player's gender.
		/// </summary>
		public enum Gender
		{
			Male,
			Female
		}

		/// <summary>
		/// Gets the gender of the player.
		/// </summary>
		/// <param name="Player">Player reference.</param>
		/// <returns>Male or Female</returns>
		public static Gender PlayerGender(Player Player)
		{
			return Player.Male ? Gender.Male : Gender.Female;
		}
		#endregion

		#region Player Position
		/// <summary>
		/// Direction of the player, -1 for left, 1 for right.
		/// </summary>
		/// <param name="Player">The player.</param> 
		/// <returns>-1 for left, 1 for right.</returns>
		public static int Direction(Player Player)
		{
			return Player.direction;
		}

		/// <summary>
		/// MyPlayer.position
		/// </summary>
		public static Vector2 MyPosition
			=> MyPlayer.position;
		#endregion

		#region Player Frames
		/// <summary>
		/// Gets the ID of the player's skin.
		/// </summary>
		/// <param name="Player">The Player.</param>
		/// <returns>The int ID of the player's skin.</returns>
		public static int SkinVariant(Player Player)
		{
			return Player.skinVariant;
		}

		/// <summary>
		/// Player's head texture.
		/// </summary>
		/// <param name="Player">The player.</param>
		/// <param name="Frame">Frame of the player's head.</param>
		/// <returns>Texture of the player's head.</returns>
		public static Texture2D Head(Player P, int Frame = 0)
		{
			return Main.playerTextures[SkinVariant(P), Frame];
		}

		/// <summary>
		/// Get the skin color of the player.
		/// </summary>
		/// <param name="Player">The Player.</param>
		/// <returns>A color ref to the player's skin.</returns>
		public static Color SkinColor(Player Player)
		{
			return Player.skinColor;
		}

		/// <summary>
		/// ID of the player's hair texture.
		/// </summary>
		/// <param name="Player">The player.</param>
		/// <returns>An int id of the player's hair.</returns>
		public static int HairID(Player Player)
		{
			return Player.hair;
		}

		/// <summary>
		/// Gets the player's hair texture.
		/// </summary>
		/// <param name="Player">The player.</param>
		/// <returns>Texture2d of the player's hair.</returns>
		public static Texture2D PlayerHair(Player Player)
		{
			return Main.playerHairTexture[HairID(Player)];
		}

		/// <summary>
		/// Get the player's hair color.
		/// </summary>
		/// <param name="Player">Player's hair color.</param>
		/// <param name="WithLighting">Whether to take lighting into account.</param>
		/// <returns>Color reference to hair color.</returns>
		public static Color HairColor(Player Player, bool WithLighting)
		{
			return Player.GetHairColor(WithLighting);
		}

		/// <summary>
		/// The ID of the player's body texture.
		/// </summary>
		/// <param name="Player">The Player.</param>
		/// <returns>The int ID of the body texture.</returns>
		public static int BodyID(Player Player)
		{
			return Player.body;
		}

		/// <summary>
		/// The texture of the player's body.
		/// </summary>
		/// <param name="Player">The player.</param>
		/// <param name="IsFemale">If the player is a female.
		/// Optional, defaults to false.</param>
		/// <returns>A texture2d reference to the player's body.</returns>
		public static Texture2D FemalePlayerBody(Player Player, bool IsFemale = false)
		{
			return IsFemale ? Main.armorBodyTexture[BodyID(Player)]
						   : Main.femaleBodyTexture[BodyID(Player)];
		}

		/// <summary>
		/// The texture of the player's arm.
		/// </summary>
		/// <param name="Player">The player.</param>
		/// <returns>The player's arm texture2d.</returns>
		public static Texture2D PlayerArm(Player P)
		{
			return Main.armorArmTexture[BodyID(P)];
		}

		/// <summary>
		/// The ID of the player's leg texture.
		/// </summary>
		/// <param name="Player">The player.</param>
		/// <returns>The int ID of the player's leg.</returns>
		public static int LegID(Player Player)
		{
			return Player.legs;
		}

		/// <summary>
		/// The texture of the player's legs.
		/// </summary>
		/// <param name="Player">The player.</param>
		/// <returns>The texture2d of the player's legs.</returns>
		public static Texture2D PlayerLegs(Player Player)
		{
			return Main.armorLegTexture[LegID(Player)];
		}
		#endregion

		#region Player Inventory

		/// <summary>
		/// Gets the type id of an item in one of the main player's slots.
		/// </summary>
		/// <param name="Slot">The slot value in the inventory.</param>
		/// <returns>The int id of the item in that slot.</returns>
		public static int GetInventoryType(int Slot)
		{
			return MyPlayer.inventory[Slot].type;
		}

		/// <summary>
		/// Gets the type id of an item in one of the player's main slots
		/// </summary>
		/// <param name="Player"></param>
		/// <param name="Slot"></param>
		/// <returns></returns>
		public static int GetInventoryType(Player Player, int Slot)
		{
			return Player.inventory[Slot].type;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Slot"></param>
		/// <returns></returns>
		public static Texture2D GetInventoryItemSlotTexture(int Slot)
		{
			return Main.itemTexture[MyPlayer.inventory[Slot].type];
		}
		#endregion

		#region Player Stats

		/// <summary>
		/// Local player's current health.
		/// </summary>
		public static int MyHealth
			=> MyPlayer.statLife;

		/// <summary>
		/// Local Player's max health.
		/// </summary>
		public static int MyMaxHealth
			=> MyPlayer.statLifeMax2;

		/// <summary>
		/// Local Player's current mana.
		/// </summary>
		public static int MyMana
			=> MyPlayer.statMana;

		/// <summary>
		/// Local player's max mana.
		/// </summary>
		public static int MyMaxMana
			=> MyPlayer.statManaMax2;

		/// <summary>
		/// Gets the value of bardResource from ThoriumPlayer.
		/// </summary>
		/// <returns>returns the bardResource value if Thorium is enabled, otherwise returns 0.</returns>
		public static int MyMusic
		{
			get
			{
				if (Mods.Thorium != null)
				{
					FieldInfo MusicReflection = ThoriumPlayer.GetType().GetField("bardResource", BindingFlags.Public | BindingFlags.Instance);
					int Music = (int)MusicReflection.GetValue(ThoriumPlayer);
					return Music;
				}
				return 0;
			}
		}

		/// <summary>
		/// Gets the value of bardResourceMax from ThoriumPlayer.
		/// </summary>
		/// <returns>returns the bardResourceMax value if Thorium is enabled, otherwise returns 0.</returns>
		public static int MyMaxMusic
		{
			get
			{
				if (Mods.Thorium != null)
				{
					FieldInfo MaxMusicReflection = ThoriumPlayer.GetType().GetField("bardResourceMax", BindingFlags.Public | BindingFlags.Instance);
					int MaxMusic = (int)MaxMusicReflection.GetValue(ThoriumPlayer);
					return MaxMusic;
				}
				return 0;
			}
		}

		/// <summary>
		/// Fasest speed at which a player can deccelerate.
		/// </summary>
		/// <param name="P">The player.</param>
		/// <returns>Float value of maximum fall speed.</returns>
		public static float PlayerMaxFallSpeed(Player P)
		{
			return P.maxFallSpeed;
		}

		/// <summary>
		/// Changes the maximum fall speed for a player.
		/// </summary>
		/// <param name="P">The player</param>
		/// <param name="NewMaxSpeed">The new value for the player's falling speed.</param
		public static void SetPlayerMaxFallSpeed(Player P, float NewMaxSpeed)
		{
			P.maxFallSpeed = NewMaxSpeed;
		}
		#endregion

		#region Player Name
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
			=> Main.fontMouseText.MeasureString(MyName);

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
			return Main.fontMouseText.MeasureString(P.name);
		}
		#endregion

		#region Player Movement
		public static float DefaultGravity
			=> Player.defaultGravity;

		public static void SetDefaultGravity(float Gravity)
		{
			Player.defaultGravity = Gravity;
		}

		public static void SetPlayerGravity(Player P, float Gravity)
		{
			P.gravity = Gravity;
		}

		public static void SetJumpHeight(int Height)
		{
			Player.jumpHeight = Height;
		}

		public static void SetJumpSpeed(float Speed)
		{
			Player.jumpSpeed = Speed;
		}

		public static void SetMaxRunSpeed(Player P, float Speed)
		{
			P.maxRunSpeed = Speed;
		}

		public static void SetRunAcceleration(Player P, float Accel)
		{
			P.runAcceleration = Accel;
		}

		public static void SetRunSlowDown(Player P, float Decelleration)
		{
			P.runSlowdown = Decelleration;
		}

		public static void SetAccRunSpeed(Player P, float Speed)
		{
			P.accRunSpeed = Speed;
		}
		#endregion

		#region Player States
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
		#endregion

		#region Mount Related

		public static bool ActiveMount(Player P)
		{
			return P.mount.Active;
		}

		public static bool InCartMount(Player P)
		{
			return P.mount.Cart;
		}

		public static bool OnWrongGround(Player P)
		{
			return P.onWrongGround;
		}

		public static bool SetOnWrongGround(Player P, bool Value)
		{
			return P.onWrongGround = Value;
		}

		#endregion

		#region Projectile Related
		public static int HeldProjectile(Player P)
		{
			return P.heldProj;
		}

		public static void SetHeldProjectile(Player P, int Type)
		{
			P.heldProj = Type;
		}
		#endregion

		#region Item Related
		/// <summary>
		/// Gets the bool value of Player.PortalPhysicsEnabled
		/// </summary>
		/// <param name="P">The player</param>
		/// <returns>Returns the bool value of Player.PortalPhysicsEnabled</returns>
		public static bool PortalPhysics(Player P)
		{
			return P.PortalPhysicsEnabled;
		}
		#endregion

		#region Biome Related
		/// <summary>
		/// Checks if the player is on the surface and not in any biome. Thanks Aqua.
		/// </summary>
		/// <param name="P">The player.</param>
		/// <returns>Returns true if player isn't in any biome and on the surface.</returns>
		public static bool IsPlayerInForest(Player P)
		{
			return !P.ZoneJungle && !P.ZoneDungeon && !P.ZoneCorrupt && !P.ZoneCrimson && !P.ZoneHoly && !P.ZoneSnow && !P.ZoneUndergroundDesert && !P.ZoneGlowshroom && !P.ZoneMeteor && P.ZoneOverworldHeight;
		}
		#endregion

		#region Armor Related

		#endregion
	}
}