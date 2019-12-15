using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.Items.Developer.GoodPro712
{
	public class Dolphin : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Super Dolphin Meowmere Sword Cat-Head Machine Gun Bullet Pouch Mammal Fish");
			Tooltip.SetDefault("Great for impersonating devs!\nUses no ammo\nThe SDMG and Meowmere had a son.");
		}

		public override void SetDefaults()
		{
			item.useStyle = 1;
			item.autoReuse = true;
			item.useAnimation = 5;
			item.useTime = 5;
			item.crit += 10;
			item.width = 60;
			item.height = 26;
			item.shoot = 10;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item40;
			item.damage = 666666;
			item.shootSpeed = 12f;
			item.value = 750000;
			item.rare = -14;
			item.knockBack = 6.5f;
			item.ranged = true;
			item.expert = true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.Meowmere, damage, knockBack, player.whoAmI);
			Main.PlaySound(SoundID.Item1, item.position);
			return true;
		}

		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= 1f;
		}
	}
}