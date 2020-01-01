using Desiccation.ModProjectiles.Markoth;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.ModItems.Markoth
{
	public class SmallRock : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Summons Markoth, The Fallen Magician\nThrow against solid material in the caverns.");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13; // This helps sort inventory know this is a boss summoning item.
		}

		public override void SetDefaults()
		{
			item.shootSpeed = 10f;
			item.useStyle = 1;
			item.useAnimation = 25;
			item.useTime = 25;
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.rare = ItemRarityID.White;
			item.consumable = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = false;
			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(gold: 2);
			item.shoot = ModContent.ProjectileType<SmallRockProjectile>();
		}

		public override bool CanUseItem(Player player)
		{
			return player.ZoneRockLayerHeight && NPC.downedBoss1;
		}

		public override void AddRecipes()
		{
			ModRecipe r = new ModRecipe(mod);
			r.AddIngredient(ItemID.StoneBlock, 50);
			r.AddIngredient(ItemID.Diamond, 4);
			r.AddIngredient(ItemID.Ruby, 4);
			r.AddIngredient(ItemID.Emerald, 4);
			r.AddIngredient(ItemID.Amethyst, 4);
			r.AddIngredient(ItemID.Sapphire, 4);
			r.AddIngredient(ItemID.Topaz, 4);
			r.AddTile(TileID.DemonAltar);
			r.SetResult(this);
			r.AddRecipe();
		}
	}
}