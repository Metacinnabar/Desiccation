using Desiccation.Projectiles.Flails;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.Items.Flails
{
	public class BorealStarstriker : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 10;
			item.value = Item.sellPrice(silver: 5);
			item.rare = ItemRarityID.White;
			item.noMelee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 40;
			item.useTime = 40;
			item.knockBack = 4f;
			item.damage = 9;
			item.scale = 2f;
			item.noUseGraphic = true;
			item.shoot = ModContent.ProjectileType<BorealStarstrikerProjectile>();
			item.shootSpeed = 15.1f;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.crit = 9;
			item.channel = true;
		}

		public override void AddRecipes()
		{
			ModRecipe r = new ModRecipe(mod);
			r.AddIngredient(ItemID.Chain, 1);
			r.AddIngredient(ItemID.BorealWood, 10);
			r.AddTile(TileID.WorkBenches);
			r.SetResult(this);
			r.AddRecipe();
		}
	}
}