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
    public class EnchantedArrow : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Enchanted Arrow";
            item.damage = 20;
            item.ranged = true;
            item.width = 8;
            item.height = 8;
            item.maxStack = 999;
            item.toolTip = "This is a modded bullet ammo.";
            item.consumable = true;
            item.knockBack = 1.5f;
            item.value = 10;
            item.rare = 2;
            item.shoot = mod.ProjectileType<Projectiles.EnchantedArrow>();
            item.shootSpeed = 16f;
            item.ammo = AmmoID.Arrow;
        }

        public override void AddRecipes()
        {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.CrystalShard, 15);
				recipe.AddIngredient(ItemID.SoulofLight, 5);
                recipe.SetResult(this, 200);
                recipe.AddRecipe();
        }
    }
}
