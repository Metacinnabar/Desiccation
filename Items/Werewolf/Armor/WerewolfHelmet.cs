using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Desiccation.Items.Werewolf.Armor
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
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<WerewolfBreastplate>() && legs.type == ItemType<WerewolfLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Description";
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