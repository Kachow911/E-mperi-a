using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Emperia;
 
namespace Emperia.Buffs
{
    public class Drowning : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffName[Type] = "Drowning"; 
            Main.buffTip[Type] = "Eat poo - poo";         
            Main.debuff[Type] = true;   
            Main.pvpBuff[Type] = true; 
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }
 
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetModInfo<NPCsInfo>(mod).drowning = true;    
            int num1 = Dust.NewDust(npc.position, npc.width, npc.height, 156);   
            Main.dust[num1].scale = 2.9f; //the dust scale , the higher is the value the large is the dust
            Main.dust[num1].velocity *= 3f; //the dust velocity
            Main.dust[num1].noGravity = true;
        }
 
    }
}