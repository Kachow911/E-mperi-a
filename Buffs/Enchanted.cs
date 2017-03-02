using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Emperia.Buffs
{
    public class Enchanted : ModBuff
    {
        public const int stackDuration = 240;      //4 seconds
        public const int minorStackDuration = 60;      //1 second
        public const int stackMax = 6;

        public const int damageIncreasePerStack = 6;   //total damage: 39 + 6 * 6 = 72

        private const string baseTip = "You feel stronger... ";

        public override void SetDefaults()
        {
            Main.buffName[Type] = "Enchanted";
            Main.buffTip[Type] = baseTip;
            Main.buffNoSave[Type] = true;
            //Main.buffNoTimeDisplay[Type] = true;

            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer p = player.GetModPlayer<MyPlayer>(mod);

            p.enchantedStacks += (int)Math.Ceiling((float)player.buffTime[buffIndex] / (float)stackDuration);// + 1;
            p.enchanted = true;
        }

        public override bool ReApply(Player player, int time, int buffIndex)
        {
            if (player.buffTime[buffIndex] + time <= stackDuration * stackMax)
                player.buffTime[buffIndex] += time;
            else player.buffTime[buffIndex] = stackDuration * stackMax;
            return true;
        }

        public override void ModifyBuffTip(ref string tip, ref int rare)
        {
            MyPlayer p = Main.player[Main.myPlayer].GetModPlayer<MyPlayer>(mod);
            tip = baseTip +  " " + p.enchantedStacks + " times stronger, to be exact.";
        }
    }
}
