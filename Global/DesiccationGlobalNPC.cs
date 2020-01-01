using Desiccation.Utilities;
using Desiccation.ModItems.Werewolf;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Desiccation.ModItems.AngryNimbus;

namespace Desiccation.Global
{
	public class DesiccationGlobalNPC : GlobalNPC
	{
		public override void NPCLoot(NPC npc)
		{
			if (npc.type == NPCID.Bunny)
			{
				if (DUtils.RandomFrom1OutOf(150) && ModContent.GetInstance<DesiccationGlobalConfig>().Bunny_FuzzyCarrot)
				{
					Item.NewItem(npc.getRect(), ItemID.FuzzyCarrot);
				}
			}

			if (npc.type == NPCID.AngryNimbus)
			{
				if (DUtils.RandomFrom1OutOf(99))
				{
					Item.NewItem(npc.getRect(), ModContent.ItemType<WaterFall>());
				}
			}

			if (npc.type == NPCID.Werewolf)
			{
				if (DUtils.RandomFrom1OutOf(3))
				{
					Item.NewItem(npc.getRect(), ModContent.ItemType<WerewolfFur>(), Main.rand.Next(1, 3));
				}
				if (DUtils.RandomFrom1OutOf(100))
				{
					Item.NewItem(npc.getRect(), ModContent.ItemType<MoonStaff>());
				}
			}
		}

		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			NPCData.AddItemToTownNPCShop(type, shop, ref nextSlot, NPCID.Merchant, ItemID.TargetDummy, NPC.downedBoss1, ModContent.GetInstance<DesiccationGlobalConfig>().Merchant_TargetDummy);
			NPCData.AddItemToTownNPCShopWithCustomBuyPrice(type, shop, ref nextSlot, NPCID.Wizard, ItemID.LunarCraftingStation, Item.buyPrice(1, 0, 0, 0), NPC.downedAncientCultist, ModContent.GetInstance<DesiccationGlobalConfig>().Wizard_AncientManipulator);
			NPCData.AddItemToTownNPCShopWithCustomBuyPrice(type, shop, ref nextSlot, NPCID.Merchant, ItemID.WhoopieCushion, Item.buyPrice(0, 1, 0, 0), NPC.downedBoss2);
		}
	}
}