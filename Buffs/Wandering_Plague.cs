using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Emperia;

namespace Emperia.Buffs
{
    public class Wandering_Plague : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffName[Type] = "Wandering Plague"; 
            Main.buffTip[Type] = "Rapidly losing life, spreads to nearby enemies.";          
            Main.debuff[Type] = true;  
            Main.pvpBuff[Type] = true;  
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetModInfo<NPCsINFO1>(mod).Plague = true;    
            int num1 = Dust.NewDust(npc.position, npc.width, npc.height, 178);    
            Main.dust[num1].scale = 2.5f; 
            Main.dust[num1].velocity *= 3f; 
            Main.dust[num1].noGravity = true;
			
			for (int i = 0; i < Main.npc.Length; i++)
			{
				if (npc.Distance(Main.npc[i].Center) < 400 && !Main.npc[i].friendly)
				{
					Main.npc[i].AddBuff(mod.BuffType("WanderingPlague"), 180, false);
				}
			}
        }
    }
}
