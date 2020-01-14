using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Desiccation.ModItems.Titanium
{
	public class TitaniumRifle : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("eef.");
		}

		public override void SetDefaults()
		{
			item.damage = 41;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; 
			item.shootSpeed = 13f;
			item.useAmmo = AmmoID.Bullet;
		}
	}
}
