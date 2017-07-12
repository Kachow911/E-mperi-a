using System.IO;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
namespace Emperia.WorldStuff
{
	public class EventWorld : ModWorld
	{
		public bool bloom = false; 
		public override void PostUpdate()
		{
			
			Player p = Main.player[Main.myPlayer];
			Vector2 pos = p.position;
			Mod mod = ModLoader.GetMod("Emperia");
			MyPlayer modPlayer = p.GetModPlayer<MyPlayer>(mod);

			
			if (!bloom && Main.dayTime /*&& modPlayer.isBloom*/)
			{
				bloom = true;
				Main.NewText("Dangerous things bloom from the jungle", 0, 255, 0);
			}				
			
			if (bloom && !Main.dayTime)
			{
				bloom = false;
				Main.NewText("The Bloom has Subsided", 0, 255, 0);
				modPlayer.isBloom = false;
			}
			if (bloom && modPlayer.points >= 100)
			{
				bloom = false;
				Main.NewText("The Bloom has Subsided", 0, 255, 0);
				modPlayer.isBloom = false;
			}
			
			if (bloom)
			{
				if (p.ZoneJungle)
				{
					if (Main.rand.Next(750) % 749 == 0)
					{
						int radius = Main.rand.Next(1000); //hyp
						int angle = Main.rand.Next(360);
						int spawnX = (int)(p.position.X + (Math.Sin(angle)*radius));
						angle = Main.rand.Next(360);
						int spawnY = (int)(p.position.Y + (Math.Cos(angle)*radius));
						NPC.NewNPC(spawnX, spawnY, 231, 0, 0f, 0f, 0f, (float)Main.myPlayer, Main.myPlayer);
					}
					if (Main.rand.Next(750) % 749 == 0)
					{
						int radius = Main.rand.Next(1000); //hyp
						int angle = Main.rand.Next(360);
						int spawnX = (int)(p.position.X + (Math.Sin(angle)*radius));
						angle = Main.rand.Next(360);
						int spawnY = (int)(p.position.Y + (Math.Cos(angle)*radius));
						
						NPC.NewNPC(spawnX, spawnY, 236, 0, 0f, 0f, 0f, (float)Main.myPlayer, Main.myPlayer);
					}
					if (Main.rand.Next(750) % 749 == 0)
					{
						int radius = Main.rand.Next(1000); //hyp
						int angle = Main.rand.Next(360);
						int spawnX = (int)(p.position.X + (Math.Sin(angle)*radius));
						angle = Main.rand.Next(360);
						int spawnY = (int)(p.position.Y + (Math.Cos(angle)*radius));
						NPC.NewNPC(spawnX, spawnY, 233, 0, 0f, 0f, 0f, (float)Main.myPlayer, Main.myPlayer);
					}
				}
			}			
		}
	}
}
