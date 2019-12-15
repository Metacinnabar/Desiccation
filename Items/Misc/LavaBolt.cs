using Desiccation.Projectiles.Misc;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.Items.Misc
{
	public class LavaBolt : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Burns targets with evil hellfires.");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 40;
			item.magic = true;
			item.mana = 15;
			item.width = 40;
			item.height = 40;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<LavaBoltProjectile>();
			item.shootSpeed = 16f;
		}

		public override void AddRecipes()
		{
			ModRecipe r = new ModRecipe(mod);
			r.AddIngredient(ItemID.SoulofNight, 5);
			r.AddIngredient(ItemID.HellstoneBar, 10);
			r.AddIngredient(ItemID.SpellTome, 1);
			r.AddTile(TileID.Bookcases);
			r.SetResult(this);
			r.AddRecipe();
		}
	}
}