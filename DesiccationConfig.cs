using Desiccation.Utilities;
using System.ComponentModel;
using Terraria.ModLoader.Config;
using static Desiccation.Utilities.PlayerData;

namespace Desiccation
{
	[Label("Clientside Config")]
	public class DesiccationClientsideConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide; // per player config

		[Header("Multiplayer")]
		[Label("Team Auto Join")]
		[Tooltip("You will automatically join this team after entering a world in multiplayer.")]
		[DrawTicks]
		[OptionStrings(new string[] { "None", "Red", "Green", "Blue", "Yellow", "Pink" })]
		[DefaultValue("None")]
		public string PvPTeam;

		[Header("Main Menu")]
		[Label("Background Changes")]
		[Tooltip("Changes for the main menu. False for no changes, true to change the whole main menu to a desert. True by default")]
		[DefaultValue(true)]
		public bool MainMenuDesert;

		[Header("Death Screen")]
		[Label("Respawn Timer")]
		[Tooltip("False for no timer on the death screen, true to show a timer until repawn on the death screen. True by default")]
		[DefaultValue(true)]
		public bool RespawnTimer;

		[Label("Respawn Timer Decimal")]
		[Tooltip("The amount of decimals to show on the respawn timer. Default 2")]
		[DrawTicks]
		[Range(0, 2)]
		[Increment(1)]
		[DefaultValue(2)]
		public int RespawnTimerDecimal;

		[Header("Accessories Slots")]
		[Label("Vanity Music Boxes")]
		[Tooltip("Making music boxes work in the vanity slots. False to keep them the same, true to be able to have music boxes play in vanity slots. True by default")]
		[DefaultValue(true)]
		public bool VanityMusicBoxes;

		[Header("Messages")]
		[Label("Welcome Message")]
		[Tooltip("Having a welcome message on world entry. False for no message, true for message. True by default")]
		[DefaultValue(true)]
		public bool WelcomeMessage;

		[Label("Eerie Messages")]
		[Tooltip("Having eerie message appear in chat and random times. False for no messages, true for messages. True by default")]
		[DefaultValue(true)]
		public bool EerieMessages;

		[Header("Tooltips")]
		[Label("Tool Tooltip Changes")]
		[Tooltip("If true, tools wont have a '%' in their tool power. True by default")]
		[DefaultValue(true)]
		public bool ToolTooltipRework;

		[Label("No Favorite Tooltips")]
		[Tooltip("If true, favorite tooltips wont be displayed. False by default")]
		[DefaultValue(false)]
		public bool NoFavoriteTooltips;

		[Header("UI")]
		[Label("Info Bar")]
		[Tooltip("If true, an info text bar will be displayed at the top of the screen. True by default")]
		[DefaultValue(true)]
		public bool NameInfo;
	}

	[Label("Global Config")]
	public class DesiccationGlobalConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide; // all player config

		[Header("Inventory")]
		[Label("Weighted Inventory")]
		[Tooltip("If true, you will go slower with a full inventory, and faster with an empty inventory.")]
		[DefaultValue(true)]
		public bool WeightedInventory;

		[Header("Multiplayer")]
		[Label("Player Name Change")]
		[Tooltip("If true, players can change their name. Default to true")]
		[DefaultValue(true)]
		public bool PlayerNameChange;

		[Header("Events")]
		[Label("OOA Skip Waiting Time")]
		[Tooltip("If true, you will be able to skip the waiting time between waves of the OOA. True by default.")]
		[DefaultValue(true)]
		public bool OOAWaitingTimeSkip;

		[Header("Items")]
		[Label("Sandgun Projectile Changes")]
		[Tooltip("If true, ebonsand, crimsand and pearlsand balls from a sandgun will give debuff to enemies. True by default.")]
		[DefaultValue(true)]
		public bool SandgunProjectileChanges;

		[Label("Resource Pickup")]
		[Tooltip("If true, resources will not pick up if they are not needed. True by default")]
		[DefaultValue(true)]
		public bool ResourcePickup;

		[Header("Town NPC Shop Additions")]
		[Label("Merchant - Target Dummy")]
		[Tooltip("If true, the merchant will sell target dummies when EoC has been defeated. True by default.")]
		[DefaultValue(true)]
		public bool Merchant_TargetDummy;

		[Label("Wizard - Ancient Manipulator")]
		[Tooltip("If true, the wizard will sell ancient manipulators when the Lunatic Cultist has been defeated. True by default.")]
		[DefaultValue(true)]
		public bool Wizard_AncientManipulator;

		[Header("NPC Drop Additions")]
		[Label("Bunny - FuzzyCarrot")]
		[Tooltip("If true, bunnies will have 1/150 chance of dropping a fuzzy carrot. True by default.")]
		[DefaultValue(true)]
		public bool Bunny_FuzzyCarrot;

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
		{
			if (NetData.IsPlayerServerOwner(MyPlayer))
			{
				return true;
			}
			else
			{
				message = "You are not the server host, and thus can't change global configs.";
				return false;
			}
		}
	}
}