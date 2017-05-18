using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Emperia.Tiles
{
	public class MagnificentMushroom : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			TileObjectData.addTile(Type);
			Main.tileCut[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
			drop = mod.ItemType("MagnificentMushroom");
			Main.tileSolid[Type] = false;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = false;
			TileObjectData.addTile(Type);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				14,
				20
			}; 
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
		
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Main.PlaySound(2, i * 16, j * 16, 27);
		} 
		
	}
}