
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Desiccation.ModItems.Pumpkin
{
    public class PumpkinHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("OOF.");
        }

        public override void SetDefaults()
        {
            item.damage = 3;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 17;
            item.useAnimation = 17;
            item.hammer = 40;
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
            recipe.AddIngredient(1725, 35);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
         }


    }
}