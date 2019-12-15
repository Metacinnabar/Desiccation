/*using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using static Desiccation.DUtils.PlayerData;

namespace Desiccation.UI
{
    internal enum ResourceBarMode
    {
        Health
    }

    internal class ResourceBar : UIElement
    {
        private readonly ResourceBarMode _resourceBarMode;
        private readonly float _width;
        private readonly float _height;

        public ResourceBar(ResourceBarMode resourceBarMode, int height, int width)
        {
            _resourceBarMode = resourceBarMode;
            _width = width;
            _height = height;
        }

        private UIText lifeText;
        private UIText notifyText;
        private Rectangle _barDestination;
        private Vector2 _drawPosition;
        private Color lightGradient;
        private Color darkGradient;
        public Texture2D resourceBarTexture;

        public override void OnInitialize()
        {
            Height.Set(_height, 0f); //Set Height of element
            Width.Set(_width, 0f);   //Set Width of element

            notifyText = new UIText("You can drag me!", 1.4f);
            notifyText.Width.Set(_width, 0f);
            notifyText.Height.Set(_height, 0f);
            notifyText.Top.Set(_height / 2 + 40, 0f); //center the UIText
            notifyText.Left.Set(_width - 80f, 0f);
            Append(notifyText);

            lifeText = new UIText("0/0"); //text to show stat
            lifeText.Width.Set(_width, 0f);
            lifeText.Height.Set(_height, 0f);
            lifeText.Top.Set(_height / 2 + 10, 0f); //center the UIText
            lifeText.Left.Set(_width - 100f, 0f);
            Append(lifeText);

            _barDestination = new Rectangle(20, 0, (int)_width, (int)_height);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            notifyText.TextColor = Color.White;

            float quotient = 1f;
            //Calculate quotient
            switch (_resourceBarMode)
            {
                case ResourceBarMode.Health:
                    quotient = MyHealth / (float)MyMaxHealth;
                    break;

                default:
                    break;
            }
            Rectangle hitbox = GetInnerDimensions().ToRectangle();
            hitbox.Width = _barDestination.Width;
            hitbox.Height = _barDestination.Height;
            int left = hitbox.Left + 20;
            int right = hitbox.Right - 10;
            int steps = (int)((right - left) * quotient);
            switch (_resourceBarMode)
            {
                case ResourceBarMode.Health:
                    resourceBarTexture = Desiccation.healthBar;
                    break;

                default:
                    resourceBarTexture = null;
                    break;
            }
            for (int i = 0; i < steps; i += 1)
            {
                //float percent = (float)i / steps; // Alternate Gradient Approach
                float percent = (float)i / (right - left);
                spriteBatch.Draw(Main.magicPixel, new Rectangle(left + i, hitbox.Y, 1, hitbox.Height), Color.Lerp(lightGradient, darkGradient, percent));
            }
            _drawPosition = new Vector2(hitbox.X, hitbox.Y);
            spriteBatch.Draw(resourceBarTexture, _drawPosition, null, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            switch (_resourceBarMode)
            {
                case ResourceBarMode.Health:
                    lifeText.SetText("Life: " + MyHealth + "/" + MyMaxHealth);
                    if (HealthBar.firstDrag == true)
                    {
                        notifyText.SetText("");
                    }
                    lightGradient = new Color(221, 255, 28);
                    darkGradient = new Color(70, 150, 93);
                    break;

                default:
                    break;
            }

            base.Update(gameTime);
        }

    }
}*/