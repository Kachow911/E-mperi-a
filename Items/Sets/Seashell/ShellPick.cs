using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Items.Sets.Seashell {
public class ShellPick : ModItem
{
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Seashell Pickaxe");
		}
    public override void SetDefaults()
    {
        item.damage = 5;
        item.melee = true;
        item.width = 46;
        item.height = 46;
        item.useTime = 19;
        item.useAnimation = 19;
        item.useTurn = true;
        item.pick = 45;
        item.useStyle = 1;
        item.knockBack = 2f;
		item.scale = 1.25f;
        item.value = 1770;
        item.rare = 1;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
    }

     public override void AddRecipes()  //How to craft this sword
        {
            ModRecipe recipe = new ModRecipe(mod);      
            recipe.AddIngredient(ItemID.Seashell, 2);
            recipe.AddIngredient(ItemID.FishingSeaweed, 1); 			
            recipe.AddTile(TileID.Anvils); 			//you need 1 DirtBlock  //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
}}