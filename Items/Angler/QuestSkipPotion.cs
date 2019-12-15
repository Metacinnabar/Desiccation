using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.Items.Angler
{
	public class QuestSkipPotion : ModItem
	{

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Very useful for changing your name.");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 30;
			item.maxStack = 30;
			item.rare = 2;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.value = 200;
			item.UseSound = SoundID.Item3;
			item.consumable = true;
		}

		public override bool UseItem(Player player)
		{
			return true;
		}

		public override void AddRecipes()
		{

		}
	}
}