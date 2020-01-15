using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Desiccation.ModItems.Orichalcum
{
	public class OrichalcumAssaultRifle : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("OOf.");
		}

		public override void SetDefaults()
		{
			item.damage = 38;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 11;
			item.useAnimation = 11;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; 
			item.shootSpeed = 14f;
			item.useAmmo = AmmoID.Bullet;
		}

		public override void AddRecipes()
	    {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(1191, 25); 
			recipe.AddTile(TileID.MythrilAnvil); 
			recipe.SetResult(this);
			recipe.AddRecipe();
	    }


	}
}
