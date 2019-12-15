using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation
{
	public class DesiccationGlobalTile : GlobalTile
	{
		public override void RightClick(int i, int j, int type)
		{
			//OOA Wave Skip
			if (type == TileID.ElderCrystalStand && DD2Event.Ongoing && DD2Event.TimeLeftBetweenWaves != 300)
			{
				if (DD2Event.EnemySpawningIsOnHold)
				{
					Main.NewText("Skipped the time between Old Ones Army waves!", 152, 144, 255);
					DD2Event.TimeLeftBetweenWaves = 1;
				}
			}
		}
	}
}