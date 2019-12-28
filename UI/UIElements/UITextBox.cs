using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ReLogic.Graphics;
using System;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace Desiccation.UI.UIElements
{
	internal class UITextBox : UIPanel //UITextPanel<string>
	{
		internal bool focused = false;

		//private int _cursor;
		//private int _frameCount;
		private int _maxLength = 60;

		private readonly string hintText;
		internal string currentString = "";
		private int textBlinkerCount;
		private int textBlinkerState;

		public event Action OnFocus;

		public event Action OnUnfocus;

		public event Action OnTextChanged;

		public event Action OnTabPressed;

		public event Action OnEnterPressed;

		//public event Action OnUpPressed;
		internal bool unfocusOnEnter = true;

		internal bool unfocusOnTab = true;

		//public NewUITextBox(string text, float textScale = 1, bool large = false) : base("", textScale, large)
		public UITextBox(string hintText, string text = "")
		{
			this.hintText = hintText;
			currentString = text;
			SetPadding(0);
			BackgroundColor = Color.White;
			BorderColor = Color.White;
		}

		public override void Click(UIMouseEvent evt)
		{
			Focus();
			base.Click(evt);
		}

		public override void RightClick(UIMouseEvent evt)
		{
			base.RightClick(evt);
			SetText("");
		}

		public void SetUnfocusKeys(bool unfocusOnEnter, bool unfocusOnTab)
		{
			this.unfocusOnEnter = unfocusOnEnter;
			this.unfocusOnTab = unfocusOnTab;
		}

		public void Unfocus()
		{
			if (focused)
			{
				focused = false;
				Main.blockInput = false;

				OnUnfocus?.Invoke();
			}
		}

		public void Focus()
		{
			if (!focused)
			{
				Main.clrInput();
				focused = true;
				Main.blockInput = true;

				OnFocus?.Invoke();
			}
		}

		public override void Update(GameTime gameTime)
		{
			Vector2 MousePosition = new Vector2(Main.mouseX, Main.mouseY);
			if (!ContainsPoint(MousePosition) && (Main.mouseLeft || Main.mouseRight)) // This solution is fine, but we need a way to cleanly "unload" a UIElement
			{
				// TODO, figure out how to refocus without triggering unfocus while clicking enable button.
				Unfocus();
			}
			base.Update(gameTime);
		}

		public void SetText(string text)
		{
			if (text.ToString().Length > _maxLength)
			{
				text = text.ToString().Substring(0, _maxLength);
			}
			if (currentString != text)
			{
				currentString = text;
				OnTextChanged?.Invoke();
			}
		}

		public void SetTextMaxLength(int maxLength)
		{
			_maxLength = maxLength;
		}

		private static bool JustPressed(Keys key)
		{
			return Main.inputText.IsKeyDown(key) && !Main.oldInputText.IsKeyDown(key);
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			Rectangle hitbox = GetInnerDimensions().ToRectangle();

			// Draw panel
			base.DrawSelf(spriteBatch);
			//	Main.spriteBatch.Draw(Main.magicPixel, hitbox, Color.Yellow);

			if (focused)
			{
				Terraria.GameInput.PlayerInput.WritingText = true;
				Main.instance.HandleIME();
				string newString = Main.GetInputText(currentString);
				if (!newString.Equals(currentString))
				{
					currentString = newString;
					OnTextChanged?.Invoke();
				}
				else
				{
					currentString = newString;
				}

				if (JustPressed(Keys.Tab))
				{
					if (unfocusOnTab) Unfocus();
					OnTabPressed?.Invoke();
				}
				if (JustPressed(Keys.Enter))
				{
					Main.drawingPlayerChat = false;
					if (unfocusOnEnter) Unfocus();
					OnEnterPressed?.Invoke();
				}
				if (++textBlinkerCount >= 20)
				{
					textBlinkerState = (textBlinkerState + 1) % 2;
					textBlinkerCount = 0;
				}
				Main.instance.DrawWindowsIMEPanel(new Vector2(98f, Main.screenHeight - 36), 0f);
			}
			string displayString = currentString;
			if (textBlinkerState == 1 && focused)
			{
				displayString = displayString + "|";
			}
			CalculatedStyle space = base.GetDimensions();
			Color color = Color.Black;
			if (currentString.Length == 0)
			{
			}
			Vector2 drawPos = space.Position() + new Vector2(4, 2);
			if (currentString.Length == 0 && !focused)
			{
				color *= 0.5f;
				//Utils.DrawBorderString(spriteBatch, hintText, new Vector2(space.X, space.Y), Color.Gray, 1f);
				spriteBatch.DrawString(Main.fontMouseText, hintText, drawPos, color);
			}
			else
			{
				//Utils.DrawBorderString(spriteBatch, displayString, drawPos, Color.White, 1f);
				spriteBatch.DrawString(Main.fontMouseText, displayString, drawPos, color);
			}
		}
	}
}