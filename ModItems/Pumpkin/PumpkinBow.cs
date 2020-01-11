using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Desiccation.ModItems.Pumpkin
{
    public class PumpkinBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("With a right click it shoots a exploding pumpkin arrow that takes a bit to charge.");
        }

        public override void SetDefaults()
        {
            item.damage = 11;
            item.ranged = true;
            item.width = 18;
            item.height = 32;
            item.useAnimation = 24;
            item.useTime = 24;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.rare = 2;
            item.UseSound = SoundID.Item5;
            item.autoReuse = false;
            item.shoot = 1;
            item.shootSpeed = 7f;
            item.value = Item.sellPrice(0, 0, 15, 0);
            item.useAmmo = AmmoID.Arrow;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(1725, 35);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        
    }
}