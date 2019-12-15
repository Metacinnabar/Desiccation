using Desiccation.Projectiles.Flails;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Desiccation.Items.Flails
{
	public class BorealStarstriker : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 10;
			item.value = Item.sellPrice(0, 0, 5, 0);
			item.rare = 0; //White
			item.noMelee = true; // Makes sure that the animation when using the item doesn't hurt NPCs.
			item.useStyle = 5; // Set the correct useStyle.
			item.useAnimation = 40; // Determines how long the animation lasts.
			item.useTime = 40; // Determines how fast you can use this weapon (a lower value results in a faster use time).
			item.knockBack = 4F;
			item.damage = 9;
			item.scale = 2F;
			item.noUseGraphic = true; // Do not use the item graphic when using the item (we just want the ball to spawn).
			item.shoot = ProjectileType<BorealStarstrikerProjectile>();
			item.shootSpeed = 15.1F;
			item.UseSound = SoundID.Item1;
			item.melee = true; // Deals melee damage.
			item.crit = 9;
			item.channel = true; // We can keep the left mouse button down when trying to keep using this weapon.
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Chain, 1);
			recipe.AddIngredient(ItemID.BorealWood, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}