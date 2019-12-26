using System;
using System.Reflection;
using Terraria.ModLoader;
using Terraria.UI;

namespace Desiccation.DUtils
{
	internal static class UIData
	{
		public static void UIInfoMessage_Show(string text, int gotoMenu)
		{
			Type Interface = typeof(ModLoader).Assembly.GetType("Terraria.ModLoader.UI.Interface");
			Type UIInfoMessage = typeof(ModLoader).Assembly.GetType("Terraria.ModLoader.UI.UIInfoMessage");
			FieldInfo infoMessage = Interface.GetField("infoMessage", BindingFlags.Static | BindingFlags.NonPublic);
			UIElement infoMessageValue = (UIElement)infoMessage.GetValue(null);
			MethodInfo Show = UIInfoMessage.GetMethod("Show", BindingFlags.Instance | BindingFlags.NonPublic);

			if (Show != null)
			{
				Show.Invoke(infoMessageValue, new object[5]
				{
					text, gotoMenu, null, "", null
				});
			}
		}

		/*public static UIElement UIInputTextField(string text)
		{
			//Doesn't work

			Type UIInputTextFieldType = typeof(ModLoader).Assembly.GetType("Terraria.ModLoader.UI.UIInputTextField");
			return (UIElement)Activator.CreateInstance(UIInputTextFieldType, BindingFlags.NonPublic | BindingFlags.Public, null, new[] { text }, null);
		}*/
	}
}
