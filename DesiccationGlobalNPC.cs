using Desiccation.DUtils;
using Desiccation.Items.Misc;
using Desiccation.Items.Werewolf;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
					if (Misc.RandomFrom1OutOf(100))
					{
						Item.NewItem(npc.getRect(), ModContent.ItemType<SeaHeart>());
					}
				}
			}
			if (npc.type == NPCID.Bunny)
			{
				if (Misc.RandomFrom1OutOf(150) && ModContent.GetInstance<DesiccationGlobalConfig>().Bunny_FuzzyCarrot)
				{
					Item.NewItem(npc.getRect(), ItemID.FuzzyCarrot);
				}
			}
			if (npc.type == NPCID.Werewolf)
			{
				if (Misc.RandomFrom1OutOf(3))
				{
					Item.NewItem(npc.getRect(), ModContent.ItemType<WerewolfFur>(), Main.rand.Next(1, 3));
				}
				if (Misc.RandomFrom1OutOf(100))
				{
					Item.NewItem(npc.getRect(), ModContent.ItemType<MoonStaff>());
				}
			}
		}

		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (type == NPCID.Wizard && NPC.downedAncientCultist && ModContent.GetInstance<DesiccationGlobalConfig>().Wizard_AncientManipulator)
			{
				shop.item[nextSlot].SetDefaults(ItemID.LunarCraftingStation);
				shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1, 0, 0, 0);
				nextSlot++;
			}
			if (type == NPCID.Merchant && NPC.downedBoss1 && ModContent.GetInstance<DesiccationGlobalConfig>().Merchant_TargetDummy)
			{
				shop.item[nextSlot].SetDefaults(ItemID.TargetDummy);
				nextSlot++;
			}
		}
	}
}
