using Desiccation.ModProjectiles.JellyFish;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Desiccation.ModItems.JellyFish
{
	public class JellyFishSpear : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Non consumable throwing javelin.");
		}

		public override void SetDefaults()
		{
			item.value = Item.sellPrice(gold: 2);
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.autoReuse = false;
			item.useTime = item.useAnimation = 18;
			item.rare = ItemRarityID.Pink;
			item.width = item.height = 86;
			item.UseSound = SoundID.Item19;
			item.damage = 32;
			item.knockBack = 2;
			item.shoot = ModContent.ProjectileType<JellyFishProjectile>();
			item.shootSpeed = 9;
			item.thrown = true;
			item.noUseGraphic = true;
			//will add particals later
		}

	}
}