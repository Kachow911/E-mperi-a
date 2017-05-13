using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace Emperia.Weapons        
{
    public class MagmaSpewer : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Magma Spewer";   
            item.damage = 66;  
            item.ranged = true;    
            item.width = 42; 
            item.height = 16;    
            item.toolTip = "The flames are made of pure lava \n Inflicts a more potent form on On Fire!";  
            item.toolTip2 = "50% chance to not consume gel";   
            item.useTime = 6;   
            item.useAnimation = 20;     
            item.useStyle = 5;  
            item.noMelee = true; 
            item.knockBack = 3.25f; 
            item.UseSound = SoundID.Item34; 
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.rare = 6;   
            item.autoReuse = true;  
            item.shoot = mod.ProjectileType("MagmaFlame");   
            item.shootSpeed = 4.5f; 
            item.useAmmo = AmmoID.Gel;
        }
 
        public override bool ConsumeAmmo(Player player) 
        {
            return Main.rand.NextFloat() > .5f;
        }
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
    }
}