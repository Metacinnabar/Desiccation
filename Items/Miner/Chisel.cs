using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.Items.Miner
{
	public class Chisel : ModItem
	{

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Makes your mining speed faster by 25%");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			item.value = 100000;
			item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.pickSpeed += player.pickSpeed / 4f;
		}
	}
}
