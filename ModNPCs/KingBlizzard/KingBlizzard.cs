using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Desiccation.ModNPCs.KingBlizzard
{
	public class KingBlizzard : ModNPC
	{
		private Player player;
		private float speed;

		public override void SetDefaults()
		{
			npc.boss = true;
			npc.width = 18;
			npc.aiStyle = -1;
			npc.height = 40;
			npc.damage = 62;
			npc.defense = 18;
			npc.lifeMax = 42000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = 60f;
			npc.knockBackResist = 0.5f;
			npc.behindTiles = false;
			npc.noTileCollide = true;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}

		public override void AI()
		{
			Target(); // sets the player target

			DespawnHandler(); // Handles if the npc should despwan

			Move(new Vector2(0, -50)); // calls the move method
									   //Attacking
			npc.ai[1] -= 1f; // subtracts 1 from the AI
			if (npc.ai[1] <= 0f)
			{
				Shoot();
			}

			if (npc.localAI[0] == 0f)
			{
				Main.PlaySound(SoundID.Roar, npc.position, 0);
				npc.localAI[0] = 1f;
			}

			if (npc.timeLeft > 10)
			{
				npc.timeLeft = 10;
			}
		}

		private void Target()
		{
			player = Main.player[npc.target];
		}

		private void Move(Vector2 offset)
		{
			speed = 5f; // sets the max speed of an npc.
			Vector2 moveto = player.Center + offset; // gets the point that the npc will be moving to.
			Vector2 move = moveto - npc.Center;
			float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
			if (magnitude > speed)
			{
				move *= speed / magnitude;
			}
			float turnResistance = 5f; //it was 10 orginally
			move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
			magnitude = Magnitude(move);
			if (magnitude > speed)
			{
				move *= speed / magnitude;
			}
			npc.velocity = move;
		}

		private void DespawnHandler()
		{
			if (!player.active || player.dead)
			{
				npc.TargetClosest(false);
				player = Main.player[npc.target];
				if (!player.active || player.dead)
				{
					npc.velocity = new Vector2(0f, -10);
					if (npc.timeLeft > 10)
					{
						npc.timeLeft = 10;
					}
					return;
				}
			}
		}

		//Does nothing
		private void Shoot()
		{
			//int type = ModContent.ProjectileType<LaserProjectile>();
		}

		private float Magnitude(Vector2 move)
		{
			return (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
		}
	}
}