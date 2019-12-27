using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.Items.Multitools
{
	public class GoldMultitool : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("The pinnacle of noobery.");
		}

		public override void SetDefaults()
		{
			item.damage = 13; // Base Damage of the Weapon
			item.width = 50; // Hitbox Width
			item.height = 50; // Hitbox Height
			item.useTime = 20; // Speed before reuse
			item.useAnimation = 16; // Animation Speed
			item.useStyle = 1; // 1 = Broadsword
			item.knockBack = 5f; // Weapon Knockbase: Higher means greater "launch" distance
			item.value = 340; // 10 | 00 | 00 | 00 : Platinum | Gold | Silver | Bronze
			item.rare = 0; // Item Tier
			item.UseSound = SoundID.Item1; // Sound effect of item on use
			item.autoReuse = true; // Do you want to torture people with clicking? Set to false
			item.axe = 13; // Axe Power - Higher Value = Better
			item.hammer = 55;
			item.pick = 55;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3518);
			recipe.AddIngredient(3521);
			recipe.AddIngredient(3519);
			recipe.AddIngredient(3517);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}