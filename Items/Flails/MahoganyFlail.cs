using Desiccation.Projectiles.Flails;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Desiccation.Items.Flails
{
	public class MahoganyFlail : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 10;
			item.value = Item.sellPrice(0, 0, 5, 0);
			item.rare = ItemRarityID.White;
			item.noMelee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 40;
			item.useTime = 40;
			item.knockBack = 4f;
			item.damage = 9;
			item.noUseGraphic = true;
			item.shoot = ProjectileType<MahoganyFlailProjectile>();
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
			r.AddIngredient(ItemID.RichMahogany, 10);
			r.AddTile(TileID.WorkBenches);
			r.SetResult(this);
			r.AddRecipe();
		}
	}
}