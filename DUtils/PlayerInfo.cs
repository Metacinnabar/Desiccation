using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using static Terraria.Main;
using static Terraria.Player;

namespace Desiccation.DUtils
{
	/// <summary>
	/// Contains information to alter or read information related to the player.
	/// </summary>
	internal static partial class PlayerData
	{

		/// <summary>
		/// Reference to the current player, yourself.
		/// </summary>
		public static Player MyPlayer
			=> LocalPlayer;

		/// <summary>
		/// Whether you have a diddley or a doodle.
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



		//NOTICE: If used in pre update vs post update you may
		// return different results.


		///------------------
		///Held Item Related
		///------------------

		#region PlayerInfo HeldItem




		#endregion

		///---------------------------------
		/// Player and LocalPlayer Position
		///---------------------------------

		#region PlayerInfo PlayerPos

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

		///------------------------------
		/// Player Frame Drawing Related
		///------------------------------

		#region PlayerInfo PlayerFrame

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
		public static Texture2D Head(Player Player, int Frame = 0)
		{
			return playerTextures[SkinVariant(Player), Frame];
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
			return playerHairTexture[HairID(Player)];
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
			return IsFemale ? armorBodyTexture[BodyID(Player)]
						   : femaleBodyTexture[BodyID(Player)];
		}

		/// <summary>
		/// The texture of the player's arm.
		/// </summary>
		/// <param name="Player">The player.</param>
		/// <returns>The player's arm texture2d.</returns>
		public static Texture2D PlayerArm(Player Player)
		{
			return armorArmTexture[BodyID(Player)];
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
			return armorLegTexture[LegID(Player)];
		}

		#endregion

		///-----------------
		/// Player Inventory
		///-----------------

		#region PlayerInfo PlayerInventory

		/// <summary>
		/// Gets the type id of an item in one of the main player's slots.
		/// </summary>
		/// <param name="Slot">The slot value in the inventory.</param>
		/// <returns>The int id of the item in that slot.</returns>
		public static int GetInventoryType(int Slot)
		{
			return LocalPlayer.inventory[Slot].type;
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
			return itemTexture[LocalPlayer.inventory[Slot].type];
		}

		#endregion


		///--------------
		/// Player Stats
		///--------------

		#region PlayerStats

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
		/// Gets the current health of a player.
		/// </summary>
		/// <param name="P">The player.</param>
		/// <returns>Int value of current life.</returns>
		public static int PlayerHealth(Player P)
		{
			return P.statLife;
		}

		/// <summary>
		/// Gets the max health of a player.
		/// </summary>
		/// <param name="P">The player.</param>
		/// <returns>Int value of the player's maximum health./returns>
		public static int PlayerMaxHealth(Player P)
		{
			return P.statLifeMax2;
		}

		/// <summary>
		/// Gets the current mana of a player.
		/// </summary>
		/// <param name="P">The player.</param>
		/// <returns>Int value of the player's mana.</returns>
		public static int PlayerMana(Player P)
		{
			return P.statMana;
		}

		/// <summary>
		/// Gets the max mana of a player.
		/// </summary>
		/// <param name="P">The player.</param>
		/// <returns></returns>
		public static int PlayerMaxMana(Player P)
		{
			return P.statManaMax2;
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


		public static float DefaultGravity
			=> defaultGravity;

		public static void SetDefaultGravity(float Gravity)
		{
			defaultGravity = Gravity;
		}

		public static void SetPlayerGravity(Player P, float Gravity)
		{
			P.gravity = Gravity;
		}

		public static void SetJumpHeight(int Height)
		{
			jumpHeight = Height;
		}

		public static void SetJumpSpeed(float Speed)
		{
			jumpSpeed = Speed;
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

		#region PlayerInfo MountRelated

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

		public static int HeldProjectile(Player P)
		{
			return P.heldProj;
		}

		public static void SetHeldProjectile(Player P, int Type)
		{
			P.heldProj = Type;
		}

		public static bool PortalPhysics(Player P)
		{
			return P.PortalPhysicsEnabled;
		}
	}

}
