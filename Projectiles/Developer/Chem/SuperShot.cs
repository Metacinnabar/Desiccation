using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.Projectiles.Developer.Chem
{
    class SuperShot : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Super Shot");
        }
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate += 1;
            projectile.extraUpdates += 1;
        }
        public override void AI()
        { //Thanks, Fargo
            Vector2 offset = new Vector2();
            double angle = Main.rand.NextDouble() * 2d * Math.PI;
            offset.X += (float)(Math.Sin(angle) * 7);
            offset.Y += (float)(Math.Cos(angle) * 7);
            Dust dust = Main.dust[Dust.NewDust(
                projectile.Center + offset - new Vector2(4, 4), 0, 0,
                DustID.Electric, 0, 0, 100, Color.White, 0.5f
                )];
            dust.velocity *= 0.75f;
            dust.noGravity = true;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White; //Makes the projectile unaffected by light
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            target.AddBuff(BuffID.Frostburn, 30);
            target.AddBuff(BuffID.ShadowFlame, 30);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 5; //This projectile would occasionally appear to pierce through 2 extra enemies otherwise
        }
        public override void ModifyHitPvp(Player target, ref int damage, ref bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 30); //Only Frostburn because Shadowflame has no effect on players (you can make it deal damage to players though, let me know if you do)
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 20; i++)
            {
                Dust dust = Main.dust[Dust.NewDust(projectile.Center, 0, 0, DustID.Electric, 0, 0, 0, Color.White, 0.5f)];
                dust.noGravity = true;
                dust.velocity *= 1.5f;
            }
        }
    }
}
