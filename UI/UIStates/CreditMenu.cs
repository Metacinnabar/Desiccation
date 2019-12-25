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
				"GoodPro712 - Current owner of Desiccation, main coder & manager\n" +
				"WeirdHat - Main stater, co-owner\n" +
				"Lemmy - Main content coder\n" +
				"\n" +
				"- Developers\n" +
				"Plex - Idea for the mod creation, multitool ideas & some sprites\n" +
				"Nobody - Stater, coder\n" +
				"Chem - Coder\n" +
				"Syringe - Stater\n" +
				"Daimgamer - Main spriter\n" +
				"Vectix - Main spriter\n" +
				"Zando - Main respriter\n" +
				"Rebmiami - Google docs helper, stater, coder\n" +
				"AnAvailableUsername - Stater\n" +
                "Chem - Coder\n" +
				"\n" +
				"- Main Helpers\n" +
				"Jopojelly - Huge help with code problems. Thx heaps!\n" +
				"Direwolf420 - Help with several code problems. Thx!\n" +
				"AbsoluteAquarian - Varius help with code problems. Thx alot!\n" +
				"\n" +
				"- Contributers\n" +
				"Darkpuppey - King blizzard resprite and some other spriting things\n" +
				"Spencer - Some random sprites\n" +
				"Orange - Werewolf Staff\n" +
				"Spectre - Vanilla shop additions\n" +
				"TraoX - Markoth, werewolf staff and gem reflecter sprites\n" +
				"Corinna - PlayerData libary code\n" +
				"Quartz - Some multitool sprites\n" +
				"Overhaul - Categorisation of config & teaching me how to method.Invoke\n" +
				"Darthmoth - Desiccation logo generator (without edits)\n" +
				"Jaserd - Edits on the Desiccation logo\n" +
				"Fargo - AI for the Hyper Scope\n" +
				"Mirsario - Unload errors from logo swapping. NPCAIStyle class\n" +
				"Itorius - Help with weighted inventory\n" +
				"Anegorami - Some ebic ideas" +
				"\n" +
				"- Patrons\n" +
				"Thank you so much to all of our patrons!\n" +
				$"Current patrons from v{ModContent.GetInstance<Desiccation>().Version} of Desiccation:\n" +
				"No one yet.";

			Misc.UIInfoMessage_Show(text, 0);
		}
	}
}