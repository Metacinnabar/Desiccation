using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace Desiccation
{
	public class ClientSideConfig : ModConfig
	{
		public override bool Autoload(ref string name)
		{
			name = "Clientside Config";
			return true;
		}
		public override ConfigScope Mode => ConfigScope.ClientSide; // per player config

		[Label("Mechanics")]
		public MechanicMenu mechanicMenu = new MechanicMenu();

		[SeparatePage]
		public class MechanicMenu
		{
			[Header("Multiplayer")]

			[Label("Team to automatically join by each client")]
			[Tooltip("You will automaticly join this team after entering a world in multiplayer.")]
			[DrawTicks]
			[OptionStrings(new string[] { "None", "Red", "Green", "Blue", "Yellow", "Pink" })]
			[DefaultValue("None")]
			public static string PvPTeam;

			[Header("Inventory")]

			[Label("Weighted Inventory")]
			[Tooltip("If true, you will go slower at full inventory, and faster at empty inventory.")]
			[DefaultValue(true)]
			public static bool WeightedInventoryBool;
		}
	}
}