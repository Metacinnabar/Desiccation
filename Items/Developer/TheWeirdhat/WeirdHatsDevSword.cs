using Desiccation.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Desiccation.Items.Developer.TheWeirdhat
{
	public class WeirdHatsDevSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Weird Sword");
			Tooltip.SetDefault("Great for impersonating devs!\nThis sword has been blessed by weird magic that makes it swing unusually fast.");
		}
		public override void SetDefaults()
		{
			item.maxStack = 1;
			item.useTurn = true;
			item.damage = 1125;
			item.melee = true;
			item.width = 40;
			item.height = 70;
			item.useTime = 0;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.knockBack = 1;
			item.value = Item.sellPrice(1, 1, 1, 1);
			item.rare = -14;
			item.expert = true;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.crit = -4;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(2))
			{
				//Emit dusts when swing the sword
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustType<BlueDust>());
			}
		}
	}
}
