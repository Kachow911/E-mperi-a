using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Drops
{
	public class FeatherDrop : GlobalNPC
	{
		 public override void NPCLoot(NPC npc)  
        {
            if (npc.type == NPCID.Vulture) {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("VultureFeather"), Main.rand.Next(1, 3)); 
            }


        }
	}
}