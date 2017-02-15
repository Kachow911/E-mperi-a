using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace Emperia.Weapons
{
    public class DesertKhopesh : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Desert Khopesh";
            item.damage = 13;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.toolTip = "Rumor has it that you can throw it...";
            item.toolTip2 = "Right click to use like a boomerang";
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 100;
            item.rare = 8;
            item.autoReuse = true;
            item.useTurn = true;
 
 
        }
 
 
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
 
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)     //2 is right click
            { 
                for (int i = 0; i < Main.projectile.Length; i++)
			{
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
                {
					
                    return false;
					item.noUseGraphic = false;
                } 
				else {
					item.noUseGraphic = true;
                item.noMelee = true;
                item.damage = 25;
				item.shoot = mod.ProjectileType("KhopeshProj");
				item.shootSpeed = 7f;
				return true;
					
				}
				
			}
			return false;
                
            }
           else {
                 item.noUseGraphic = false;
				 item.noMelee = false;
                item.useTime = 20;
                item.useAnimation = 20;
                item.damage = 19;
                return base.CanUseItem(player);
		   }
           item.noUseGraphic = false;
        }
	
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse == 2)     //2 is right click
            { 
			return true;
			}
			else {
				
				return false;
			}
		}
 
    }
}