using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Weapons   //where is located
{
    public class DesertBlade : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Desert's Wrath";     //Sword name
            item.damage = 9;            //Sword damage
            item.melee = true;            //if it's melee
            item.width = 16;              //Sword width
            item.height = 16;             //Sword height
            item.toolTip = "Occasionally shoots balls of sand";  //Item Description
            item.useTime = 24;          //how fast 
            item.useAnimation = 24;     
            item.useStyle = 1;        //Style is how this item is used, 1 is the style of the sword
            item.knockBack = 5;      //Sword knockback
            item.value = 100;        
            item.rare = 10;
			item.shoot = 1;
			item.shootSpeed = 7f;
            item.autoReuse = true;   //if it's capable of autoswing.
            item.useTurn = true;             //projectile speed                 
        }
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (Main.rand.Next(3) == 0) {
				 Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.SandBallGun, damage, knockBack, player.whoAmI, 0f, 0f);
				return false;
			}
            return false; //Makes sure to not fire the original projectile
        }
        public override void AddRecipes()  //How to craft this sword
        {
            ModRecipe recipe = new ModRecipe(mod);      
            recipe.AddIngredient(null, "DesertBar", 7); 
            recipe.AddTile(TileID.Anvils); 			//you need 1 DirtBlock  //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}