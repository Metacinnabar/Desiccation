using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.Items.Misc
{
	public class Boxinator : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Creates a basic and suitable house for your Town NPCs.\nYou need 35 walls in your inventory to work.\nUses up the closest wall in your inventory");
			DisplayName.SetDefault("Expert Boxinator");
		}

		public override void SetDefaults()
		{
			item.useStyle = 4;
			item.useTime = 2;
			item.useAnimation = 2;
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 300;
			item.rare = 1;
			item.consumable = true;
		}

		public override bool UseItem(Player player)
		{
			int wallBox = -1;
			bool foundWall = false;
			foreach (Item item in player.inventory)
			{
				if (!item.IsAir && item.createWall > -1)
				{
					if (item.stack < 35)
					{
						continue;
					}
					wallBox = item.createWall;
					item.stack -= 35;
					if (item.stack <= 0)
					{
						item.TurnToAir();
					}
					foundWall = true;
					break;
				}
			}
			if (!foundWall)
			{
				Main.NewText("You don't have enough walls in your inventory. Make sure you have atleast 35 wall items in your inventory before using this.");
				return false;
			}
			//Thanks Kazzymodus#2686, Spearmint#9132 & Putan#1022 helping on Discord!
			Vector2 standingOn = new Vector2((int)Math.Floor(player.position.X / 16f) - 1, (int)Math.Ceiling((player.position.Y + player.height) / 16f));
			for (int i = (int)standingOn.Y - 6; i < (int)standingOn.Y + 1; i++)
			{
				for (int j = (int)standingOn.X; j < (int)standingOn.X + 9; j++)
				{
					if (i == (int)standingOn.Y || j == (int)standingOn.X || (i == (int)standingOn.Y - 6 && !(j == (int)standingOn.X + 1 || j == (int)standingOn.X + 2)) || j == (int)standingOn.X + 8)
					{
						WorldGen.PlaceTile(j, i, 30);
					}
					else if (!(i == (int)standingOn.Y - 6 && (j == (int)standingOn.X + 1 || j == (int)standingOn.X + 2)))
					{
						WorldGen.PlaceWall(j, i, wallBox);
					}
				}
			}

			WorldGen.PlaceTile((int)standingOn.X + 1, (int)standingOn.Y - 6, 19);
			WorldGen.PlaceTile((int)standingOn.X + 2, (int)standingOn.Y - 6, 19);
			WorldGen.PlaceTile((int)standingOn.X + 7, (int)standingOn.Y - 5, 4);
			WorldGen.PlaceTile((int)standingOn.X + 7, (int)standingOn.Y - 1, 15);
			WorldGen.PlaceTile((int)standingOn.X + 5, (int)standingOn.Y - 1, 18);
			NetMessage.SendTileRange(-1, (int)standingOn.X, (int)standingOn.Y - 6, 9, 7, TileChangeType.None);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe r = new ModRecipe(mod);
			r.AddIngredient(ItemID.Wood, 42);
			r.AddIngredient(ItemID.Gel, 1);
			r.anyWood = true;
			r.SetResult(this, 1);
			r.AddRecipe();
		}
	}
}