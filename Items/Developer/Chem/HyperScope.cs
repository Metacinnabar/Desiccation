using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.Items.Developer.Chem
{
	public class HyperScope : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Rapidly fires energy shots in bursts of three\nWhen low on health, fires slow but powerful orbs\n'Destroy them with lazers!'");
		}

        public override void SetDefaults()
        {
            item.magic = true;
            item.width = 88;
            item.height = 34;
            item.damage = 35;
            item.useTime = 5;
            item.useAnimation = 15;
            item.mana = 14;
            item.UseSound = SoundID.Item91;
            item.shoot = mod.ProjectileType("SuperShot");
            item.shootSpeed = 20f;
            item.useStyle = 5;
            item.knockBack = 3;
            item.value = 1000000;
            item.rare = 5;
            item.autoReuse = true;
        }

        public override void HoldItem(Player player)
        {
            if (player.statLife <= player.statLifeMax2 / 5) //statLifeMax2 is used instead of statLifeMax since the latter is only the base max life value
            {
                item.damage = 175;
                item.useTime = 30;
                item.useAnimation = 30;
                item.mana = 60;
                item.shoot = mod.ProjectileType("HyperShot");
                item.shootSpeed = 15f;
            }
            else
            {
                item.damage = 35;
                item.useTime = 5;
                item.useAnimation = 15;
                item.mana = 14;
                item.shoot = mod.ProjectileType("SuperShot");
                item.shootSpeed = 20f;
            }
        }

        public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LaserRifle);
            recipe.AddIngredient(ItemID.SoulofSight, 20);
            recipe.AddIngredient(ItemID.IllegalGunParts);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}