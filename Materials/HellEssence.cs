using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace Emperia.Materials
{
    public class HellEssence : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Aspect of Flame";
            item.width = 20;
            item.height = 20;
            item.value = 100;
            item.rare = 1;
            item.maxStack = 999;
            ItemID.Sets.ItemNoGravity[item.type] = true;  //this make that the item will float in air
        }
 
        public override DrawAnimation GetAnimation()
        {
            return new DrawAnimationVertical(15, 4);   //2 is the sprite frame, change of how many frames your sprite have
        }
 
    }
}