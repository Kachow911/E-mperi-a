using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Drops
{
	public class CoreDrop : GlobalNPC
	{
		 public override void NPCLoot(NPC npc)  
        {
			Player player = Main.LocalPlayer;
			 if(npc.type == NPCID.GraniteFlyer)
                {
                  
                      Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GraniteCore"), 1); 

				}


        }
	}
}