using Desiccation.Projectiles.Markoth;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Desiccation.Items.Markoth
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
			item.shoot = ProjectileType<SmallRockProjectile>();
		}

		public override bool CanUseItem(Player player)
		{
			return player.ZoneRockLayerHeight && NPC.downedBoss1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 50);
			recipe.AddIngredient(ItemID.Diamond, 4);
			recipe.AddIngredient(ItemID.Ruby, 4);
			recipe.AddIngredient(ItemID.Emerald, 4);
			recipe.AddIngredient(ItemID.Amethyst, 4);
			recipe.AddIngredient(ItemID.Sapphire, 4);
			recipe.AddIngredient(ItemID.Topaz, 4);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
		}
	}
}