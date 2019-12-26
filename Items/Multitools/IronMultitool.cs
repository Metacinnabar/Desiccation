using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.Items.Multitools
{
	public class IronMultitool : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("The pinnacle of noobery.");
		}

		public override void SetDefaults()
		{
			item.damage = 10; // Base Damage of the Weapon
			item.width = 50; // Hitbox Width
			item.height = 50; // Hitbox Height
			item.useTime = 21; // Speed before reuse
			item.useAnimation = 16; // Animation Speed
			item.useStyle = 1; // 1 = Broadsword
			item.knockBack = 5f; // Weapon Knockbase: Higher means greater "launch" distance
			item.value = 340; // 10 | 00 | 00 | 00 : Platinum | Gold | Silver | Bronze
			item.rare = 0; // Item Tier
			item.UseSound = SoundID.Item1; // Sound effect of item on use
			item.autoReuse = true; // Do you want to torture people with clicking? Set to false
			item.axe = 11; // Axe Power - Higher Value = Better
			item.hammer = 45;
			item.pick = 45;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(10);
			recipe.AddIngredient(1);
			recipe.AddIngredient(6);
			recipe.AddIngredient(7);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}