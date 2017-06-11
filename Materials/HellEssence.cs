using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace Emperia.Materials
{
    public class HellEssence : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Aspect of Flame");
		}
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.value = 100;
            item.rare = 1;
            item.maxStack = 999;
            ItemID.Sets.ItemNoGravity[item.type] = true;  //this make that the item will float in air
        }

        
 
    }
}