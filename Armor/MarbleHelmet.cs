﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Armor {
public class MarbleHelmet : ModItem
{
    public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
    {
    	equips.Add(EquipType.Head);
        return true;
    }

    public override void SetDefaults()
    {
        item.name = "Marble Helmet";
        item.width = 18;
        item.height = 18;
        AddTooltip("2% increased damage");
        item.value = 50000;
        item.rare = 3;
        item.defense = 4; //15
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == mod.ItemType("MarbleBreastplate") && legs.type == mod.ItemType("MarbleGrieves");
    }
    
  

    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = "6% damage reduction";
        player.endurance += 0.06f;
    }
    
    public override void UpdateEquip(Player player)
    {
    	player.meleeDamage *= 1.02f;
        player.thrownDamage *= 1.02f;
        player.rangedDamage *= 1.02f;
        player.magicDamage *= 1.02f;
        player.minionDamage *= 1.02f;
    }
    
    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "MarbleBar", 13);
        recipe.AddTile(TileID.Anvils);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
}}