using Desiccation.Projectiles.OOA.Ogre;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.Items.DD2.Ogre
{
	public class EtherianJavelin : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Non consumable throwing javelin.");
		}

		public override void SetDefaults()
		{
			item.value = Item.sellPrice(gold: 1);
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.autoReuse = false;
			item.useTime = item.useAnimation = 25;
			item.rare = ItemRarityID.Pink;
			item.width = item.height = 32;
			item.UseSound = SoundID.DD2_GoblinBomberThrow;
			item.damage = 32;
			item.knockBack = 2;
			item.shoot = ModContent.ProjectileType<EtherianJavelinProjectile>();
			item.shootSpeed = 12;
			item.thrown = true;
<<<<<<< HEAD:Items/OOA/Ogre/EtherianJavelin.cs
        }


            public override bool UseItem(Player player)
            {
            return base.UseItem(player);
            }


       
=======
>>>>>>> fc89202a0de5e46a19ce7eabd97a4118db58945d:Items/DD2/Ogre/EtherianJavelin.cs
		}
	}
