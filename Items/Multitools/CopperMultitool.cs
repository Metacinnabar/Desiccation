using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.Items.Multitools
{
	public class CopperMultitool : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("The pinnacle of noobery.");
		}

		public override void SetDefaults()
		{
			item.damage = 5; // Base Damage of the Weapon
			item.width = 50; // Hitbox Width
			item.height = 50; // Hitbox Height
			item.useTime = 33; // Speed before reuse
			item.useAnimation = 16; // Animation Speed
			item.useStyle = 1; // 1 = Broadsword
			item.knockBack = 1f; // Weapon Knockbase: Higher means greater "launch" distance
			item.value = 340; // 10 | 00 | 00 | 00 : Platinum | Gold | Silver | Bronze
			item.rare = 1; // Item Tier
			item.UseSound = SoundID.Item1; // Sound effect of item on use
			item.autoReuse = true; // Do you want to torture people with clicking? Set to false
			item.axe = 7; // Axe Power - Higher Value = Better
			item.hammer = 35;
			item.pick = 35;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3509);
			recipe.AddIngredient(3506);
			recipe.AddIngredient(3507);
			recipe.AddIngredient(3505);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}