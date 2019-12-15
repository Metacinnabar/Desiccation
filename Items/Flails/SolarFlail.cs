using Desiccation.Projectiles.Flails;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.Items.Flails
{
	public class SolarFlail : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 10;
			item.value = Item.sellPrice(0, 0, 5, 0);
			item.rare = 0;
			item.noMelee = true;
			item.useStyle = 5;
			item.useAnimation = 40;
			item.useTime = 40;
			item.knockBack = 4F;
			item.damage = 60;
			item.scale = 2F;
			item.noUseGraphic = true;
			item.shoot = ModContent.ProjectileType<SolarFlailProjectile>();
			item.shootSpeed = 20F;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.crit = 11;
			item.channel = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentSolar, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}