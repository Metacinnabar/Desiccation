using System.Collections.Generic;
using Terraria;

namespace Desiccation.Utilities
{
	internal static class BGData
	{
		public static void MainMenuBackgroundSwap(int newFrontBackgroudID, int newMiddleBackgroundID, int newBackBackgroundID)
		{
			Main.backgroundTexture[173] = Main.backgroundTexture[newFrontBackgroudID];
			Main.backgroundTexture[172] = Main.backgroundTexture[newMiddleBackgroundID];
			Main.backgroundTexture[171] = Main.backgroundTexture[newBackBackgroundID];
		}

		/// <summary>
		/// Loads specifc backgrounds
		/// </summary>
		/// <param name="loadbgNumbers">The backgrounds to load.</param>
		public static void LoadBackgrounds(List<int> loadbgNumbers)
		{
			if (!Main.dedServ)
			{
				foreach (int loadbgNumber in loadbgNumbers)
				{
					Main.instance.LoadBackground(loadbgNumber);
				}
			}
		}
	}
}