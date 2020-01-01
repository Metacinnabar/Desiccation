using Desiccation.Utilities;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.Global
{
	public class DesiccationGlobalTile : GlobalTile
	{
		public int Timer = 0;

		public override void RightClick(int i, int j, int type)
		{
			if (type == TileID.ElderCrystalStand && DD2Event.Ongoing && DD2Event.TimeLeftBetweenWaves > 0 && DD2Event.EnemySpawningIsOnHold && ModContent.GetInstance<DesiccationGlobalConfig>().OOAWaitingTimeSkip)
			{
				Timer++;
				if (Timer > 1)
				{
					DUtils.Chat("Skipped the time between Old Ones Army waves!", true, 152, 144, 255);
					DD2Event.TimeLeftBetweenWaves = 0;
					Timer = 0;
				}
			}
		}
	}
}