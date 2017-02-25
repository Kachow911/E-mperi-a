using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Emperia.Weapons.Enchanted
{   //Made by BlueRaven
    //Sword that fires a projectile similar to the beam sword or terra blade.
    //Like other enchanted weapons, damage of the weapon is increased each time the player kills an enemy.
    public class EnchantedSword : ModItem
    {
        private int damageIncrease;
        private const int damageIncreasePerKill = 6;

        private int falloffTimer = falloffTimerMax; 
        private const int falloffTimerMax = 240;      //4 seconds

        public override void SetDefaults()
        {
            item.name = "Enchanted Sword";
            item.damage = 12;        
            item.melee = true;       
            item.width = 128;         
            item.height = 32;        
            item.useTime = 27;       
            item.useAnimation = 27;
            item.useStyle = 1;       
            item.knockBack = 3.5f;   
            item.value = 100;
            item.rare = 3;
            item.scale = 1f;
            item.autoReuse = true;
            item.useTurn = true;    //turns the player to face mouse direction

            //item.shoot = mod.ProjectileType<>();  //TODO shoot thing

            projOnSwing = true; //see https://github.com/bluemagic123/tModLoader/wiki/ModItem#public-bool-projonswing
        }

        public override void Update(ref float gravity, ref float maxFallSpeed)
        {   //reset the additional damage if it's ever lying in the world to prevent exploitation or something idk
            falloffTimer = falloffTimerMax;
            damageIncrease = 0;
        }

        public override void UpdateInventory(Player player)
        {   //used to reset damage when falling off
            if (damageIncrease > 0)
            {   //so it doesn't run and instantly reset before the player has killed an npc
                //Main.NewText("Damage has fallen off.");
                falloffTimer--;

                if (falloffTimer <= 0)
                    damageIncrease = 0;
            }
        }

        public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        {
            damage += damageIncrease;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (target.life < 0)    //dead
            {
                falloffTimer = falloffTimerMax;
                damageIncrease += damageIncreasePerKill;
                Main.NewText("damageincrease: " + damageIncrease);
            }
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {   //dust determined by how much damage increase the item has
            for (int i = 0; i < (damageIncrease / damageIncreasePerKill) * 2; i++)
            {
                int x = Main.rand.Next(0, hitbox.Width);
                int y = Main.rand.Next(0, hitbox.Height);

                Dust.NewDust(new Vector2(hitbox.Location.X + x, hitbox.Location.Y + y), damageIncrease / damageIncreasePerKill, damageIncrease / damageIncreasePerKill, 20);
            }
        }

        public override void AddRecipes()
        {   //Placeholder recipe
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 8);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}
