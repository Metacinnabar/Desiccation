using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.ModItems.Pumpkin
{
    public class PumpkinAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Mushy"); //bruh
        }

        public override void SetDefaults()
        {
            item.damage = 5;
            item.melee = true;
            item.width = 4;
            item.height = 40;
            item.useTime = 15;
			item.useAnimation = 10;
            item.axe = 40;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Pumpkin, 35);
			recipe.AddRecipeGroup("IronBar", 6);
			recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}