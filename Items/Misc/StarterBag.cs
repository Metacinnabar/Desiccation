using Desiccation.DUtils;
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
			player.QuickSpawnItem(ItemID.MiningPotion, Main.rand.Next(1, 3));
			player.QuickSpawnItem(ItemID.SpelunkerPotion);
			if (NetData.Multiplayer)
			{
				player.QuickSpawnItem(ItemID.WormholePotion, Main.rand.Next(2, 6));
			}
			player.QuickSpawnItem(ItemID.IronskinPotion, Main.rand.Next(1, 2));
			player.QuickSpawnItem(ItemID.LesserHealingPotion, Main.rand.Next(3, 6));
			player.QuickSpawnItem(ItemID.Torch, Main.rand.Next(22, 54));
			player.QuickSpawnItem(ItemID.SlimeStaff);
			player.QuickSpawnItem(ItemID.AmethystStaff);
			player.QuickSpawnItem(ItemID.IronBow);
			player.QuickSpawnItem(ItemID.IronBroadsword);
			player.QuickSpawnItem(ItemID.WoodenArrow, Main.rand.Next(100, 200));
			player.QuickSpawnItem(ItemID.Star, Main.rand.Next(3, 7));
		}
	}
}