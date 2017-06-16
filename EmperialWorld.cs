using System.IO;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Emperia.WorldStuff;

namespace Emperia
{
    public class EmperialWorld : ModWorld
    {
	//6
	//13
	/*
	This code is full of cancer because i went tile by tile for most of it, and so its bad.
	if you read it you may die
	That was a warning
	so dont sue me
	the formatting is bad too
	pls be careful
	*/
		public static bool downedMushor = false;
		public static int twilightTiles = 0;
		public override void Initialize()
		{
			downedMushor = false;

		}
		public override void NetSend(BinaryWriter writer)
		{
			BitsByte flags = new BitsByte();
			flags[0] = downedMushor;
			writer.Write(flags);
		}
		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			downedMushor = flags[0];
		}
		public override void ResetNearbyTileEffects()
		{
			MyPlayer modPlayer = Main.LocalPlayer.GetModPlayer<MyPlayer>(mod);
			twilightTiles = 0;
		}
		public override void TileCountsAvailable(int[] tileCounts)
		{
			twilightTiles = tileCounts[mod.TileType("TwilightGrass")];
		}
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Micro Biomes"));
			tasks.Insert(genIndex + 1, new PassLegacy("Twilight Forest", delegate (GenerationProgress progress)
			{
				int XTILE = WorldGen.genRand.Next(300, Main.maxTilesX - 1000);
                int yAxis = Main.maxTilesY / 9;
			    for (int xAxis = XTILE; xAxis < XTILE + 200; xAxis++)
			    {
				    int Slope2 = Math.Abs(Main.rand.Next(52,74) - Math.Abs((xAxis - XTILE) - Main.rand.Next(52,74))) / 3;
				    string SlopeText = Slope2.ToString();
				    for (int I = 0; I < Slope2; I++)
				    {
					    WorldGen.TileRunner(xAxis, yAxis + I, (double)20, 1, mod.TileType("TwilightGrass"), true, 0f, 0f, true, true);
				    }
				    WorldGen.TileRunner(xAxis, yAxis, (double)20, 1, mod.TileType("TwilightGrass"), true, 0f, 0f, true, true);
				    if (Main.rand.Next(30) == 0)
				    {
					    WorldGen.TileRunner(xAxis, yAxis - 5, (double)20, 1, mod.TileType("TwilightGrass"), true, 0f, 0f, true, true);
				    }
			    }
			}));
		}

        public override void PostWorldGen()
        {   //mostly copied from examplemod
            for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];
                if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 2 * 36) //2 * 36 == locked dungeon chest
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == 0)
                        {   //first empty inventory slot
                            if (Main.rand.Next(4) == 0)
                                chest.item[inventoryIndex].SetDefaults(mod.ItemType<Items.RottenMushroom>());
                            break;
                        }
                    }
                }
            }
        }
    }

}	