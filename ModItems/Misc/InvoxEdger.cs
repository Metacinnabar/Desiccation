using Desiccation.ModProjectiles.Misc;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Desiccation.ModItems.Misc
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
			ModRecipe r = new ModRecipe(mod);
			r.AddIngredient(ItemID.CobaltDrill);
			r.AddIngredient(ItemID.MythrilDrill);
			r.AddIngredient(ItemID.AdamantiteDrill);
			r.AddIngredient(ItemID.ChlorophyteDrill);
			r.AddIngredient(ItemID.Drax);
			r.AddIngredient(ItemID.LaserDrill);
			r.AddTile(TileID.LunarCraftingStation);
			r.SetResult(this);
			r.AddRecipe();
		}
	}
}