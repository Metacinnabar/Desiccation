using Desiccation.ModProjectiles.Developer.Chem;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.ModItems.Developer.Chem
{
	public class HyperScope : ModItem
	{
		private bool TookLife;

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Rapidly fires energy shots in bursts of three\nOvercharges at critical health, firing slow but powerful orbs\nConsumes life when used while overcharged\n'Destroy them with lazers!'");
		}

		//TODO: Rework Hyper Scope to have a charge shot instead eventually
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
			{ //TODO: Rebalances, man this is hard to balance
				if (Main.rand.Next(3) == 0)
					Dust.NewDust(player.position, player.width, player.height, DustID.Electric, Scale: 0.75f);
				if (player.releaseUseItem)
					TookLife = false;
				if (player.lifeRegen > 0)
					player.lifeRegen = 0;
				player.lifeRegenTime = 0;
				item.damage = 200;
				item.useTime = 45;
				item.useAnimation = 45;
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

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (!TookLife && player.statLife <= player.statLifeMax2 / 5)
			{
				Main.PlaySound(SoundID.Item93.WithVolume(0.75f), player.position);
				for (int i = 0; i < 30; i++)
				{
					Dust dust = Main.dust[Dust.NewDust(player.position, player.width, player.height, DustID.Electric, Scale: 1.25f)];
					dust.velocity *= 1.5f;
				}
				player.statLife -= 10;
				CombatText.NewText(player.getRect(), CombatText.DamagedFriendly, 10);
				if (player.statLife <= 0)
					player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " couldn't contain the watts."), player.statLife, 0);
				TookLife = true;
			}
			if (player.statLife <= 0)
			{
				return false;
			}
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
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