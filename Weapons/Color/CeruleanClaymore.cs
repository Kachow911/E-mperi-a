using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Weapons.Color   //where is located
{
    public class CeruleanClaymore : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Cerulean Claymore";     //Sword name
            item.damage = 32;            //Sword damage
            item.melee = true;            //if it's melee
            item.width = 32;              //Sword width
            item.height = 32;             //Sword height
            item.useTime = 28;          //how fast 
            item.useAnimation = 28;     
            item.useStyle = 1;        //Style is how this item is used, 1 is the style of the sword
            item.knockBack = 3.5f;  
			item.crit = 4;			//Sword knockback
            item.value = 100;        
            item.rare = 3;
			item.scale = 1f;
            item.autoReuse = false;   //if it's capable of autoswing.
            item.useTurn = true;             //projectile speed                 
        }
		
        public override void AddRecipes()  //How to craft this sword
        {
            ModRecipe recipe = new ModRecipe(mod);      
            recipe.AddIngredient(null, "Prism", 1); 
			recipe.AddIngredient(ItemID.Sapphire, 8); 
			recipe.AddIngredient(ItemID.BlueBerries, 1); 
            recipe.AddTile(TileID.Anvils); 			//you need 1 DirtBlock  //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
		 public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			player.AddBuff(mod.BuffType("CeruleanBuff"), Main.rand.Next(300, 720));
		}
    }
}