using Desiccation.Items.Misc;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace Desiccation.Tiles.Decorations
{
	public class SeaHeartTile : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolidTop[Type] = false;
			Main.tileSolid[Type] = false;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = false;
			Main.tileLavaDeath[Type] = false;
			Main.tileBlockLight[Type] = false;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Heart of the Sea");
			AddMapEntry(new Color(102, 134, 186), name);
			disableSmartCursor = true;
			Main.tileLighted[Type] = true;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height)
		{
			offsetY = 4;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 32, ItemType<SeaHeart>());//, Main.rand.Next(3, 6));
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = .4f;
			g = 0.16f;
			b = 0.0f;
		}
	}
}