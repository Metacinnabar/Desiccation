using Desiccation.ModProjectiles.Flails;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.ModItems.Flails
{
	public class PlatinumSuperflail : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 10;
			item.value = Item.sellPrice(0, 0, 34, 12);
			item.rare = ItemRarityID.White;
			item.noMelee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 40;
			item.useTime = 40;
			item.knockBack = 6.5F;
			item.damage = 18;
			item.scale = 2f;
			item.noUseGraphic = true;
			item.shoot = ModContent.ProjectileType<PlatinumSuperflailProjectile>();
			item.shootSpeed = 18f;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.crit = 9;
			item.channel = true;
			item.healLife = 3;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Chain, 1);
			recipe.AddIngredient(ItemID.PlatinumBar, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}