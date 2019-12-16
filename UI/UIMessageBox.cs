using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace Desiccation.UI
{
	internal class UIMessageBox : UIPanel
	{
		protected UIScrollbar Scrollbar;

		private string _text;

		private float _height;

		private bool _heightNeedsRecalculating;

		private readonly List<Tuple<string, float>> _drawTexts = new List<Tuple<string, float>>();

		public UIMessageBox(string text)
		{
			SetText(text);
		}

		public override void OnActivate()
		{
			base.OnActivate();
			_heightNeedsRecalculating = true;
		}

		internal void SetText(string text)
		{
			_text = text;
			ResetScrollbar();
		}

		private void ResetScrollbar()
		{
			if (Scrollbar != null)
			{
				Scrollbar.ViewPosition = 0f;
				_heightNeedsRecalculating = true;
			}
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			base.DrawSelf(spriteBatch);
			CalculatedStyle space = GetInnerDimensions();
			float position = 0f;
			if (Scrollbar != null)
			{
				position = 0f - Scrollbar.GetValue();
			}
			foreach (Tuple<string, float> drawText in _drawTexts)
			{
				if (position + drawText.Item2 > space.Height)
				{
					break;
				}
				if (position >= 0f)
				{
					Utils.DrawBorderString(spriteBatch, drawText.Item1, new Vector2(space.X, space.Y + position), Color.White, 1f, 0f, 0f, -1);
				}
				position += drawText.Item2;
			}
			Recalculate();
		}

		public override void RecalculateChildren()
		{
			base.RecalculateChildren();
			if (_heightNeedsRecalculating)
			{
				CalculatedStyle space = base.GetInnerDimensions();
				if (!(space.Width <= 0f) && !(space.Height <= 0f))
				{
					DynamicSpriteFont font = Main.fontMouseText;
					_drawTexts.Clear();
					float position = 0f;
					float textHeight = font.MeasureString("A").Y;
					string[] array = _text.Split('\n');
					for (int i = 0; i < array.Length; i++)
					{
						string drawString = array[i];
						do
						{
							string remainder = "";
							while (font.MeasureString(drawString).X > space.Width)
							{
								remainder = drawString[drawString.Length - 1].ToString() + remainder;
								drawString = drawString.Substring(0, drawString.Length - 1);
							}
							if (remainder.Length > 0)
							{
								int index = drawString.LastIndexOf(' ');
								if (index >= 0)
								{
									remainder = drawString.Substring(index + 1) + remainder;
									drawString = drawString.Substring(0, index);
								}
							}
							_drawTexts.Add(new Tuple<string, float>(drawString, textHeight));
							position += textHeight;
							drawString = remainder;
						}
						while (drawString.Length > 0);
					}
					_height = position;
					_heightNeedsRecalculating = false;
				}
			}
		}

		public override void Recalculate()
		{
			base.Recalculate();
			UpdateScrollbar();
		}

		public override void ScrollWheel(UIScrollWheelEvent evt)
		{
			base.ScrollWheel(evt);
			if (Scrollbar != null)
			{
				Scrollbar.ViewPosition -= evt.ScrollWheelValue;
			}
		}

		public void SetScrollbar(UIScrollbar scrollbar)
		{
			Scrollbar = scrollbar;
			UpdateScrollbar();
			_heightNeedsRecalculating = true;
		}

		private void UpdateScrollbar()
		{
			UIScrollbar scrollbar = Scrollbar;
			if (scrollbar != null)
			{
				scrollbar.SetView(GetInnerDimensions().Height, _height);
			}
		}
	}

	internal class CreditMenu : UIElement
	{
		internal void Credits()
		{
			string text = "Bruh";

			UIMessageBox message = new UIMessageBox(text)
			{
				Width =
				{
					Percent = 1f
				},
				Height =
				{
					Pixels = 400f,
					Percent = 0f
				}
			};
			message.SetScrollbar(new UIScrollbar());
		}
	}
}