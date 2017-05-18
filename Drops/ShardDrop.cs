using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Drops
{
	public class ShardDrop : GlobalNPC
	{
		 public override void NPCLoot(NPC npc)  
        {
			Player player = Main.LocalPlayer;
			 if(player.ZoneSnow)
                {
                   if (Main.rand.Next(4) == 0) {
                      Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IceShard"), 1); 
				   }
				}


        }
	}
}