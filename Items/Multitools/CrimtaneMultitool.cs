using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.Items.Multitools
{
	public class CrimtaneMultitool : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crimtane Multitool");
			Tooltip.SetDefault("The pinnacle of noobery.");
		}

		public override void SetDefaults()
		{
			item.damage = 22; // Base Damage of the Weapon
			item.width = 50; // Hitbox Width
			item.height = 50; // Hitbox Height
			item.useTime = 25; // Speed before reuse
			item.useAnimation = 16; // Animation Speed
			item.useStyle = 1; // 1 = Broadsword
			item.knockBack = 5f; // Weapon Knockbase: Higher means greater "launch" distance
			item.value = 340; // 10 | 00 | 00 | 00 : Platinum | Gold | Silver | Bronze
			item.rare = 1; // Item Tier
			item.UseSound = SoundID.Item1; // Sound effect of item on use
			item.autoReuse = true; // Do you want to torture people with clicking? Set to false
			item.axe = 18; // Axe Power - Higher Value = Better
			item.pick = 70;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(799);
			recipe.AddIngredient(798);
			recipe.AddIngredient(796);
			recipe.AddIngredient(797);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}