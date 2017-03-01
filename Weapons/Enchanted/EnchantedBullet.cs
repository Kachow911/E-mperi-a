using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

using Emperia.Projectiles;

namespace Emperia.Weapons.Enchanted
{
    public class EnchantedBullet : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Example Bullet";
            item.damage = 12;
            item.ranged = true;
            item.width = 8;
            item.height = 8;
            item.maxStack = 999;
            item.toolTip = "This is a modded bullet ammo.";
            item.consumable = true;
            item.knockBack = 1.5f;
            item.value = 10;
            item.rare = 2;
            item.shoot = mod.ProjectileType<Projectiles.EnchantedBullet>();
            item.shootSpeed = 16f;
            item.ammo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {   //Placeholder recipe
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrystalShard, 8);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
    }
}
