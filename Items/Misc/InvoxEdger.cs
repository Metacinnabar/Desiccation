using Desiccation.Projectiles.Misc;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Desiccation.Items.Misc
{
	public class InvoxEdger : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 62;
			item.melee = true;
			item.width = 54;
			item.height = 38;
			item.channel = true;
			item.pick = 435;
			item.tileBoost = 13;
			item.noUseGraphic = true;
			item.useTime = 3;
			item.useAnimation = 25;
			item.useStyle = 5;
			item.knockBack = 2;
			item.value = 100;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ProjectileType<InvoxEdgerProjectile>();
			item.shootSpeed = 40f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(385);
			recipe.AddIngredient(386);
			recipe.AddIngredient(388);
			recipe.AddIngredient(1231);
			recipe.AddIngredient(579);
			recipe.AddIngredient(2798);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
