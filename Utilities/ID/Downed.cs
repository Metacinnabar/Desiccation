using Terraria;

namespace Desiccation.Utilities.ID
{
	public static class Downed
	{
		//Bosses
		public static bool KingSlime => NPC.downedSlimeKing;
		public static bool EyeOfCthulhu => NPC.downedBoss1;
		public static bool EaterOfWorlds => NPC.downedBoss2 && DUtils.Corruption;
		public static bool BrainOfCthulhu => NPC.downedBoss2 && DUtils.Crimson;
		public static bool QueenBee => NPC.downedQueenBee;
		public static bool Skeletron => NPC.downedBoss3;
		public static bool WallOfFlesh => Main.hardMode;
		public static bool Destroyer => NPC.downedMechBoss1;
		public static bool Twins => NPC.downedMechBoss2;
		public static bool SkeletronPrime => NPC.downedMechBoss3;
		public static bool Plantera => NPC.downedPlantBoss;
		public static bool Golem => NPC.downedGolemBoss;
		public static bool DukeFishron => NPC.downedFishron;
		public static bool LunaticCultist => NPC.downedAncientCultist;
		public static bool Moonlord => NPC.downedMoonlord;

		//Minibosses
		public static bool Clown => NPC.downedClown;
		public static bool SolarPillar => NPC.downedTowerSolar;
		public static bool VortexPillar => NPC.downedTowerVortex;
		public static bool NebulaPillar => NPC.downedTowerNebula;
		public static bool StardustPillar => NPC.downedTowerStardust;

		//Events
		public static bool GoblinArmy => NPC.downedGoblins;
		public static bool PirateInvasion => NPC.downedPirates;
		//public static bool PirateInvasion => ;
		public static bool FrostMoon => NPC.downedFrost;
		public static bool MartianMadness => NPC.downedMartians;

		//Event Bosses
		public static bool MourningWood => NPC.downedHalloweenTree;
		public static bool Pumpking => NPC.downedHalloweenKing;
		public static bool Everscream => NPC.downedChristmasTree;
		public static bool SantaNK1 => NPC.downedChristmasSantank;
		public static bool IceQueen => NPC.downedChristmasIceQueen;

		//Misc
		public static bool WorldEvilBoss => NPC.downedBoss2;
		public static bool AnyMechBoss => NPC.downedMechBossAny;
	}
}