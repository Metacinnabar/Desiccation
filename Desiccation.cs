#region Usings
using Desiccation.DUtils;
using Desiccation.UI.UIStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.UI.Chat;
using static Desiccation.DUtils.PlayerData;
#endregion

namespace Desiccation
{
	public class Desiccation : Mod
	{
		//--Stuff for GoodPro712 to do:
		//TODO: Cactie deal damage but no knockback. 
		//TODO: Search for player names and worlds
		//TODO: Shift z shows extra stats
		//TODO: Piggybank UI when nurse npc chat is active
		//TODO: Show info on vanity accessories. Code for this in antisocial
		//TODO: Statue enemies drop loot if requirements are met
		//TODO: Rework dev weapons. balanace out
		//0.11.6 TODO: All items don't burn via GlobalItem.CanBurnInLava() return false;
		//TODO: Overequipping
		//TODO: IL Edit the ooa wave countdown timer
		//TODO: Quick stack ammo and coins
		//TODO: Multitool Rework with select ui and random thing. Ideas in #concept-discussion. fix multitool sprites aswell
		//TODO: Able to hold right click to open bags and crates etc. IL Edit
		//TODO: discord tags for credits
		//TODO: Create desiccation email, youtube and twitter and twitter discord webhook

		//--Stuff for Lemmy to do:
		//TODO: Make squirrels fall out of trees in random ammounts and sometimes none. Maybe make use of NPCData.SpawnMoreThanOneNPCOfTheSameType
		//TODO: Rework sifting pan. the stats are in #stating
		//TODO: Rework overbright torch. Mak eit burn out after a certain amount of time of it being selected. Maybe progress bar under sprite? for goodpro to do? idk

		//--Stuff for Reb to do:
		//TODO: Banner rework? stats in the checklist google doc.

		//--Stuff for Nobody to do:
		//TODO: Constructer potion. stats pinned in #stating

		#region Fields
		private Texture2D vanillaLogoDay;
		private Texture2D vanillaLogoNight;
		private Texture2D vanillaSkyBackground;
		public Texture2D vanillaFrontMainMenuBackground;
		public Texture2D vanillaMiddleMainMenuBackground;
		public Texture2D vanillaBackMainMenuBackground;
		public Texture2D[] vanillaCloud = new Texture2D[22];
		internal static CreditMenu creditMenuUI;
		private bool unloadCalled;
		private bool isInVersionRectangle;
		private bool isInDiscordRectangle;
		private bool isInGithubRectangle;
		private bool isInPatreonRectangle;
		private bool isInCreditRectangle;
		private bool isInLinkMenuRectangle;
		private bool linksOpen;
		private bool lastMouseLeft;
		public float fadePercent = 0;
		private static string releaseSuffix;
		public static DesiccationGlobalConfig GlobalConfig = ModContent.GetInstance<DesiccationGlobalConfig>();
		public static DesiccationClientsideConfig ClientConfig = ModContent.GetInstance<DesiccationClientsideConfig>();
		#endregion

		public Desiccation()
		{
		}

