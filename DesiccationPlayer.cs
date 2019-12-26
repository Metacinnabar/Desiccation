using Desiccation.DUtils;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Desiccation.DUtils.PlayerData;

namespace Desiccation
{
	public class DesiccationPlayer : ModPlayer
	{
		#region Fields

		private Dictionary<int, int> itemToMusicValue;
		private bool teamLoaded;
		private bool teamChanged;
		private int teamInt;
		private string teamString;

		#endregion Fields

		#region tModLoader Hooks

		public override void Initialize()
		{
			FieldInfo itemToMusicField = typeof(SoundLoader).GetField("itemToMusic", BindingFlags.Static | BindingFlags.NonPublic);
			itemToMusicValue = (Dictionary<int, int>)itemToMusicField.GetValue(null);
		}

		public override void UpdateVanityAccessories()
		{
			if (ModContent.GetInstance<DesiccationClientsideConfig>().VanityMusicBoxes)
			{
				for (int n = 13; n < 18 + MyPlayer.extraAccessorySlots; n++)
				{
					Item item = MyPlayer.armor[n];
					if (item.type >= ItemID.MusicBoxOverworldDay && item.type <= ItemID.MusicBoxBoss3)
					{
						Main.musicBox2 = item.type - ItemID.MusicBoxOverworldDay;
					}
					if (item.type >= ItemID.MusicBoxSnow && item.type <= ItemID.MusicBoxEclipse)
					{
						Main.musicBox2 = item.type - ItemID.MusicBoxSnow + 13;
					}
					if (item.type >= ItemID.MusicBoxPumpkinMoon && item.type <= ItemID.MusicBoxFrostMoon)
					{
						Main.musicBox2 = item.type - ItemID.MusicBoxPumpkinMoon + 28;
					}
					if (item.type >= ItemID.MusicBoxMartians && item.type <= ItemID.MusicBoxHell)
					{
						Main.musicBox2 = item.type - ItemID.MusicBoxMartians + 33;
					}
					if (item.type == ItemID.MusicBoxTowers || item.type == ItemID.MusicBoxGoblins)
					{
						Main.musicBox2 = item.type - ItemID.MusicBoxTowers + 36;
					}
					switch (item.type)
					{
						case ItemID.MusicBoxMushrooms:
							Main.musicBox2 = 27;
							break;

						case ItemID.MusicBoxUndergroundCrimson:
							Main.musicBox2 = 31;
							break;

						case ItemID.MusicBoxLunarBoss:
							Main.musicBox2 = 32;
							break;

						case ItemID.MusicBoxSandstorm:
							Main.musicBox2 = 38;
							break;

						case ItemID.MusicBoxDD2:
							Main.musicBox2 = 39;
							break;
					}
					if (itemToMusicValue.ContainsKey(item.type))
					{
						Main.musicBox2 = itemToMusicValue[item.type];
					}
				}
			}
		}

		public override void OnEnterWorld(Player player)
		{
			BackgroundReReplacing(173, 172, 171);
			GetTeamValues();
			if (MyPlayer.team != 0 && !teamChanged)
			{
				MyPlayer.team = teamInt;
				Misc.Chat("Team auto changed to " + teamString + " from config.", false, 172, 191, 184);
				teamChanged = true;
			}
			if (ModContent.GetInstance<DesiccationClientsideConfig>().WelcomeMessage)
			{
				Misc.Chat("Thanks for playing with Desiccation, " + MyName + ". Remeber to check out the config menu!", true, Color.CornflowerBlue.R, Color.CornflowerBlue.G, Color.CornflowerBlue.B);
			}
		}

		public override void SendClientChanges(ModPlayer localPlayer)
		{
			if (!teamLoaded)
			{
				if (MyPlayer.team > 0)
				{
					NetMessage.SendData(45, -1, -1, null, Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
				}
				teamLoaded = true;
			}
		}

		public override void PostUpdateMiscEffects()
		{
			if (ModContent.GetInstance<DesiccationGlobalConfig>().WeightedInventory)
			{
				int emptySlots = MyPlayer.inventory.Count(x => !x.IsAir);
				float speedAdd = 0.33f * (emptySlots - 29f) / 29f;
				MyPlayer.moveSpeed *= 1 - speedAdd;
			}
		}

		public override void PostUpdate()
		{
			if (player.IsPlayerTouchingTile(TileID.Cactus))
			{
				player.Hurt(PlayerDeathReason.ByCustomReason(" got spiked up their spine"), Main.rand.Next(7, 10), player.direction);
			}
		}

		#endregion tModLoader Hooks

		private void GetTeamValues()
		{
			teamString = ModContent.GetInstance<DesiccationClientsideConfig>().PvPTeam;
			switch (teamString)
			{
				case "None":
					teamInt = 0;
					break;

				case "Red":
					teamInt = 1;
					break;

				case "Green":
					teamInt = 2;
					break;

				case "Blue":
					teamInt = 3;
					break;

				case "Yellow":
					teamInt = 4;
					break;

				case "Pink":
					teamInt = 5;
					break;
			}
		}

		/// <summary>
		/// Putting the backgrounds back for normal gameplay
		/// </summary>
		/// <param name="front"></param>
		/// <param name="middle"></param>
		/// <param name="back"></param>
		internal void BackgroundReReplacing(int front, int middle, int back)
		{
			if (!Main.dedServ)
			{
				for (int i = 0; i < ModContent.GetInstance<Desiccation>().vanillaCloud.Length; i++)
				{
					Main.cloudTexture[i] = ModContent.GetInstance<Desiccation>().vanillaCloud[i];
				}
				Main.backgroundTexture[front] = ModContent.GetInstance<Desiccation>().vanillaFrontMainMenuBackground;
				Main.backgroundTexture[middle] = ModContent.GetInstance<Desiccation>().vanillaMiddleMainMenuBackground;
				Main.backgroundTexture[back] = ModContent.GetInstance<Desiccation>().vanillaBackMainMenuBackground;
			}
		}
	}
}