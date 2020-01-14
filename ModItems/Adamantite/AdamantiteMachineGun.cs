using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Desiccation.ModItems.Adamantite
{
	public class AdamantiteMachineGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("eef.");
		}

		public override void SetDefaults()
		{
			item.damage = 45;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 15f;
			item.useAmmo = AmmoID.Bullet;
		}
	}
}
