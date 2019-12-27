using Desiccation.DUtils;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Desiccation.DUtils.PlayerData;

namespace Desiccation.Global
{
	public class DesiccationGlobalItem : GlobalItem
	{
		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			if (ModContent.GetInstance<DesiccationClientsideConfig>().ToolTooltipRework)
			{
				if (item.pick > 0)
				{
					TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "PickPower" && x.mod == "Terraria");
					if (tt != null)
					{
						tt.text = $"{item.pick.ToString()} pickaxe power";
					}
				}
				if (item.axe > 0)
				{
					TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "AxePower" && x.mod == "Terraria");
					if (tt != null)
					{
						tt.text = $"{item.axe.ToString()} axe power";
					}
				}
				if (item.hammer > 0)
				{
					TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "HammerPower" && x.mod == "Terraria");
					if (tt != null)
					{
						tt.text = $"{item.hammer.ToString()} hammer power";
					}
				}
			}

			if (ModContent.GetInstance<DesiccationClientsideConfig>().NoFavoriteTooltips)
			{
				tooltips.RemoveAll(delegate (TooltipLine tt)
				{
					if (tt.mod == "Terraria")
					{
						return tt.Name.StartsWith("Favorite");
					}
					return false;
				});
			}
		}

		public override bool CanPickup(Item item, Player player)
		{
			if (ModContent.GetInstance<DesiccationGlobalConfig>().ResourcePickup)
			{
				switch (item.type)
				{
					case ItemID.Heart:
						if (MyHealth == MyMaxHealth)
						{
							return false;
						}
						break;

					case ItemID.CandyApple:
						if (MyHealth == MyMaxHealth)
						{
							return false;
						}
						break;

					case ItemID.CandyCane:
						if (MyHealth == MyMaxHealth)
						{
							return false;
						}
						break;

					case ItemID.Star:
						if (MyMana == MyMaxMana)
						{
							return false;
						}
						break;

					case ItemID.SugarPlum:
						if (MyMana == MyMaxMana)
						{
							return false;
						}
						break;
				}
				if (Mods.Thorium != null)
				{
					if (item.type == Mods.Thorium.ItemType("MusicReplenish") || item.type == Mods.Thorium.ItemType("MusicReplenish3") || item.type == Mods.Thorium.ItemType("MusicReplenish4") || item.type == Mods.Thorium.ItemType("MusicReplenishNoble"))
					{
						if (MyMusic == MyMaxMusic)
						{
							return false;
						}
					}
				}
			}
			return base.CanPickup(item, player);
		}
	}
}