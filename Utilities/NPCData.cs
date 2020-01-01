using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace Desiccation.Utilities
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

		/// <summary>
		/// Adds an item to a town npc's item shop.
		/// </summary>
		/// <param name="type"></param>
		/// <param name="shop"></param>
		/// <param name="nextSlot"></param>
		/// <param name="TownNPCType">The type id of the town npc</param>
		/// <param name="ItemToAdd">The item id of the item to add</param>
		/// <param name="RequiredDownedBoss"></param>
		/// <param name="ConfigBool"></param>
		public static void AddItemToTownNPCShop(int type, Chest shop, ref int nextSlot, int TownNPCType, int ItemToAdd, bool RequiredDownedBoss = true, bool ConfigBool = true)
		{
			if (type == TownNPCType && RequiredDownedBoss && ConfigBool)
			{
				shop.item[nextSlot].SetDefaults(ItemToAdd);
				nextSlot++;
			}
		}

		/// <summary>
		/// Adds an item to a town npc's item shop with a custom buy price
		/// </summary>
		/// <param name="type"></param>
		/// <param name="shop"></param>
		/// <param name="nextSlot"></param>
		/// <param name="TownNPCType">The type id of the town npc</param>
		/// <param name="ItemToAdd">The item id of the item to add</param>
		/// <param name="CustomBuyPrice">The custom buy price for the item</param>
		/// <param name="RequiredDownedBoss"></param>
		/// <param name="ConfigBool"></param>
		public static void AddItemToTownNPCShopWithCustomBuyPrice(int type, Chest shop, ref int nextSlot, int TownNPCType, int ItemToAdd, int CustomBuyPrice, bool RequiredDownedBoss = true, bool ConfigBool = true)
		{
			if (type == TownNPCType && RequiredDownedBoss && ConfigBool)
			{
				shop.item[nextSlot].SetDefaults(ItemToAdd);
				shop.item[nextSlot].shopCustomPrice = CustomBuyPrice;
				nextSlot++;
			}
		}

		public static bool IsOnTile(this NPC npc, int x, int y)
		{
			Rectangle rectangle = npc.getRect();
			rectangle.Y += 1;
			return rectangle.Intersects(TileData.GetTileRectangle(x, y));
		}
	}
}