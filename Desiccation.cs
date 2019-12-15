#region Usings
using Desiccation.NPCs.TownNPCs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using ReLogic.OS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.UI.Chat;
using Terraria.Utilities;
using static Desiccation.DUtils.Mods;
using static Desiccation.DUtils.PlayerData;
#endregion

namespace Desiccation
{
	public class Desiccation : Mod
	{
		private const string releaseSuffix = "Beta Release!";
		public Desiccation()
		{
		}
		#region Fields
		private Texture2D vanillaLogoDay;
		private Texture2D vanillaLogoNight;
		private Texture2D vanillaSkyBackground;
		public Texture2D vanillaFrontMainMenuBackground;
		public Texture2D vanillaMiddleMainMenuBackground;
		public Texture2D vanillaBackMainMenuBackground;
		public Texture2D[] vanillaCloud = new Texture2D[22];
		internal UserInterface MinerUserInterface;
		private bool unloadCalled;
		private bool titleReplaced;
		private bool isInVersionRectangle;
		private bool isInDiscordRectangle;
		private bool isInGithubRectangle;
		private bool isInPatreonRectangle;
		private bool isInCreditRectangle;
		private bool isInLinkMenuRectangle;
		private bool linksOpen;
		private bool lastMouseLeft;
		public float fadePercent = 0;
		#endregion

		public override void Load()
		{
			#region Main Menu Changes
			vanillaFrontMainMenuBackground = Main.backgroundTexture[173];
			vanillaMiddleMainMenuBackground = Main.backgroundTexture[172];
			vanillaBackMainMenuBackground = Main.backgroundTexture[171];
			for (int i = 0; i < vanillaCloud.Length; i++)
			{
				vanillaCloud[i] = Main.cloudTexture[i];
			}
			vanillaSkyBackground = Main.backgroundTexture[0];
			vanillaLogoDay = Main.logoTexture;
			vanillaLogoNight = Main.logo2Texture;
			#endregion
			if (!Main.dedServ)
			{
				Main.backgroundTexture[0] = GetTexture("UI/Sky");
				Main.logoTexture = Main.logo2Texture = GetTexture("UI/DesiccationLogo");
				MinerUserInterface = new UserInterface();
			} 
			unloadCalled = false;
			Main.OnTick += OnTickEvent;
			Main.OnPostDraw += OnPostDrawEvent;
		}
		 
