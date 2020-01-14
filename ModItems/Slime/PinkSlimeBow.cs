using Desiccation.ModProjectiles.Slime;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.ModItems.Slime
{
    class PinkSlimeBow : ModItem
    {
        public override void SetStaticDefaults()
        { //TODO: New pink sprite (Crim's already on it)
            Tooltip.SetDefault("Coats wooden arrows in bouncy gel\nFlaming arrow types and lava will set the gel ablaze\nWater will wash off the gel, converting it back to normal");
        }

        public override void SetDefaults()
        {
            item.damage = 16;
            item.ranged = true;
            item.width = 18;
            item.height = 36;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 0;
            item.value = 60;
            item.rare = 1;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = 1;
            item.shootSpeed = 5f;
            item.useAmmo = AmmoID.Arrow;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        { //ai1 chart: Standard (0, default) Flaming (1) Cursed (2) Frostburn (3)
            if (type == ProjectileID.WoodenArrowFriendly)
            {
                Projectile.NewProjectile(position, new Vector2(speedX, speedY), ModContent.ProjectileType<PinkSlimeArrow>(), item.damage, 0, player.whoAmI);
                return false;
            }
            else if (type == ProjectileID.FireArrow)
            {
                Projectile.NewProjectile(position, new Vector2(speedX, speedY), ModContent.ProjectileType<PinkSlimeArrow>(), item.damage, 0, player.whoAmI, ai1: 1);
                return false;
            }
            else if (type == ProjectileID.CursedArrow)
            {
                Projectile.NewProjectile(position, new Vector2(speedX, speedY), ModContent.ProjectileType<PinkSlimeArrow>(), item.damage, 0, player.whoAmI, ai1: 2);
                return false;
            }
            else if (type == ProjectileID.FrostburnArrow)
            {
                Projectile.NewProjectile(position, new Vector2(speedX, speedY), ModContent.ProjectileType<PinkSlimeArrow>(), item.damage, 0, player.whoAmI, ai1: 3);
                return false;
            }
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PinkGel, 20);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
