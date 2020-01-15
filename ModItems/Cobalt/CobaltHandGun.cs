using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Desiccation.ModItems.Cobalt
{
	public class CobaltHandGun : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("No.");
		}

		public override void SetDefaults() 
		{
			item.damage = 37;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;
			item.shoot = 10; 
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Bullet;
			
		}

		public override void AddRecipes()
	    {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(381, 25); 
			recipe.AddTile(TileID.MythrilAnvil); 
			recipe.SetResult(this);
			recipe.AddRecipe();


	    }
	}
}