		public override void Unload()
		{
			#region Main Menu Changes
			Main.logoTexture = vanillaLogoDay;
			Main.logo2Texture = vanillaLogoNight;
			Main.backgroundTexture[0] = vanillaSkyBackground;
			for (int i = 0; i < vanillaCloud.Length; i++)
			{
				Main.cloudTexture[i] = vanillaCloud[i];
			}
			Main.backgroundTexture[173] = vanillaFrontMainMenuBackground;
			Main.backgroundTexture[172] = vanillaMiddleMainMenuBackground;
			Main.backgroundTexture[171] = vanillaBackMainMenuBackground;
			#endregion
			Main.OnTick -= OnTickEvent;
			Main.OnPostDraw -= OnPostDrawEvent;
			unloadCalled = true;
		}

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			int inventory = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));
			if (inventory != -1)
			{
				layers.Insert(inventory, new LegacyGameInterfaceLayer("Desiccation: Miner Light UI",
					delegate
					{
						MinerUserInterface.Draw(Main.spriteBatch, new GameTime());
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
			int deathText = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Death Text"));
			if (deathText != -1)
			{
				layers.Insert(deathText, new LegacyGameInterfaceLayer("Desiccation: Respawn Timer", delegate
				{
					if (MyPlayer.dead)
					{
						DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, Main.fontDeathText, string.Format("{0:f1}", MyPlayer.respawnTimer / 60f), new Vector2((Main.screenWidth / 2) - Main.fontDeathText.MeasureString(string.Format("{0:f1}", MyPlayer.respawnTimer / 60f)).X / 2f, (Main.screenHeight / 2 - 70)), MyPlayer.GetDeathAlpha(Color.Transparent));
					}
					return true;
				},
					InterfaceScaleType.UI)
				);
			}
		}

		public override void UpdateUI(GameTime gameTime)
		{
			MinerUserInterface?.Update(gameTime);
		}

		public override void PostSetupContent()
		{
			if (Census != null)
			{
				Census.Call("TownNPCCondition", ModContent.NPCType<Miner>(), "Have either a silver or tungsten pickaxe in your inventory, 1 gold in your inventory, and for the merchant to be housed.");
			}
		}

		public override void UpdateMusic(ref int music, ref MusicPriority priority)
		{
			string titlePrefix;
			WeightedRandom<string> titleSuffix = new WeightedRandom<string>();
			if (titleReplaced == false)
			{
				titlePrefix = "Terraria with Desiccation:";
				titleSuffix.Add("Waiting for titles.");
				titleSuffix.Add("Still wating...");
				Platform.Current.SetWindowUnicodeTitle(Main.instance.Window, titlePrefix + " " + titleSuffix);
				titleReplaced = true;
			}
		}

		public override void PreSaveAndQuit()
		{
			WorldGen.setBG(0, 6);
		}

		public override object Call(params object[] args)
		{
			try
			{
				string type = args[0] as string;
				if (type == "PickupResource")
				{
					int itemid = Convert.ToInt32(args[1]);
					return "Success";
				}
				else
				{
					Logger.Error($"Desiccation Mod.Call Error: No such type as {type}.");
				}
			}
			catch (Exception e)
			{
				Logger.Error("Desiccation Mod.Call Error:", e);
			}

			return null;
		}

		#region Events
		public void OnTickEvent()
		{
			if (Main.gameMenu)
			{
				fadePercent += MathHelper.ToRadians(1.7f * 360f / 60f);

				if (Overhaul == null)
				{
					Main.dayTime = true;
					Main.time = 40000;
					Main.sunModY = 5;
					RemoveClouds();
					LoadBackgrounds(new List<int>() { 173, 171, 172, 20, 21, 22 });
					MainMenuBackgroundSwap(20, 21, 22);
					return;
				}

				if (Main.menuMode == 10006 && !unloadCalled)
				{
					Unload();
					return;
				}
			}
		}

		public void OnPostDrawEvent(GameTime gametime)
		{
			if (Main.gameMenu)
			{
				Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
				MainMenuLinkDraw("Desiccation v" + Version + " - " + releaseSuffix, 8, "https://forums.terraria.org/index.php?threads/84525/", 10, ref isInVersionRectangle, "Forum");
				MainMenuLinkDraw("Desiccation Credits (In Development)", 36, "", -18, ref isInCreditRectangle, "Credits");
				if (!linksOpen)
				{
					MainMenuLinkDraw("Useful Links", 64, "", -46, ref isInLinkMenuRectangle, "Useful Links");
				}
				else
				{
					MainMenuLinkDraw("Need support? Discord!", 70, "https://discordapp.com/invite/btQqCdt", -52, ref isInDiscordRectangle, "Discord");
					//TODO: fix github link
					MainMenuLinkDraw("Got an issue to report? Github!", 100, "https://github.com/GoodPro712/DesiccationModBrowser", -82, ref isInGithubRectangle, "Github");
					MainMenuLinkDraw("Want to support development? Patreon!", 130, "https://patreon.com/tModLoader_Desiccation", -112, ref isInPatreonRectangle, "Patreon");
				}
				//TODO: Credit Menu
				Main.DrawCursor(Main.DrawThickCursor());
				Main.spriteBatch.End();
			}
			lastMouseLeft = Main.mouseLeft;
		}
		#endregion

		#region Main Menu Backgrounds
		/// <summary>
		/// Loads specifc backgrounds
		/// </summary>
		/// <param name="loadbgNumbers">The backgrounds to load.</param>
		public void LoadBackgrounds(List<int> loadbgNumbers)
		{
			if (!Main.dedServ)
			{
				foreach (int loadbgNumber in loadbgNumbers)
				{
					Main.instance.LoadBackground(loadbgNumber);
				}
			}
		}

		/// <summary>
		/// Call to remove cloud textures
		/// </summary>
		public void RemoveClouds()
		{
			for (int vanillaCloudTextureID = 0; vanillaCloudTextureID < vanillaCloud.Length; vanillaCloudTextureID++)
			{
				Main.cloudTexture[vanillaCloudTextureID] = GetTexture("UI/Blank");
			}
		}

		/// <summary>
		/// Call with the provided params to swap the main menu backgrounds.
		/// </summary>
		/// <param name="newFrontBackgroudID"></param>
		/// <param name="newMiddleBackgroundID"></param>
		/// <param name="newBackBackgroundID"></param>
		public void MainMenuBackgroundSwap(int newFrontBackgroudID, int newMiddleBackgroundID, int newBackBackgroundID)
		{
			Main.backgroundTexture[173] = Main.backgroundTexture[newFrontBackgroudID];
			Main.backgroundTexture[172] = Main.backgroundTexture[newMiddleBackgroundID];
			Main.backgroundTexture[171] = Main.backgroundTexture[newBackBackgroundID];
		}
		#endregion

		//TODO: Credit menu
		#region Credits
		private void Credits()
		{

		}
		#endregion

		#region Main Menu Text
		private void MainMenuLinkDraw(string text, float Y, string process, int offset, ref bool IsIn, string type)
		{
			#region Color Setting
			Color color;
			if (type == "Useful Links")
			{
				color = IsIn ? Color.White * 0.75f : Color.Lerp(Color.White * 0.50f, Color.Lerp(Color.SlateGray, Color.Black, 0.5f), (float)Math.Sin(fadePercent));
			}
			else
			{
				color = IsIn ? Color.White * 0.75f : Color.SlateGray;
			}
			Color newColor = Color.Black;
			for (int i = 0; i < 5; i++)
			{
				if (i == 4)
				{
					newColor = color;
					newColor.R = (byte)((255 + newColor.R) / 2);
					newColor.G = (byte)((255 + newColor.G) / 2);
					newColor.B = (byte)((255 + newColor.B) / 2);
				}
				newColor.A = (byte)(newColor.A * 0.5f);
			}
			#endregion Color Setting
			#region Rectangle & Hover/Click
			Vector2 size = ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, Main.fontMouseText, text, new Vector2(10f, Y), Color.Transparent, 0f, Vector2.Zero, new Vector2(1f, 1f));
			Rectangle rectangle = new Rectangle((int)10f, (int)Y, (int)size.X - 10, (int)size.Y + offset);
			if (rectangle.Contains(new Point(Main.mouseX, Main.mouseY)))
			{
				if (IsIn == false)
				{
					IsIn = true;
					Main.PlaySound(SoundID.MenuTick);
				}
			}
			else if (IsIn == true && !rectangle.Contains(new Point(Main.mouseX, Main.mouseY)))
			{
				IsIn = false;
			}
			if (!lastMouseLeft && Main.mouseLeft && rectangle.Contains(new Point(Main.mouseX, Main.mouseY)))
			{
				if (type == "Credits")
				{
					Main.PlaySound(SoundID.MenuOpen);
					//	Main.menuMode = 666;
					Credits();
				}
				else if (type == "Useful Links")
				{
					Main.PlaySound(SoundID.MenuOpen);
					linksOpen = true;
				}
				else
				{
					Main.PlaySound(SoundID.MenuOpen);
					Process.Start(process);
				}
			}
			#endregion Rectangle & Hover/Click
			ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, Main.fontMouseText, text, new Vector2(10f, Y), newColor, 0f, Vector2.Zero, new Vector2(1f, 1f));
		}
		#endregion
	}
}