using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

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

		/// <summary>
		/// Putting the backgrounds back for normal gameplay
		/// </summary>
		/// <param name="front"></param>
		/// <param name="middle"></param>
		/// <param name="back"></param>
		public static void BackgroundReReplacing(int front, int middle, int back)
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