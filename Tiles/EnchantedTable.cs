using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Emperia.Tiles
{
    public class EnchantedTable : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
            AddMapEntry(new Color(255, 35, 233), "Enchanter's Table");
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
            disableSmartCursor = true;
            TileObjectData.addTile(Type);
            
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("EnchantedTable"));
        }
    }
}