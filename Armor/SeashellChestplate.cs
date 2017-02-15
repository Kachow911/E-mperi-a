using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace Emperia.Armor {
public class SeashellChestplate : ModItem
{
    public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
    {
        equips.Add(EquipType.Body);
        return true;
    }

    public override void SetDefaults()
    {
        item.name = "Seashell Breastplate";
        item.width = 18;
        item.height = 18;
        AddTooltip("+3 increased defsnse when in liquid");
        item.value = 65000;
        item.rare = 3;
        item.defense = 4; //15
    }

    public override void UpdateEquip(Player player)
    {
       if(player.wet == true || player.honeyWet == true || player.lavaWet == true)
    	{
			player.statDefense += 3;
		}
    }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);      
            recipe.AddIngredient(ItemID.Seashell, 4);
            recipe.AddIngredient(ItemID.FishingSeaweed, 3); 			
            recipe.AddTile(TileID.Anvils); 			//you need 1 DirtBlock  //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
    }
}}