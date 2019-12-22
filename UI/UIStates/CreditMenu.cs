using Desiccation.DUtils;
using Terraria.ModLoader;
using Terraria.UI;

namespace Desiccation.UI.UIStates
{
	internal class CreditMenu : UIState
	{
		public override void OnInitialize()
		{
			string text =
				"- Main Developers\n" +
				"WeirdHat - Main stater, co-owner\n" +
				"GoodPro712 - Main coder\n" +
				"Lemmy - Main content coder\n" +
				"Nobody - Stater, coder, balancer\n\n" +
				"- Developers\n" +
				"Syringe - Stater\n" +
				"Daimgamer - Main spriter\n" +
				"Vectix - Main spriter\n" +
				"Zando - Main respriter\n" +
				"Rebmiami - Google docs helper, stater, coder\n" +
				"AnAvailableUsername - Stater\n" +
                "Chem - Coder\n\n" +
				"- Contributers\n" +
				"Orange - Werewolf Staff\n" +
				"Spectre - Vanilla shop additions\n" +
				"TraoX - Markoth, werewolf staff and gem reflecter sprites\n" +
				"Corinna - PlayerData libary code\n" +
				"Plex - Multitool ideas & some sprites\n" +
				"Quartz - Some multitool sprites\n\n" +
				"- Main Helpers\n" +
				"Jopojelly - Huge help with code problems. Thx heaps!\n" +
				"Direwolf420 - Help with several code problems. Thx!\n" +
				"AbsoluteAquarian - Varius help with code problems. Thx alot!\n\n" +
				"- Small Helpers\n" +
				"Overhaul - Categorisation of config, and unload errors\n" +
				"Darthmoth - Desiccation logo generator (without edits)\n" +
				"Itorius - Help with weighted inventory\n\n" +
				"- Patrons\n" +
				"Thank you so much to all of our patrons!\n" +
				$"Current patrons from v{ModContent.GetInstance<Desiccation>().Version} of Desiccation:\n" +
				"No one yet.";

			Misc.UIInfoMessage_Show(text, 0);
		}
	}
}