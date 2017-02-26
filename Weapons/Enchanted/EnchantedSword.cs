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
{   //Made by BlueRaven
    //Sword that fires a projectile similar to the beam sword or terra blade.
    //Like other enchanted weapons, damage of the weapon is increased each time the player kills an enemy.
    public class EnchantedSword : ModItem
    {
        private const int damageIncreasePerStack = 6;   //total damage: 39 + 6 * 6 = 72

        public override void SetDefaults()
        {
            item.name = "Enchanted Sword";
            item.damage = 39;
            //item.melee = true;       
            item.ranged = true;
            item.width = 64;         
            item.height = 64;        
            item.useTime = 30;       
            item.useAnimation = 30;
            item.useStyle = 1;       
            item.knockBack = 3.5f;   
            item.value = 100;
            item.rare = 3;
            item.scale = 1.2f;
            item.autoReuse = true;
            item.useTurn = true;    //turns the player to face mouse direction

            item.shoot = mod.ProjectileType<EnchantedBall>();//mod.ProjectileType<>();  //TODO shoot thing
            item.shootSpeed = 4;

            projOnSwing = true; //see https://github.com/bluemagic123/tModLoader/wiki/ModItem#public-bool-projonswing
        }

        public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        {   //increase weapon damage. Will have to do similar in projectile
            damage += player.GetModPlayer<MyPlayer>(mod).enchantedStacks * damageIncreasePerStack;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            damage = item.damage + player.GetModPlayer<MyPlayer>(mod).enchantedStacks * damageIncreasePerStack;
            speedY = 0;
            return true;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (target.life <= 0)
            {
                player.AddBuff(mod.BuffType<Buffs.Enchanted>(), Buffs.Enchanted.stackDuration);
            }
        }

        public override void AddRecipes()
        {   //Placeholder recipe
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrystalShard, 8);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
