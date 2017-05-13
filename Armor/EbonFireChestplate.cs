using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace Emperia.Armor {
public class EbonFireChestplate : ModItem
{
    public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
    {
        equips.Add(EquipType.Body);
        return true;
    }

    public override void SetDefaults()
    {
        item.name = "Ebonfire Chestplate";
        item.width = 18;
        item.height = 18;
        AddTooltip("+3% damage");
        item.value = 65000;
        item.rare = 3;
        item.defense = 16; //15
    }

    public override void UpdateEquip(Player player)
    {

		player.rangedDamage *= 1.08f;
		Mod mod = ModLoader.GetMod("Emperia");
		MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
		modPlayer.rofIncrease += 12;



    }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "EvilTwig", 26);
		recipe.AddIngredient(ItemID.CursedFlames, 36);
        recipe.AddTile(TileID.MythrilAnvil);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
}}