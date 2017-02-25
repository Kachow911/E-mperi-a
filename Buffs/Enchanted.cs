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
            player.buffTime[buffIndex] += time;
            return true;
        }
    }
}
