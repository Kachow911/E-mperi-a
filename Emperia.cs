using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using Emperia.WorldStuff;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
namespace Emperia
{
    public class Emperia : Mod
    {
        public static BasicEffect basicEffect { get; private set; }
        public static Texture2D whitePixel { get; private set; }
        internal static Emperia instance;
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
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			MyPlayer modPlayer1 = Main.player[Main.myPlayer].GetModPlayer<MyPlayer>();
			//if (EventWorld.bloom)
			//{
				int index = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));
				LegacyGameInterfaceLayer bloomProgress = new LegacyGameInterfaceLayer("Emperia: BloomLayer",
					delegate
					{
						DrawBloom(Main.spriteBatch);
                       return true;
						
					},
					InterfaceScaleType.UI);
				layers.Insert(index, bloomProgress);
			//}
    
		}
        public void DrawBloom(SpriteBatch spriteBatch)
		{
            MyPlayer modPlayer1 = Main.player[Main.myPlayer].GetModPlayer<MyPlayer>();
			if (Main.player[Main.myPlayer].GetModPlayer<MyPlayer>().isBloom = true && !Main.gameMenu)
			{
				float scaleMultiplier = 0.5f + 1 * 0.5f;
				float alpha = 0.5f;
				Texture2D progressBg = Main.colorBarTexture;
				Texture2D progressColor = Main.colorBarTexture;
				Texture2D bloomIcon = Emperia.instance.GetTexture("WorldStuff/BloomIcon");
				const string bloomDescription = "The Bloom";
				Color descColor = new Color(39, 86, 134);

				Color waveColor = new Color(255, 241, 51);
				Color barrierColor = new Color(255, 241, 51);

				try
				{
					//draw the background for the waves counter
					const int offsetX = 20;
					const int offsetY = 20;
					int width = (int)(200f * scaleMultiplier);
					int height = (int)(46f * scaleMultiplier);
					Rectangle waveBackground = Utils.CenteredRectangle(new Vector2(Main.screenWidth - offsetX - 100f, Main.screenHeight - offsetY - 23f), new Vector2(width, height));
					Utils.DrawInvBG(spriteBatch, waveBackground, new Color(63, 65, 151, 255) * 0.785f);

					//draw wave text

					string waveText = "Cleared " + Main.player[Main.myPlayer].GetModPlayer<MyPlayer>().points + "%";
					Utils.DrawBorderString(spriteBatch, waveText, new Vector2(waveBackground.X + waveBackground.Width / 2, waveBackground.Y), Color.White, scaleMultiplier, 0.5f, -0.1f);

					//draw the progress bar

					Rectangle waveProgressBar = Utils.CenteredRectangle(new Vector2(waveBackground.X + waveBackground.Width * 0.5f, waveBackground.Y + waveBackground.Height * 0.75f), new Vector2(progressColor.Width, progressColor.Height));
					Rectangle waveProgressAmount = new Rectangle(0, 0, (int)(progressColor.Width * 0.01f * MathHelper.Clamp(Main.player[Main.myPlayer].GetModPlayer<MyPlayer>().points, 0f, 100f)), progressColor.Height);
					Vector2 offset = new Vector2((waveProgressBar.Width - (int)(waveProgressBar.Width * scaleMultiplier)) * 0.5f, (waveProgressBar.Height - (int)(waveProgressBar.Height * scaleMultiplier)) * 0.5f);


					spriteBatch.Draw(progressBg, waveProgressBar.Location.ToVector2() + offset, null, Color.White * alpha, 0f, new Vector2(0f), scaleMultiplier, SpriteEffects.None, 0f);
					spriteBatch.Draw(progressBg, waveProgressBar.Location.ToVector2() + offset, waveProgressAmount, waveColor, 0f, new Vector2(0f), scaleMultiplier, SpriteEffects.None, 0f);

					//draw the icon with the event description

					//draw the background
					const int internalOffset = 6;
					Vector2 descSize = new Vector2(154, 40) * scaleMultiplier;
					Rectangle barrierBackground = Utils.CenteredRectangle(new Vector2(Main.screenWidth - offsetX - 100f, Main.screenHeight - offsetY - 19f), new Vector2(width, height));
					Rectangle descBackground = Utils.CenteredRectangle(new Vector2(barrierBackground.X + barrierBackground.Width * 0.5f, barrierBackground.Y - internalOffset - descSize.Y * 0.5f), descSize);
					Utils.DrawInvBG(spriteBatch, descBackground, descColor * alpha);

					//draw the icon
					int descOffset = (descBackground.Height - (int)(32f * scaleMultiplier)) / 2;
					Rectangle icon = new Rectangle(descBackground.X + descOffset, descBackground.Y + descOffset, (int)(32 * scaleMultiplier), (int)(32 * scaleMultiplier));
					spriteBatch.Draw(bloomIcon, icon, Color.White);

					//draw text

					Utils.DrawBorderString(spriteBatch, bloomDescription, new Vector2(barrierBackground.X + barrierBackground.Width * 0.5f, barrierBackground.Y - internalOffset - descSize.Y * 0.5f), Color.White, 0.80f, 0.3f, 0.4f);
				}
				catch (Exception e)
				{
					ErrorLogger.Log(e.ToString());
				}
			}
		}
		
    }
}