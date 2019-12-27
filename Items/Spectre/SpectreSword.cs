using Desiccation.Projectiles.Spectre;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Desiccation.Items.Spectre
{
	public class SpectreSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Built by a lost soul in the depths of a dungeon.");
		}

		public override void SetDefaults()
		{
			item.maxStack = 1;
			item.useTurn = true;
			item.damage = 76;
			item.melee = true;
			item.width = 40;
			item.height = 70;
			item.useTime = 24;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 7;
			item.value = Item.sellPrice(0, 8, 0, 0);
			item.rare = 8; //Yellow
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ProjectileType<SpectreProjectile>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3261, 18); //Spectre Bar (18)
			recipe.AddTile(TileID.MythrilAnvil); //Both Hardmode Anvils
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}