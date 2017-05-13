using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia
{
    public class NPCsGLOBAL : GlobalNPC
    {

        public override void ResetEffects(NPC npc)
        {
            npc.GetModInfo<NPCsINFO1>(mod).customdebuff = false;
			npc.GetModInfo<NPCsINFO1>(mod).customdebuff2 = false;
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (npc.GetModInfo<NPCsINFO1>(mod).customdebuff2)  //this tells the game to use the public bool customdebuff from NPCsINFO.cs
            {
                npc.lifeRegen -= 50;      //this make so the npc lose life, the highter is the value the faster the npc lose life
                if (damage < 2)
                {
                    damage = 6;  // this is the damage dealt when the npc lose health
                }
            }
			if (npc.GetModInfo<NPCsINFO1>(mod).customdebuff)  //this tells the game to use the public bool customdebuff from NPCsINFO.cs
            {
                npc.lifeRegen -= 50;      //this make so the npc lose life, the highter is the value the faster the npc lose life

                    damage = 1;  // this is the damage dealt when the npc lose health
      
            }
        }
    }
}