﻿using Desiccation.DUtils;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation
{
	public class DesiccationGlobalTile : GlobalTile
	{
		public override void RightClick(int i, int j, int type)
		{
			if (type == TileID.ElderCrystalStand && DD2Event.Ongoing && DD2Event.TimeLeftBetweenWaves != 300 && DD2Event.EnemySpawningIsOnHold)
			{
				Misc.Chat("Skipped the time between Old Ones Army waves!", true, 152, 144, 255);
				DD2Event.TimeLeftBetweenWaves = 1;
			}
		}
	}
}