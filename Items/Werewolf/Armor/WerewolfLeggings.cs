using Terraria.ModLoader;

namespace Desiccation.Items.Werewolf.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class WerewolfLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Werewolf Legs");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 16;
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