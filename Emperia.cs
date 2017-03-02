using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Emperia
{
	public class Emperia : Mod
	{
		public Emperia()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true,
                AutoloadBackgrounds = true
            };
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
    }
}