using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.Items.Misc
{
	public class StarterBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Right click for goodies!");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.rare = 2;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			player.QuickSpawnItem(ItemID.MiningPotion, DUtils.Misc.RandomInt(1, 3));
			player.QuickSpawnItem(ItemID.SpelunkerPotion);
			if (Main.netMode != NetmodeID.SinglePlayer)
			{
				player.QuickSpawnItem(ItemID.WormholePotion, DUtils.Misc.RandomInt(2, 6));
			}
			player.QuickSpawnItem(ItemID.IronskinPotion, DUtils.Misc.RandomInt(1, 2));
			player.QuickSpawnItem(ItemID.LesserHealingPotion, DUtils.Misc.RandomInt(3, 6));
			player.QuickSpawnItem(ItemID.Torch, DUtils.Misc.RandomInt(22, 54));
			player.QuickSpawnItem(ItemID.SlimeStaff);
			player.QuickSpawnItem(ItemID.AmethystStaff);
			player.QuickSpawnItem(ItemID.IronBow);
			player.QuickSpawnItem(ItemID.IronBroadsword);
			player.QuickSpawnItem(ItemID.WoodenArrow, DUtils.Misc.RandomInt(100, 200));
			player.QuickSpawnItem(ItemID.Star, DUtils.Misc.RandomInt(3, 7));
		}
	}
}