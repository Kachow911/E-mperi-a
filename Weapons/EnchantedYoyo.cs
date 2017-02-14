using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Weapons {
public class EnchantedYoyo : ModItem
{
	
	
    public override void SetDefaults()
    {
    	item.CloneDefaults(ItemID.HelFire);
        item.name = "Yoyo.jpg";
        item.damage = 43;
        item.useTime = 22;
        item.useAnimation = 22;
        item.toolTip = "Fires things";
        item.useStyle = 5;
        item.channel = true;
        item.melee = true;
        item.knockBack = 3.4f;
        item.value = 150000;
        item.rare = 6;
        item.autoReuse = true;
        item.shoot = mod.ProjectileType("YoyoProjectile");
    }
    
    public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
    {
        Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, (int)((double)damage), knockBack, player.whoAmI, 0.0f, 0.0f);
		return false;
	}
public override void AddRecipes()  //How to craft this sword
        {
            ModRecipe recipe = new ModRecipe(mod);      
            recipe.AddIngredient(ItemID.DirtBlock, 1);					//you need 1 DirtBlock  //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
		}

}}