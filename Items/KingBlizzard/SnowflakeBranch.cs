using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.Items.KingBlizzard
{
	public class SnowflakeBranch : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Wait snowflakes have branches? Yes you fool.");
		}

		public override void SetDefaults()
		{
			item.damage = 47;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 25;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 11;
			item.value = Item.buyPrice(gold: 1);
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			if (DUtils.Misc.RandomInt(0, 2) == 0)
			{
				target.AddBuff(32, 900);
			}
			if (DUtils.Misc.RandomInt(0, 11) == 0)
			{
				target.AddBuff(47, 180);
			}
		}
	}
}