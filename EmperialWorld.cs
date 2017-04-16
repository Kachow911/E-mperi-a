using System.IO;
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
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex == -1)
			{
				// Shinies pass removed by some other mod.
				return;
			}
        tasks.Insert(ShiniesIndex +  1, new PassLegacy("DynastyBiome", delegate(GenerationProgress progress)
            {
               
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