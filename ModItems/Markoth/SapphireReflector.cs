using Desiccation.ModProjectiles.Gems;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.ModItems.Markoth
{
	public class SapphireReflector : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shoot a laser beam that can eliminate anything...");
		}

		public override void SetDefaults()
		{
			item.damage = 13;
			item.noMelee = true;
			item.magic = true;
			item.channel = true;
			item.mana = 5;
			item.rare = 5;
			item.width = 28;
			item.height = 30;
			item.useTime = 20;
			item.UseSound = SoundID.Item13;
			item.useStyle = 5;
			item.shootSpeed = 14f;
			item.useAnimation = 20;
			item.shoot = ModContent.ProjectileType<SapphireReflectorBeam>();
			item.value = Item.sellPrice(silver: 3);
		}
	}
}