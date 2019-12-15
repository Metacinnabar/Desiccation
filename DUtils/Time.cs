using Terraria;

namespace Desiccation.DUtils
{
	/// <summary>
	/// This partial class contains integers on time values.
	/// </summary>
	internal static partial class Time
	{
		/// <summary>
		/// Occurs at the end of night.
		/// </summary>
		public static bool EndOfNight
			=> Night && Main.time == 32400;

		/// <summary>
		/// Occurs at the end of day.
		/// </summary>
		public static bool EndOfDay
			=> Day && Main.time == 54000;

		/// <summary>
		/// returns true if night time.
		/// </summary>
		public static bool Night
			=> !Main.dayTime;

		/// <summary>
		/// returns true if day time.
		/// </summary>
		public static bool Day
			=> Main.dayTime;
	}
}
