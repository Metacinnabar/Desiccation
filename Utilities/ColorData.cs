using Microsoft.Xna.Framework;

namespace Desiccation.Utilities
{
	internal static class ColorData
	{
		/// <summary>
		/// Blends the two colors with the given bias towards "toColor". Made by direwolf420. Basiclly Color.Lerp
		/// </summary>
		/// <param name="fromColor">The original color.</param>
		/// <param name="toColor">The color being blended towards.</param>,
		/// <param name="fadePercent">The percent bias towards "toColor". Range[0, 1]</param>
		public static Color FadeBetween(Color fromColor, Color toColor, float fadePercent)
			=> fadePercent == 0f ? fromColor : new Color(fromColor.ToVector4() * (1f - fadePercent) + toColor.ToVector4() * fadePercent);
	}
}