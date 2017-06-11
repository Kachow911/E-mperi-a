using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Weapons   //where is located
{
    public class GraniteSword : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Granite Sword");
		}
        public override void SetDefaults()
        {    //Sword name
            item.damage = 16;            //Sword damage
            item.melee = true;            //if it's melee
            item.width = 16;              //Sword width
            item.height = 16;             //Sword height
            item.useTime = 27;          //how fast 
            item.useAnimation = 27;     
            item.useStyle = 1;        //Style is how this item is used, 1 is the style of the sword
            item.knockBack = 3.5f;      //Sword knockback
            item.value = 100;        
            item.rare = 1;
			item.scale = 1f;
            item.autoReuse = false;   //if it's capable of autoswing.
            item.useTurn = true;             //projectile speed                 
        }
		
        public override void AddRecipes()  //How to craft this sword
        {
            ModRecipe recipe = new ModRecipe(mod);      
            recipe.AddIngredient(null, "GraniteBar", 8); 
            recipe.AddTile(TileID.Anvils); 			//you need 1 DirtBlock  //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}