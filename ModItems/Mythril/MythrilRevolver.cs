using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Desiccation.ModItems.Mythril
{
	public class MythrilRevolver : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("OOf.");
		}

		public override void SetDefaults() {
			item.damage = 42;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Bullet;
			item.crit = 5;
			}
		}
	}
		