using Desiccation.Items.Misc;
using Desiccation.Items.Werewolf;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Desiccation.DUtils.Misc;
using static Terraria.ModLoader.ModContent;

namespace Desiccation.NPCs
{
	public class DesiccationGlobalNPC : GlobalNPC
	{

		public override void NPCLoot(NPC npc)
		{
			if (!npc.boss)
			{
				if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneBeach)
				{
					if (RandomInt(1, 100) == 1)
					{
						Item.NewItem(npc.getRect(), ItemType<SeaHeart>());
					}
				}
			}
			if (npc.type == NPCID.Zombie)
			{
				if (RandomInt(0, 9) == 0)
				{
					Item.NewItem(npc.getRect(), ItemID.Leather);
				}
			}
			if (npc.type == NPCID.Werewolf)
			{
				if (RandomInt(1, 3) == 1)
				{
					Item.NewItem(npc.getRect(), ItemType<WerewolfFur>(), RandomInt(1, 3));
				}
				if (RandomInt(1, 300) == 1)
				{
					Item.NewItem(npc.getRect(), ItemType<Items.Werewolf.MoonStaff>());
				}
			}
			if (npc.type == NPCID.Bunny)
			{
				if (RandomInt(0, 149) == 0)
				{
					Item.NewItem(npc.getRect(), ItemID.FuzzyCarrot);
				}
			}
		}

		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (type == NPCID.Wizard)
			{
				if (NPC.downedAncientCultist)
				{
					shop.item[nextSlot].SetDefaults(ItemID.LunarCraftingStation);
					nextSlot++;
				}
			}
			if (type == NPCID.Merchant)
			{
				if (NPC.downedBoss1)
				{
					shop.item[nextSlot].SetDefaults(ItemID.TargetDummy);
					shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 1, 0, 0);
					nextSlot++;
				}
			}
		}
	}
}
