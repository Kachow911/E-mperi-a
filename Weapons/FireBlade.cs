using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Weapons   //where is located
{
    public class FireBlade : ModItem
    {
        public override void SetDefaults()
        {
			item.CloneDefaults(ItemID.IceBlade);
            item.name = "Fire Blade";     //Sword name
            item.shoot = mod.ProjectileType("FireBolt");    
        }
    }
}