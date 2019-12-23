using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace Desiccation.Projectiles.AngryNimbus
{
    public class WaterBoltProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elemental Ball");
        }

        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.alpha = 255;
            projectile.timeLeft = 180;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.aiStyle = 14;
        }

        private bool rotChanged = false;
        public override void AI()
        {
            
            {             
                Vector2 offset = new Vector2();
                Dust dust = Main.dust[Dust.NewDust(projectile.Center + offset - new Vector2(2, 2), 0, 0, 68, 0, 0, 100, Color.Blue, 1.0f)];
            }
        }
    }
}
			