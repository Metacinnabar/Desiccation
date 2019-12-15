using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.Items.Miner
{
	public class Pan : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Found in the ruins of a cave.\nUse in water to have a chance to pan for ores.");
		}

		public override void SetDefaults()
		{
			item.useStyle = ItemHoldStyleID.HoldingOut;
			item.width = 40;
			item.height = 40;
			item.value = 40000; //4 gold
			item.rare = 9;
			item.autoReuse = false;
			item.useAnimation = 40;
			item.useTime = 40;
			item.useTurn = true;
		}

		public override bool UseItem(Player player)
		{
			if (player.whoAmI == Main.myPlayer)
			{
				if (player.wet)
				{
					int num522 = Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType();
					int num521 = 0;
					for (int num520 = Player.tileTargetX - 1; num520 <= Player.tileTargetX + 1; num520++)
					{
						for (int num515 = Player.tileTargetY - 1; num515 <= Player.tileTargetY + 1; num515++)
						{
							if (Main.tile[num520, num515].liquidType() == num522)
							{
								num521 += Main.tile[num520, num515].liquid;
							}
						}
					}
					if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid > 0 && (num521 > 100 || item.type == 3032))
					{
						int liquidType = Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType();

						Main.PlaySound(19, (int)item.position.X, (int)item.position.Y, 1, 1f, 0f);
						player.itemTime = PlayerHooks.TotalUseTime(item.useTime, player, item);
						int num519 = Main.tile[Player.tileTargetX, Player.tileTargetY].liquid;
						Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = 0;
						if (Main.rand.NextFloat() < .0450f)
						{ //4.5%
							Item.NewItem(player.getRect(), ItemID.CopperOre, 1);
						}
						if (Main.rand.NextFloat() < .0450f)
						{ //7%
							Item.NewItem(player.getRect(), ItemID.TinOre, 1);
						}
						if (Main.rand.NextFloat() < .0250f)
						{ //5%
							Item.NewItem(player.getRect(), ItemID.IronOre, 1);
						}
						if (Main.rand.NextFloat() < .0250f)
						{ //5%
							Item.NewItem(player.getRect(), ItemID.LeadOre, 1);
						}
						if (Main.rand.NextFloat() < .0200f)
						{ //4%
							Item.NewItem(player.getRect(), ItemID.SilverOre, 1);
						}
						if (Main.rand.NextFloat() < .0200f)
						{ //4%
							Item.NewItem(player.getRect(), ItemID.TungstenOre, 1);
						}
						if (Main.rand.NextFloat() < .0100f)
						{ //2%
							Item.NewItem(player.getRect(), ItemID.GoldOre, 1);
						}
						if (Main.rand.NextFloat() < .0100f)
						{ //2%
							Item.NewItem(player.getRect(), ItemID.PlatinumOre, 1);
						}
						if (Main.rand.NextFloat() < .0050f)
						{ //1%
							Item.NewItem(player.getRect(), ItemID.Obsidian, 1);
						}
						Main.tile[Player.tileTargetX, Player.tileTargetY].lava(false);
						Main.tile[Player.tileTargetX, Player.tileTargetY].honey(false);
						WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, false);
						if (Main.netMode == 1)
						{
							NetMessage.sendWater(Player.tileTargetX, Player.tileTargetY);
						}
						else
						{
							Liquid.AddWater(Player.tileTargetX, Player.tileTargetY);
						}
						for (int num518 = Player.tileTargetX - 1; num518 <= Player.tileTargetX + 1; num518++)
						{
							for (int num517 = Player.tileTargetY - 1; num517 <= Player.tileTargetY + 1; num517++)
							{
								if (num519 < 256 && Main.tile[num518, num517].liquidType() == num522)
								{
									int num516 = Main.tile[num518, num517].liquid;
									if (num516 + num519 > 255)
									{
										num516 = 255 - num519;
									}
									num519 += num516;
									Main.tile[num518, num517].liquid -= (byte)num516;
									Main.tile[num518, num517].liquidType(liquidType);
									if (Main.tile[num518, num517].liquid == 0)
									{
										Main.tile[num518, num517].lava(false);
										Main.tile[num518, num517].honey(false);
									}
									WorldGen.SquareTileFrame(num518, num517, false);
									if (Main.netMode == 1)
									{
										NetMessage.sendWater(num518, num517);
									}
									else
									{
										Liquid.AddWater(num518, num517);
									}
								}
							}
						}
					}

				}
			} //Thx Dark;Light and Direwolf
			return true;
		}
	}
}