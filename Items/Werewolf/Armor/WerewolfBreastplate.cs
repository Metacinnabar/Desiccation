using Terraria.ModLoader;

namespace Desiccation.Items.Werewolf.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class WerewolfBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Werewolf Body");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 18;
			item.defense = 21;
			item.value = 25000;
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