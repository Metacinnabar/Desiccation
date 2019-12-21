using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Desiccation.DUtils.PlayerData;
using static Terraria.ModLoader.ModContent;

namespace Desiccation.Projectiles.Markoth
{
	public class SmallRockProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Small Rock");
		}

		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.tileCollide = true;
			projectile.alpha = 0;
		}

		public override void Kill(int timeLeft)
		{
			//Dust
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			//Sound
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
			if (NPC.downedBoss1 && MyPlayer.ZoneRockLayerHeight && !NPC.AnyNPCs(NPCType<NPCs.Markoth.Markoth>()))
			{
				Player player = new Player();
				//Boss Sound
				Main.PlaySound(SoundID.Roar, player.position, 0);
				//Boss Spawn
				NPC.SpawnOnPlayer(player.whoAmI, NPCType<NPCs.Markoth.Markoth>());
			}
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			//Penetrate
			projectile.penetrate--;
			//Kill
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
			else
			{
				//Dust
				Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
				//Sound
				Main.PlaySound(SoundID.Item1, projectile.position);
			}
			return false;
		}

		public int TargetWhoAmI
		{
			get => (int)projectile.ai[1];
			set => projectile.ai[1] = value;
		}

		public override void AI()
		{
			//Velocity
			TargetWhoAmI++;
			if (TargetWhoAmI >= 0)
			{
				const float velXmult = 0.98f;
				const float velYmult = 0.35f;
				TargetWhoAmI = 0;
				projectile.velocity.X *= velXmult;
				projectile.velocity.Y += velYmult;
			}
			//Rotation
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
		}
	}
}
