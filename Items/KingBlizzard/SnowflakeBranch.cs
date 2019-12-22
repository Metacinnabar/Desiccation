using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.Items.KingBlizzard
{
	public class SnowflakeBranch : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Wait, snowflakes have branches? Yes you fool.");
		}

		public override void SetDefaults()
		{
			item.damage = 47;
			item.melee = true;
			item.Size = new Vector2(40);
			item.useTime = 25;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 11;
			item.value = Item.sellPrice(gold: 3);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			if (DUtils.Misc.RandomFrom1OutOf(2))
			{
				target.AddBuff(BuffID.Slow, 900);
			}
			if (DUtils.Misc.RandomFrom1OutOf(10))
			{
				target.AddBuff(BuffID.Frozen, 180);
			}
		}
	}
}