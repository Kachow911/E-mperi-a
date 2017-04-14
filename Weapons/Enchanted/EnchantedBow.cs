using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

using Emperia.Buffs;
using Emperia.Projectiles;

namespace Emperia.Weapons.Enchanted
{
    public class EnchantedBow : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Enchanted Bow";
            item.damage = 45;
            item.ranged = true;
            item.width = 64;
            item.height = 64;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.knockBack = 3.5f;
            item.value = 100;
            item.rare = 3;
            item.scale = 1f;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.useTurn = true;    //turns the player to face mouse direction
            item.noMelee = true;

            item.shoot = 10;
            item.shootSpeed = 8f;
            item.useAmmo = AmmoID.Arrow;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            damage = item.damage + player.GetModPlayer<MyPlayer>(mod).enchantedStacks * Buffs.Enchanted.damageIncreasePerStack;
            Projectile p = Main.projectile[Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack)];
            p.GetModInfo<EnchantedInfo>(mod).givesEnchanted = true;
            p.owner = player.whoAmI;
            return false;   //return false since we're spawning in manually
        }
		 public override void AddRecipes()
        {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.CrystalShard, 15);
				recipe.AddIngredient(ItemID.SoulofLight, 5);
                recipe.SetResult(this);
                recipe.AddRecipe();
        }
    }
}