		#region tModLoader Hooks
		public override void Load()
		{
			#region Main Menu Backups
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
			#region Update Names
			if (Version >= new Version(0, 1))
			{
				releaseSuffix = "Beta Release!";
			}
			if (Version >= new Version(1, 0))
			{
				releaseSuffix = "Release!";
			}
			if (Version >= new Version(2, 0))
			{
				releaseSuffix = "Biome Update #1!";
			}
			if (Version >= new Version(3, 0))
			{
				releaseSuffix = "Qol Update #1!";
			}
			#endregion
			unloadCalled = false;
			Main.OnTick += OnTickEvent;
			Main.OnPostDraw += OnPostDrawEvent;
			Main.OnPreDraw += OnPreDrawEvent;
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
			Main.OnPreDraw -= OnPreDrawEvent;
			unloadCalled = true;
		}

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			int deathText = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Death Text"));
			if (deathText != -1)
			{
				layers.Insert(deathText, new LegacyGameInterfaceLayer("Desiccation: Respawn Timer", delegate
				{
					if (MyPlayer.dead && ModContent.GetInstance<DesiccationClientsideConfig>().RespawnTimer)
					{
						DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, Main.fontDeathText, string.Format("{0:f" + ModContent.GetInstance<DesiccationClientsideConfig>().RespawnTimerDecimal + "}", MyPlayer.respawnTimer / 60f), new Vector2((Main.screenWidth / 2) - Main.fontDeathText.MeasureString(string.Format("{0:f" + ModContent.GetInstance<DesiccationClientsideConfig>().RespawnTimerDecimal + "}", MyPlayer.respawnTimer / 60f)).X / 2f, Main.screenHeight / 2 - 70), MyPlayer.GetDeathAlpha(Color.Transparent));
					}
					return true;
				},
					InterfaceScaleType.UI)
				);
			}
			int mouseText = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (mouseText != -1)
			{
				layers.Insert(mouseText, new LegacyGameInterfaceLayer("Desiccation: Player Name", delegate
				{
					if (!Main.gameMenu && ModContent.GetInstance<DesiccationClientsideConfig>().NameInfo && !Misc.IsInventoryOpen)
					{
						string text = $"{MyName} in {Main.worldName}";
						Vector2 size = Utils.DrawBorderString(Main.spriteBatch, text, new Vector2(Misc.CenterStringXOnScreen(text, Main.fontMouseText), 2f), Color.WhiteSmoke);
						Rectangle rectangle = new Rectangle((int)Misc.CenterStringXOnScreen(text, Main.fontMouseText), 2, (int)size.X + 2, (int)size.Y - 10);
						if (rectangle.CountainsMouse())
						{
							Main.hoverItemName = "Type in chat to change names. '/playername NEW NAME' to change player name, '/worldname NEW NAME' to change world name.";
						}
					}
					return true;
				},
					InterfaceScaleType.UI) 
				);
			}
		}

		public override void PreSaveAndQuit()
		{
			WorldGen.setBG(0, 6);
		}
		#endregion

		#region Events
		private void OnTickEvent()
		{
			if (Main.gameMenu)
			{
				fadePercent += MathHelper.ToRadians(1.7f * 360f / 60f);

				if (Mods.Overhaul == null)
				{
					if (ModContent.GetInstance<DesiccationClientsideConfig>().MainMenuDesert)
					{
						Main.dayTime = true;
						Main.time = 40000;
						Main.sunModY = 5;

						if (!Main.dedServ)
						{
							Misc.LoadBackgrounds(new List<int>() { 173, 171, 172, 20, 21, 22 });
							Misc.MainMenuBackgroundSwap(20, 21, 22);
							for (int vanillaCloudTextureID = 0; vanillaCloudTextureID < vanillaCloud.Length; vanillaCloudTextureID++)
							{
								Main.cloudTexture[vanillaCloudTextureID] = Misc.BlankTexture;
							}
							Main.backgroundTexture[0] = GetTexture("UI/Textures/Sky");
							Main.logoTexture = Main.logo2Texture = GetTexture("UI/Textures/DesiccationDesertLogo");
						}
					}
					else
					{
						if (!Main.dedServ)
						{
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
						}
					}
					if (Main.menuMode == 10006 && !unloadCalled)
					{
						Unload();
						return;
					}
				}
			}
		}

		private void OnPreDrawEvent(GameTime gameTime)
		{
			if (tModLoaderVersion >= new Version(0, 11, 6))
			{
				Type DD2Event = typeof(ModLoader).Assembly.GetType("Terraria.GameContent.Events.DD2Event");
				FieldInfo TimeLeftBetweenWavesTimer = DD2Event.GetField("TimeLeftBetweenWavesTimer", BindingFlags.Static | BindingFlags.Public);
				TimeLeftBetweenWavesTimer.SetValue(DD2Event, string.Format("Right-Click to Skip: {0}", Terraria.GameContent.Events.DD2Event.TimeLeftBetweenWaves / 60));
			}
		}

		private void OnPostDrawEvent(GameTime gametime)
		{
			if (Main.gameMenu)
			{
				Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
				MainMenuLinkDraw("Desiccation v" + Version + " - " + releaseSuffix, 8, "https://forums.terraria.org/index.php?threads/84525/", 10, ref isInVersionRectangle, "Forum");
				MainMenuLinkDraw("Desiccation Credits ", 36, "", -18, ref isInCreditRectangle, "Credits");
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
					if (Main.menuMode == 0)
					{
						Main.PlaySound(SoundID.MenuOpen);
						creditMenuUI = new CreditMenu();
						UserInterface.ActiveInstance.SetState(creditMenuUI);
					}
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