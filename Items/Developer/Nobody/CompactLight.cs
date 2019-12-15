using Desiccation.Projectiles.Developer.Nobody;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.Items.Developer.Nobody
{
	public class CompactLight : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("The gun that fires a bullet that fires more bullets...");
		}

		public override void SetDefaults()
		{
			item.damage = 50;
			item.ranged = true;
			item.noMelee = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 10f;
			item.shoot = ModContent.ProjectileType<NobodysBulletProjectile>();
			item.useAmmo = AmmoID.Bullet;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.GrenadeI, 1, 13, player.whoAmI);
			if (type == ProjectileID.Bullet)
			{
				type = ProjectileID.BulletHighVelocity;
			}
			return true;
		}
	}
}
