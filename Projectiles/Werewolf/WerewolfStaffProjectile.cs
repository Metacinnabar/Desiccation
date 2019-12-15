using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.Projectiles.Werewolf
{
	public class WerewolfStaffProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moon");     //The English name of the projectile
		}

		public override void SetDefaults()
		{
			projectile.width = 8;               //The width of projectile hitbox
			projectile.height = 8;              //The height of projectile hitbox
			projectile.aiStyle = 0;             //The ai style of the projectile, please reference the source code of Terraria
			projectile.friendly = true;         //Can the projectile deal damage to enemies?
			projectile.ranged = true;           //Is the projectile shoot by a ranged weapon?
			projectile.penetrate = 5;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			projectile.timeLeft = 600;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			projectile.light = 0.5f;            //How much light emit around the projectile
			projectile.ignoreWater = false;          //Does the projectile's speed be influenced by water?
			projectile.tileCollide = true;          //Can the projectile collide with tiles?
			projectile.extraUpdates = 1;            //Set to above 0 if you want the projectile to update multiple time in a frame
			aiType = ProjectileID.Bullet;
		}

		public override void AI()
		{

			if (projectile.localAI[1] == 0f)
			{
				projectile.localAI[1] = 1f;
			}
			float[] var_2_24600_cp_0 = projectile.ai;
			int var_2_24600_cp_1 = 0;
			float num73 = var_2_24600_cp_0[var_2_24600_cp_1];
			var_2_24600_cp_0[var_2_24600_cp_1] = num73 + 1f;
			int num3;
			if (projectile.ai[0] % 30f == 0f && projectile.ai[0] < 180f && Main.netMode != 1)
			{
				int[] array4 = new int[5];
				Vector2[] array5 = new Vector2[5];
				int num844 = 0;
				float num845 = 2000f;
				for (int num846 = 0; num846 < 255; num846 = num3 + 1)
				{
					if (Main.player[num846].active && !Main.player[num846].dead)
					{
						Vector2 center9 = Main.player[num846].Center;
						float num847 = Vector2.Distance(center9, projectile.Center);
						if (num847 < num845 && Collision.CanHit(projectile.Center, 1, 1, center9, 1, 1))
						{
							array4[num844] = num846;
							array5[num844] = center9;
							num3 = num844 + 1;
							num844 = num3;
							if (num3 >= array5.Length)
							{
								break;
							}
						}
					}
					num3 = num846;
				}
				for (int i = 0; i < 200; i++)
				{
					//Enemy NPC variable being set
					NPC target = Main.npc[i];

					//Getting the shooting trajectory
					float shootToX = target.position.X + target.width * 0.5f - projectile.Center.X;
					float shootToY = target.position.Y - projectile.Center.Y;
					float distance = (float)System.Math.Sqrt(shootToX * shootToX + shootToY * shootToY);

					//If the distance between the projectile and the live target is active
					if (distance < 400f && !target.friendly && target.active)
					{
						if (projectile.ai[0] > 4f) //Assuming you are already incrementing this in AI outside of for loop
						{
							//Dividing the factor of 3f which is the desired velocity by distance
							distance = 1f / distance;

							//Multiplying the shoot trajectory with distance times a multiplier if you so choose to
							shootToY = shootToX *= distance * 5;
							shootToY *= distance * 5;

							//Shoot projectile and set ai back to 0
							Projectile.NewProjectile(projectile.position.X, projectile.position.Y, shootToX, shootToY, ModContent.ProjectileType<WerewolfStaffProjectile_Small>(), 31, projectile.knockBack, Main.myPlayer); // 296 is the explosion from the Inferno Fork
							projectile.ai[0] = 0f;
						}
					}
				}
				projectile.rotation = projectile.velocity.ToRotation();
				projectile.ai[0] += 1f;
			}
		}
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y); // Play a death sound
			Vector2 usePos = projectile.position; // Position to use for dusts
			Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2(); // rotation vector to use for dust velocity
			usePos += rotVector * 16f;

			// Declaring a constant in-line is fine as it will be optimized by the compiler
			// It is however recommended to define it outside method scope if used elsewhere as well
			// They are useful to make numbers that don't change more descriptive
			const int NUM_DUSTS = 20;

			for (int i = 0; i < NUM_DUSTS; i++)
			{
				// Create a new dust
				Dust dust = Dust.NewDustDirect(usePos, projectile.width, projectile.height, 81);
				dust.position = (dust.position + projectile.Center) / 2f;
				dust.velocity += rotVector * 2f;
				dust.velocity *= 0.5f;
				dust.noGravity = true;
				usePos -= rotVector * 8f;
			}
		}
	}
}