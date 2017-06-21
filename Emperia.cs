using System;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Emperia.WorldStuff;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
namespace Emperia
{
    public class Emperia : Mod
    {
        public static BasicEffect basicEffect { get; private set; }
        public static Texture2D whitePixel { get; private set; }
        public Emperia()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true,
                AutoloadBackgrounds = true
            };

            GraphicsDevice device = Main.graphics.GraphicsDevice;
            Texture2D whitePixel = new Texture2D(device, 1, 1);
            whitePixel.SetData<Color>(new Color[] { Color.White });

            basicEffect = new BasicEffect(Main.graphics.GraphicsDevice);
            basicEffect.VertexColorEnabled = true;
            basicEffect.TextureEnabled = true;
            basicEffect.Projection = Matrix.CreateOrthographicOffCenter
                (0, Main.graphics.GraphicsDevice.Viewport.Width,     // left, right
                Main.graphics.GraphicsDevice.Viewport.Height, 0,    // bottom, top
                0, 1);
            basicEffect.Texture = whitePixel;  //give it the white pixel texture

            Emperia.whitePixel = whitePixel;
        }
		public override void Load()
		{
			if (!Main.dedServ)
			{
				Filters.Scene["Emperia:Bloom"] = new Filter(new BloomScreenShaderData("FilterMiniTower").UseColor(0.12f, 1f, 0.4f).UseOpacity(0.2f), EffectPriority.VeryHigh);
				Filters.Scene["Emperia:Twilight"] = new Filter(new TwilightScreenShaderData("FilterMiniTower").UseColor(1f, 0.5f, 1f).UseOpacity(0.4f), EffectPriority.VeryHigh);
				//SkyManager.Instance["Emperia:Bloom"] = new PuritySpiritSky();

			}
		}
        /// <summary>
        /// Gets the entity nearest to the given vector.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="looknear">The position to look near</param>
        /// <param name="entityList">The list to look through, e.g. Main.npc.</param>
        /// <returns>The nearest entity to the given vector.</returns>
        public static T GetNearestEntity<T>(Vector2 looknear, params T[] entityList) where T : Entity
        {
            float closestDistance = 0;  //for ease of access when comparing, instead of having to re-write the check every time
            T closestEntity = null;     //null so we know it hasn't been set yet

            for (int i = 0; i < entityList.Length; i++)
            {
                T currentEntity = entityList[i];    //for ease of access

                if (currentEntity != null)
                {   //so we don't deal with any nullpointerexceptions
                    float currentDistance = (looknear - currentEntity.Center).Length();

                    if (closestEntity == null || currentDistance < closestDistance)
                    {   //if the current distance is less than the current closest distance, OR it has not been set yet
                        closestDistance = currentDistance;
                        closestEntity = currentEntity;
                    }
                }
            }

            return closestEntity;
        }

        public override void PostSetupContent()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
                // AddBoss, bossname, order or value in terms of vanilla bosses, inline method for retrieving downed value.
                bossChecklist.Call("AddBoss", "Mushor", 5.5f, (Func<bool>)(() => EmperialWorld.downedMushor));
                //bossChecklist.Call(....
            }
        }

        public static T CreateProjectile<T>(Mod modReference, Vector2 position, Vector2 velocity, int damage, float knockback, int owner = 255, float ai0 = 0, float ai1 = 0) where T : ModProjectile
        {
            return (T)Main.projectile[Projectile.NewProjectile(position, velocity, modReference.ProjectileType<T>(), damage, knockback, Main.myPlayer, ai0, ai1)].modProjectile;
        }
		
    }
}