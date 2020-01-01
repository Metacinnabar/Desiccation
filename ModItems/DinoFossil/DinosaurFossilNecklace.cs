using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.ModItems.DinoFossil
{
	public class DinosaurFossilNecklace : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Increases armor penetration by 32");
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
			player.armorPenetration += 32;
		}
	}
}