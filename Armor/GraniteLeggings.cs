using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace Emperia.Armor {
public class GraniteLeggings : ModItem
{
    public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
    {
    	equips.Add(EquipType.Legs);
        return true;
    }
    
    public override void SetDefaults()
    {
        item.name = "Granite Greaves";
        item.width = 18;
        item.height = 18;
        AddTooltip("6% increased movement speed");
        item.value = 57500;
        item.rare = 3;
        item.defense = 5; //15
    }

    public override void UpdateEquip(Player player)
    {
        player.moveSpeed += 0.06f;
    }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "GraniteBar", 13);
        recipe.AddTile(TileID.Anvils);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
}}