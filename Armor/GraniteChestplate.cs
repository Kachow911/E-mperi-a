﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace Emperia.Armor {
public class GraniteChestplate : ModItem
{
    public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
    {
        equips.Add(EquipType.Body);
        return true;
    }

    public override void SetDefaults()
    {
        item.name = "Granite Breastplate";
        item.width = 18;
        item.height = 18;
        AddTooltip("+3% damage");
        item.value = 65000;
        item.rare = 3;
        item.defense = 6; //15
    }

    public override void UpdateEquip(Player player)
    {
        player.meleeDamage *= 1.03f;
		player.rangedDamage *= 1.03f;
		player.magicDamage *= 1.03f;
		player.minionDamage *= 1.03f;
		player.thrownDamage *= 1.03f;
    }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "GraniteBar", 18);
        recipe.AddTile(TileID.Anvils);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
}}