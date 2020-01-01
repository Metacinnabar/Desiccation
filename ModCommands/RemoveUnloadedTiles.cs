using Desiccation.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Desiccation.ModCommands
{
	public class RenoveUnloadedTiles : ModCommand
	{
		public override CommandType Type => CommandType.Console | CommandType.World;
		public override string Command => "RemoveUnloadedTiles";
		public override string Description => "Removes all unloaded tiles from your world.";

		public override void Action(CommandCaller caller, string input, string[] args)
		{
			ushort MysteryTile = (ushort)ModLoader.GetMod("ModLoader").TileType("MysteryTile");
			int numRemoved = 0;
			for (int y = 0; y < Main.maxTilesY; y++)
			{
				for (int x = 0; x < Main.maxTilesX; x++)
				{
					var tile = Main.tile[x, y];
					if (tile.type == MysteryTile && tile.active())
					{
						tile.ResetToType(0);
						tile.active(false);
						numRemoved++;
					}
				}
			}
			DUtils.Chat($"{numRemoved} unloaded tiles removed.", true, Color.CornflowerBlue.R, Color.CornflowerBlue.G, Color.CornflowerBlue.B);
		}
	}
}