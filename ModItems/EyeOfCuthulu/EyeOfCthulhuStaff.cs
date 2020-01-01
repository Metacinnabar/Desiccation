using Desiccation.ModProjectiles.EyeOfCthulhu;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.ModItems.EyeOfCuthulu
{
	public class EyeOfCthulhuStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'It's very gaze has the power to kill'");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 20;
			item.summon = true;
			item.noMelee = true;
			item.mana = 12;
			item.width = 40;
			item.height = 40;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = Item.sellPrice(silver: 20);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item20;
			item.autoReuse = false;
			item.shoot = ModContent.ProjectileType<EyeOfCthulhuStaffProjectile>();
			item.shootSpeed = 16f;
		}

		public override void AddRecipes()
		{
			ModRecipe r = new ModRecipe(mod);
			r.AddIngredient(ItemID.CrimtaneBar, 15);
			r.AddTile(TileID.Anvils);
			r.SetResult(this);
			r.AddRecipe();
			r.AddRecipe(); r = new ModRecipe(mod);
			r.AddIngredient(ItemID.DemoniteBar, 15);
			r.AddTile(TileID.Anvils);
			r.SetResult(this);
			r.AddRecipe();
		}
	}
}