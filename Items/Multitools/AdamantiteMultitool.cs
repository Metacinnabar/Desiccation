using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.Items.Multitools
{
	public class AdamantiteMultitool : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("The pinnacle of noobery.");
		}

		public override void SetDefaults()
		{
			item.damage = 56; // Base Damage of the Weapon
			item.width = 50; // Hitbox Width
			item.height = 50; // Hitbox Height
			item.useTime = 33; // Speed before reuse
			item.useAnimation = 10; // Animation Speed
			item.useStyle = 1; // 1 = Broadsword
			item.knockBack = 5f; // Weapon Knockbase: Higher means greater "launch" distance
			item.value = 340; // 10 | 00 | 00 | 00 : Platinum | Gold | Silver | Bronze
			item.rare = 1; // Item Tier
			item.UseSound = SoundID.Item1; // Sound effect of item on use
			item.autoReuse = true; // Do you want to torture people with clicking? Set to false
			item.axe = 100; // Axe Power - Higher Value = Better
			item.hammer = 100;
			item.pick = 180;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(993);
			recipe.AddIngredient(482);
			recipe.AddIngredient(778);
			recipe.AddIngredient(387);
			recipe.AddIngredient(388);
			recipe.AddIngredient(406);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}