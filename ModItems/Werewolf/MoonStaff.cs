using Desiccation.ModProjectiles.Werewolf;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.ModItems.Werewolf
{
	public class MoonStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shoots crescent moons that shoot small moonbeams at nearby enemies.\r\nCannot go through walls.\r\nDropped from werewolves");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 62;
			item.noMelee = true;
			item.magic = true;
			item.mana = 10;
			item.rare = 5;
			item.width = 28;
			item.height = 30;
			item.useTime = 20;
			item.UseSound = SoundID.Item20;
			item.useStyle = 5;
			item.shootSpeed = 6f;
			item.useAnimation = 20;
			item.shoot = ModContent.ProjectileType<WerewolfStaffProjectile>();
			item.value = Item.sellPrice(silver: 3);
			item.channel = true;
		}
	}
}