using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace Emperia.Items.Sets.Seashell {
public class SeashellLeggings : ModItem
{
    public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
    {
    	equips.Add(EquipType.Legs);
        return true;
    }
    
    public override void SetDefaults()
    {
        item.name = "Seashell Greaves";
        item.width = 18;
        item.height = 18;
        AddTooltip("6% increased movement speed when in liquid");
        item.value = 57500;
        item.rare = 3;
        item.defense = 2; //15
    }

    public override void UpdateEquip(Player player)
    {
		if(player.wet == true || player.honeyWet == true || player.lavaWet == true)
    	{
        player.moveSpeed += 0.06f;
		}
    }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);      
            recipe.AddIngredient(ItemID.Seashell, 3);
            recipe.AddIngredient(ItemID.FishingSeaweed, 2); 			
            recipe.AddTile(TileID.Anvils); 			//you need 1 DirtBlock  //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
    }
}}