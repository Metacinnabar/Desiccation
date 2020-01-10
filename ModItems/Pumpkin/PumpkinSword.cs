using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace Desiccation.ModItems.Pumpkin
{
    public class PumpkinSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A sword that has a 1//30 chance to inflect the burn debuff on the enemy.");
        }

        public override void SetDefaults()
        {
            item.damage = 13;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 19;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 100;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(1725, 30);
            recipe.AddTile(18);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(30) == 0)
                target.AddBuff(BuffID.OnFire, 180);
        }
    }
}