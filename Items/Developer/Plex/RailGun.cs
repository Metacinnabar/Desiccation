using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.Items.Developer.Plex
{
	public class RailGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Plex's Developer Gun");
		}

		public override void SetDefaults()
		{
			item.damage = 88;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 2;
			item.useAnimation = 300;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 1;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10;
			if (AmmoID.Bullet == ItemID.MoonlordBullet)
			{
				item.shootSpeed = 0.7f;
			}
			else
			{
				item.shootSpeed = 1f;
			}
			item.useAmmo = AmmoID.Bullet;
			item.reuseDelay = 180;
		}
	}
}