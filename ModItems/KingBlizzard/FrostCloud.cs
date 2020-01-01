using Desiccation.ModProjectiles.KingBlizzard;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.ModItems.KingBlizzard
{
	public class FrostCloud : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Creates a large cloud of frost that pierces infinite enemies and travels through walls.\nInflicts the Chilled debuff for 8 seconds.");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 20;
			item.mana = 20;
			item.sentry = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 45;
			item.useAnimation = 25;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item28;
			item.autoReuse = true;
			item.shootSpeed = 0f;
			item.shoot = ModContent.ProjectileType<FrostCloudProjectile>();
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
	}
}