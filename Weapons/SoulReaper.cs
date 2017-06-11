using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace Emperia.Weapons
{
    public class SoulReaper: ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Reaper of Souls");
			Tooltip.SetDefault("The legends say...");
		}
        public override void SetDefaults()
        {         
            item.thrown = true;
            item.width = 30;
			item.damage = 87;
            item.height = 30;
            item.useTime = 25;
            item.useAnimation = 25;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = 8;
            item.rare = 6;
            item.shootSpeed = 12f;
            item.shoot = mod.ProjectileType ("SoulReaper");
            item.autoReuse = true;
        }
    }
}