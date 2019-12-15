/*using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.UI;
using static Desiccation.DUtils.PlayerData;

namespace Desiccation.UI
{
    internal class HealthBar : UIState
    {
        public ResourceBar healthBar;
        public static bool visible = false;
        public static bool firstDrag;

        public override void OnInitialize()
        {
            firstDrag = false;
            healthBar = new ResourceBar(ResourceBarMode.Health, 130, 1);
            healthBar.Left.Set(Main.screenWidth / 2 + 92, 0f);
            healthBar.Top.Set(Main.screenHeight / 2 - 50 + 12f, 0f);
            healthBar.OnMouseDown += new MouseEvent(DragStart);
            healthBar.OnMouseUp += new MouseEvent(DragEnd);
            Append(healthBar);
        }

        private Vector2 _offset;
        public bool dragging = false;
        private void DragStart(UIMouseEvent evt, UIElement listeningElement)
        {
            firstDrag = true;
            _offset = new Vector2(evt.MousePosition.X - healthBar.Left.Pixels, evt.MousePosition.Y - healthBar.Top.Pixels);
            dragging = true;
        }

        private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            dragging = false;

            healthBar.Left.Set(end.X - _offset.X, 0f);
            healthBar.Top.Set(end.Y - _offset.Y, 0f);

            Recalculate();
        }
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Vector2 mousePosition = new Vector2(Main.mouseX, Main.mouseY);
            if (healthBar.ContainsPoint(mousePosition))
            {
                MyPlayer.mouseInterface = true;
            }
            if (dragging)
            {
                healthBar.Left.Set(mousePosition.X - _offset.X, 0f);
                healthBar.Top.Set(mousePosition.Y - _offset.Y, 0f);
                Recalculate();
            }
        }
    }
}*/