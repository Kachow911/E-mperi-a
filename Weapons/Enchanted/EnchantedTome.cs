using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Weapons.Enchanted   //where is located
{
    public class EnchantedTome : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Enchanted Tome";     //Sword name
            item.damage = 40;            //Sword damage
            item.magic = true;
            item.noMelee = true;          //if it's melee
            item.width = 32;              //Sword width
            item.height = 32;             //Sword height  //Item Description
            item.useTime = 32;          //how fast 
            item.useAnimation = 32;     
            item.useStyle = 5;    
            item.mana = 17;			//Style is how this item is used, 1 is the style of the sword
            item.knockBack = 5;      //Sword knockback
            item.value = 100;        
            item.rare = 13;
			item.shoot = mod.ProjectileType("EnchantedCrystal"); // the tornado when its ready
			item.shootSpeed = 8f;
            item.autoReuse = false;   //if it's capable of autoswing.
            item.useTurn = true;             //projectile speed                 
        }
		 public override void AddRecipes()
        {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.CrystalShard, 15);
				recipe.AddIngredient(ItemID.SoulofLight, 5);
                recipe.SetResult(this);
                recipe.AddRecipe();
        }
    }
}