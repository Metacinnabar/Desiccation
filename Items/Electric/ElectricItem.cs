using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;

namespace Desiccation.Items.Electric
{
	public abstract class ElectricItem : ModItem
	{
		public static bool electric = true;

		public override void SetDefaults()
		{
			item.melee = false;
			item.thrown = false;
			item.summon = false;
			item.ranged = false;
			item.magic = false;
		}
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
			if (tt != null)
			{
				string[] split = tt.text.Split(' ');
				tt.text = split.First() + " electric " + split.Last();
			}
		}
	}
}