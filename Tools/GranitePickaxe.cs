using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Tools {
public class GranitePickaxe : ModItem
{
    public override void SetDefaults()
    {
        item.name = "Granite Pickaxe";
        item.damage = 7;
        item.melee = true;
        item.width = 46;
        item.height = 46;
        item.useTime = 19;
        item.useAnimation = 19;
        item.useTurn = true;
        item.pick = 55;
        item.useStyle = 1;
        item.knockBack = 2f;
        item.value = 1770;
        item.rare = 4;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
    }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "GraniteBar", 7);
        recipe.AddTile(TileID.Anvils);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
}}