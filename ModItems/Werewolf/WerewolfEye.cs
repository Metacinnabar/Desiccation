using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.ModItems.Werewolf
{
	public class WerewolfEye : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Improves vision during the night\nMore effective during a full moon\nDropped by werewolfs");
			DisplayName.SetDefault("Werewolf's Eye");
		}

		public override void SetDefaults()
		{
			item.width = 56;
			item.height = 30;
			item.accessory = true;
			item.value = 19000; //1 gold, 90 silver
			item.rare = ItemRarityID.LightRed;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			Vector2 position = player.RotatedRelativePoint(new Vector2(player.position.X, player.position.Y));
			if (!Main.dayTime)
			{
				if (Main.moonPhase == 1)
				{
					Lighting.AddLight(position, 1f, 1f, 10f);
				}
				else
				{
					Lighting.AddLight(position, 1f, 1f, 1f);
				}
			}
		}
	}
}