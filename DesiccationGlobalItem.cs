using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Desiccation.DUtils.Mods;
using static Desiccation.DUtils.PlayerData;

namespace Desiccation.Items
{
	public class DesiccationGlobalItem : GlobalItem
	{
		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			if (item.sentry)
			{
				TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
				if (tt != null)
				{
					string[] splitText = tt.text.Split(' ');
					string damageValue = splitText.First();
					string damageWord = splitText.Last();
					tt.text = damageValue + " sentry " + damageWord;
				}
			}
			if (item.pick > 0 || item.axe > 0 || item.hammer > 0)
			{
				TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
				if (tt != null)
				{
					string[] splitText = tt.text.Split(' ');
					string damageValue = splitText.First();
					string damageWord = splitText.Last();
					tt.text = damageValue + " tool " + damageWord;
				}
			}
			if (item.pick > 0)
			{
				TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "PickPower" && x.mod == "Terraria");
				if (tt != null)
				{
					string pickValue = item.pick.ToString();
					string pickWord = "pickaxe";
					tt.text = pickValue + " " + pickWord;
				}
			}
			if (item.axe > 0)
			{
				TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "AxePower" && x.mod == "Terraria");
				if (tt != null)
				{
					string axeValue = item.axe.ToString();
					string axeWord = "axe";
					tt.text = axeValue + " " + axeWord;
				}
			}
			if (item.hammer > 0)
			{
				TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "HammerPower" && x.mod == "Terraria");
				if (tt != null)
				{
					string hammerValue = item.hammer.ToString();
					string hammerWord = "hammer";
					tt.text = hammerValue + " " + hammerWord;
				}
			}
		}

		public override bool CanPickup(Item item, Player player)
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
			}
			if (Thorium != null)
			{
				ModPlayer thoriumPlayer = Thorium.GetPlayer("ThoriumPlayer");
				FieldInfo bardResourceField = thoriumPlayer.GetType().GetField("bardResource", BindingFlags.Public | BindingFlags.Instance);
				FieldInfo bardResourceMax2Field = thoriumPlayer.GetType().GetField("bardResourceMax", BindingFlags.Public | BindingFlags.Instance);
				int bardResource = (int)bardResourceField.GetValue(thoriumPlayer);
				int bardResourceMax = (int)bardResourceMax2Field.GetValue(thoriumPlayer);
				if (item.type == Thorium.ItemType("MusicReplenish") || item.type == Thorium.ItemType("MusicReplenish3") || item.type == Thorium.ItemType("MusicReplenish4") || item.type == Thorium.ItemType("MusicReplenishNoble"))
				{
					if (bardResource == bardResourceMax)
					{
						return false;
					}
				}
			}
			return base.CanPickup(item, player);
		}
	}
}