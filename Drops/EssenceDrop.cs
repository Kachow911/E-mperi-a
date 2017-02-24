using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Drops
{
	public class EssenceDrop : GlobalNPC
	{
		 public override void NPCLoot(NPC npc)  
        {
			//ZoneUnderworldHeight
			Player player = Main.LocalPlayer;
			 if(player.ZoneBeach)
                {
                   if (Main.rand.Next(4) == 0) {
                      Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OceanEssence"), 1); 
				   }
				}
				if(player.ZoneUnderworldHeight)
                {
                   if (Main.rand.Next(4) == 0) {
                      Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HellEssence"), 1); 
				   }
				}


        }
	}
}