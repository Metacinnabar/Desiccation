using Terraria.ModLoader;

namespace Desiccation.DUtils
{
	/// <summary>
	/// This partial class contains information getters related to differant mods on the mod browser.
	/// </summary>
	internal static class Mods
	{
		/// <summary>
		/// Gets Thorium's instance.
		/// </summary>
		public static Mod Thorium
			=> ModLoader.GetMod("ThoriumMod");

		/// <summary>
		/// Gets Census's instance.
		/// </summary>
		public static Mod Census
			=> ModLoader.GetMod("Census");

		/// <summary>
		/// Gets Terraria Overhaul's instance.
		/// </summary>
		public static Mod Overhaul
			=> ModLoader.GetMod("OverhaulMod");
	}
}