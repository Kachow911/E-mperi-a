using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent;
using Terraria.IO;
using Terraria.ObjectData;
using Terraria.Utilities;
using Terraria.ModLoader;

namespace Emperia.Weapons {
public class TreeSpiritStaff : ModItem
{
	
    public override void SetDefaults()
    {
        item.name = "Tree Spirit Staff";
        item.damage = 3;
        item.mana = 4;
        item.width = 50;
        item.height = 56;
        item.useTime = 36;
        item.useAnimation = 36;
        item.useStyle = 1;
        AddTooltip("Summons a tree spirit to fight for you");
        item.noMelee = true; //so the item's animation doesn't do damage
        item.knockBack = 1.25f;
        item.value = 55000;
        item.rare = 3;
        item.UseSound = SoundID.Item44;
        item.autoReuse = true;
        item.shoot = mod.ProjectileType("WoodSpirit");
        item.shootSpeed = 10f;
        item.buffType = mod.BuffType("WoodSpiritBuff");
        item.buffTime = 3600;
        item.summon = true;
    }
    
    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.Wood, 75);
        recipe.AddIngredient(ItemID.Acorn, 25);
        recipe.AddTile(TileID.WorkBenches);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
    
    public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
    {
    	int i = Main.myPlayer;
		float num72 = item.shootSpeed;
		int num73 = item.damage;
		float num74 = item.knockBack;
    	num74 = player.GetWeaponKnockback(item, num74);
    	player.itemTime = item.useTime;
    	Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
		Vector2 value = Vector2.UnitX.RotatedBy((double)player.fullRotation, default(Vector2));
		Vector2 vector3 = Main.MouseWorld - vector2;
    	float num78 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
		float num79 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
		if (player.gravDir == -1f)
		{
			num79 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector2.Y;
		}
		float num80 = (float)Math.Sqrt((double)(num78 * num78 + num79 * num79));
		float num81 = num80;
		if ((float.IsNaN(num78) && float.IsNaN(num79)) || (num78 == 0f && num79 == 0f))
		{
			num78 = (float)player.direction;
			num79 = 0f;
			num80 = num72;
		}
		else
		{
			num80 = num72 / num80;
		}
    	num78 = 0f;
		num79 = 0f;
		vector2.X = (float)Main.mouseX + Main.screenPosition.X;
		vector2.Y = (float)Main.mouseY + Main.screenPosition.Y;
		Projectile.NewProjectile(vector2.X, vector2.Y, num78, num79, mod.ProjectileType("WoodSpirit"), num73, num74, i, 0f, 0f);
		return false;
    }
}}