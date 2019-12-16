using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace Desiccation
{
	public class DesiccationClientsideConfig : ModConfig
	{
		public override bool Autoload(ref string name)
		{
			name = "Clientside Config";
			return true;
		}
		public override ConfigScope Mode => ConfigScope.ClientSide; // per player config

		[Header("Multiplayer")]

		[Label("Team Auto Join")]
		[Tooltip("You will automaticly join this team after entering a world in multiplayer.")]
		[DrawTicks]
		[OptionStrings(new string[] { "None", "Red", "Green", "Blue", "Yellow", "Pink" })]
		[DefaultValue("None")]
		public static string PvPTeam;

		[Header("Main Menu")]

		[Label("Background Changes")]
		[Tooltip("If true, the main menu's background will change to a desert, aswell as the logo.")]
		[DefaultValue(true)]
		public static bool MainMenuBackgroundChnages;

	}

	public class DesiccationGlobalConfig : ModConfig
	{
		public override bool Autoload(ref string name)
		{
			name = "Global Config";
			return true;
		}
		public override ConfigScope Mode => ConfigScope.ServerSide; // all player config

		[Header("Inventory Changes")]

		[Label("Weighted Inventory")]
		[Tooltip("If true, you will go slower with a full inventory, and faster with an empty inventory.")]
		[DefaultValue(true)]
		public static bool WeightedInventory;
	}
}