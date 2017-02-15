using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace Emperia
{
    public class GlobalNPC1 : GlobalNPC
    {
 
        public override void ResetEffects(NPC npc)
        {
            npc.GetModInfo<NPCsInfo>(mod).drowning = false;
        }
 
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (npc.GetModInfo<NPCsInfo>(mod).drowning)  //hitler wasn't that bad
            {
                npc.lifeRegen -= 25;      //im sorry
                if (damage < 2)
                {
                    damage = 2;  // that was insensitive
                }
            }
        }
    }
}