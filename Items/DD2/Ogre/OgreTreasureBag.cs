using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.Items.DD2.Ogre
{
	public class OgreTreasureBagT2 : ModItem
	{
		public override int BossBagNPC => NPCID.DD2OgreT2;
		public override string Texture => "Desiccation/Items/DD2/Ogre/OgreTreasureBag";

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("Right click to open");
		}

		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.rare = ItemRarityID.Expert;
			item.expert = true;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			player.QuickSpawnItem(ItemID.DefenderMedal, Main.rand.Next(6, 10));
			player.QuickSpawnItem(ModContent.ItemType<EtherianJavelin>(), 1);
		}
	}

	public class OgreTreasureBagT3 : ModItem
	{
		public override int BossBagNPC => NPCID.DD2OgreT3;
		public override string Texture => "Desiccation/Items/DD2/Ogre/OgreTreasureBag";

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("Right click to open");
		}

		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.rare = ItemRarityID.Expert;
			item.expert = true;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			player.QuickSpawnItem(ItemID.DefenderMedal, Main.rand.Next(8, 12));
			player.QuickSpawnItem(ModContent.ItemType<EtherianJavelin>(), 1);
		}
	}
}