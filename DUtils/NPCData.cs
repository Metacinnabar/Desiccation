using Terraria;
using Terraria.DataStructures;

namespace Desiccation.DUtils
{
	internal static class NPCData
	{
		public static void SpawnMoreThanOneNPCOfTheSameType(int NPCTypeToSpawn, Point16 SpawnPosition, int Amount = 1, Point16[] UniqueSpawnPositions = null)
		{
			if (UniqueSpawnPositions != null & UniqueSpawnPositions.Length != Amount)
			{
				return;
			}
			for (int Index = Amount; Amount > 0; Index--)
			{
				NPC.NewNPC(UniqueSpawnPositions != null ? UniqueSpawnPositions[Index].X : SpawnPosition.X, UniqueSpawnPositions != null ? UniqueSpawnPositions[Index].Y : SpawnPosition.Y, NPCTypeToSpawn);
			}
		}
	}
}