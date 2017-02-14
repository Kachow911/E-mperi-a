using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;

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
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
        int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Micro Biomes"));
		tasks.Insert(genIndex + 1, new PassLegacy("Clearing Space", delegate (GenerationProgress progress)
        {
			for (int j = 0; j < 49; j++) {
			for (int i = 0; i < 49; i++) {
					WorldGen.KillTile(Main.spawnTileX - j, Main.spawnTileY - i);
			}
			for (int i = 0; i < 49; i++) {
					WorldGen.KillTile(Main.spawnTileX + j, Main.spawnTileY - i);
			}
			}
			for (int i = 0; i < 14; i++) {
					WorldGen.KillTile(Main.spawnTileX - 6 + i, Main.spawnTileY);
					WorldGen.KillTile(Main.spawnTileX - 6 + i, Main.spawnTileY + 1);
			}
			for (int i = 0; i < 5; i++) {
					WorldGen.KillTile(Main.spawnTileX - 7, Main.spawnTileY - i - 1);
				    WorldGen.KillTile(Main.spawnTileX - 8, Main.spawnTileY - i - 1);
					WorldGen.KillTile(Main.spawnTileX + 8, Main.spawnTileY - i - 1);
				    WorldGen.KillTile(Main.spawnTileX + 9, Main.spawnTileY - i - 1);
				
			}
        }));
        tasks.Insert(genIndex + 2, new PassLegacy("Generating ruined dungeon", delegate (GenerationProgress progress)
        {
			for (int i = 0; i < 15; i++) {
					WorldGen.PlaceTile(Main.spawnTileX, Main.spawnTileY - 22 + i, TileID.GrayBrick);
					WorldGen.PlaceTile(Main.spawnTileX + 1, Main.spawnTileY - 22 + i, TileID.GrayBrick);
			}
					WorldGen.PlaceTile(Main.spawnTileX, Main.spawnTileY - 4, TileID.Platforms);
					WorldGen.PlaceTile(Main.spawnTileX + 1, Main.spawnTileY - 4, TileID.Platforms);
			for (int i = 0; i < 3; i++) {
					WorldGen.PlaceTile(Main.spawnTileX - 1 - i, Main.spawnTileY - 4, TileID.GrayBrick);
					WorldGen.PlaceTile(Main.spawnTileX + 2 + i, Main.spawnTileY - 4, TileID.GrayBrick);
				
			}
			for (int i = 0; i < 15; i++) {
					WorldGen.PlaceTile(Main.spawnTileX - 6 + i, Main.spawnTileY, TileID.GrayBrick);
					WorldGen.PlaceTile(Main.spawnTileX - 6 + i, Main.spawnTileY + 1, TileID.GrayBrick);
			}
			for (int i = 0; i < 5; i++) {
					WorldGen.PlaceTile(Main.spawnTileX - 7, Main.spawnTileY - i - 1, TileID.GrayBrick);
				    WorldGen.PlaceTile(Main.spawnTileX - 8, Main.spawnTileY - i - 1, TileID.GrayBrick);
					WorldGen.PlaceTile(Main.spawnTileX + 8, Main.spawnTileY - i - 1, TileID.GrayBrick);
				    WorldGen.PlaceTile(Main.spawnTileX + 9, Main.spawnTileY - i - 1, TileID.GrayBrick);
					
				
			}
			        WorldGen.PlaceTile(Main.spawnTileX - 4, Main.spawnTileY - 4, TileID.Platforms);
					WorldGen.PlaceTile(Main.spawnTileX + 5, Main.spawnTileY - 4, TileID.Platforms);
					WorldGen.PlaceChest(Main.spawnTileX, Main.spawnTileY - 23, (ushort)mod.TileType("RuinedChest"), false, 2);
			
        }));
		
        }
		
		
		
	}

}	