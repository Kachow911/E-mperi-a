using System.IO;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Emperia.UI;
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

			
			if (!bloom && Main.dayTime && modPlayer.isBloom)
			{
				bloom = true;
				Main.NewText("Dangerous things bloom from the jungle", 0, 255, 0);
				eventUI.visible = true;
			}				
			
			if (bloom && !Main.dayTime)
			{
				bloom = false;
				Main.NewText("The Bloom has Subsided", 0, 255, 0);
				modPlayer.isBloom = false;
			}
			
			if (bloom)
			{
				if (Main.rand.Next(500) % 499 == 0)
				{
					int radius = Main.rand.Next(1000); //hyp
					int angle = Main.rand.Next(360);
					int spawnX = (int)(p.position.X + (Math.Sin(angle)*radius));
					angle = Main.rand.Next(360);
					int spawnY = (int)(p.position.Y + (Math.Cos(angle)*radius));
					NPC.NewNPC(spawnX, spawnY, mod.NPCType("Mushor"), 0, 0f, 0f, 0f, (float)Main.myPlayer, Main.myPlayer);
				}
			}			
		}
	}
}
