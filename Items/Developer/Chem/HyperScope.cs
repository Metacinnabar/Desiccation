using Desiccation.Projectiles.Developer.Chem;
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
			item.shoot = ModContent.ProjectileType<SuperShot>();
			item.shootSpeed = 20f;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 3;
			item.value = Item.sellPrice(gold: 20);
			item.rare = ItemRarityID.Pink;
			item.autoReuse = true;
		}

		public override void HoldItem(Player player)
		{
			if (player.statLife <= player.statLifeMax2 / 5)
			{
				item.damage = 175;
				item.useTime = 30;
				item.useAnimation = 30;
				item.mana = 60;
				item.shoot = ModContent.ProjectileType<HyperShot>();
				item.shootSpeed = 15f;
			}
			else
			{
				item.damage = 35;
				item.useTime = 5;
				item.useAnimation = 15;
				item.mana = 14;
				item.shoot = ModContent.ProjectileType<SuperShot>();
				item.shootSpeed = 20f;
			}
		}

		public override void AddRecipes()
		{
			ModRecipe r = new ModRecipe(mod);
			r.AddIngredient(ItemID.LaserRifle);
			r.AddIngredient(ItemID.SoulofSight, 20);
			r.AddIngredient(ItemID.IllegalGunParts);
			r.AddTile(TileID.MythrilAnvil);
			r.SetResult(this);
			r.AddRecipe();
		}
	}
}