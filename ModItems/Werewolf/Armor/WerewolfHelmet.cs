using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Desiccation.ModItems.Werewolf.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class WerewolfHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Werewolf Mask");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 26;
			item.defense = 14;
			item.value = 20000;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<WerewolfBreastplate>() && legs.type == ItemType<WerewolfLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Same as moon charm but with +5% knockback and can be stacked with moon charm";
			player.statDefense += 2;
			player.meleeCrit += 2;
			player.allDamage += 0.05f;
			player.meleeSpeed += 0.05f;
			player.magicCrit += 2;
			player.rangedCrit += 2;
			player.thrownCrit += 2;
			player.minionKB += 0.5f;
			player.moveSpeed += 0.2f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			//recipe.AddIngredient(ItemType<WerewolfFur>(), ...);
			//recipe.AddTile(TileType<AnimalLoom>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}