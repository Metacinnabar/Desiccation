using Desiccation.ModProjectiles.Developer.Nobody;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Desiccation.ModItems.Developer.Nobody
{
	public class NobodysBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nobody's Bullet");
		}

		public override void SetDefaults()
		{
			item.damage = 30;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 1.5f;
			item.value = 10;
			item.rare = 2;
			item.shoot = ProjectileType<NobodysBulletProjectile>();
			item.shootSpeed = 16f;
			item.ammo = AmmoID.Bullet;
		}

		// Give each bullet consumed a 20% chance of granting the Wrath buff to the player for 5 seconds
		public override void OnConsumeAmmo(Player player)
		{
			if (Main.rand.NextBool(5))
			{
				player.AddBuff(BuffID.Wrath, 300);
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MusketBall, 50);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}