using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Emperia.Mounts
{
	public class BetterUfo : ModMountData
	{
		public override void SetDefaults()
		{
			mountData.spawnDust = 21;
			mountData.buff = mod.BuffType("BerylBuff");
			 mountData.heightBoost = 16;
      mountData.flightTimeMax = 320;
      mountData.fatigueMax = 320;
      mountData.fallDamage = 0.0f;
      mountData.usesHover = true;
      mountData.runSpeed = 2f;
      mountData.dashSpeed = 2f;
      mountData.acceleration = 0.16f;
      mountData.jumpHeight = 10;
      mountData.jumpSpeed = 4f;
      mountData.blockExtraJumps = true;
      mountData.totalFrames = 1;
      mountData.xOffset = 1;
      mountData.bodyFrame = 3;
      mountData.yOffset = 4;
      mountData.playerHeadOffset = 18;
      mountData.standingFrameCount = 1;
      mountData.standingFrameDelay = 12;
      mountData.standingFrameStart = 0;
      mountData.runningFrameCount = 1;
      mountData.runningFrameDelay = 12;
      mountData.runningFrameStart = 0;
      mountData.flyingFrameCount = 1;
      mountData.flyingFrameDelay = 12;
      mountData.flyingFrameStart = 5;
      mountData.inAirFrameCount = 1;
      mountData.inAirFrameDelay = 12;
      mountData.inAirFrameStart = 5;
      mountData.idleFrameCount = 1;
      mountData.idleFrameDelay = 12;
      mountData.idleFrameStart = 8;
      mountData.idleFrameLoop = true;
      mountData.swimFrameCount = 0;
      mountData.swimFrameDelay = 12;
      mountData.swimFrameStart = 0;
		}

		public override void UpdateEffects(Player player)
		{
			if (Math.Abs(player.velocity.X) > 4f)
			{
				Rectangle rect = player.getRect();
				Dust.NewDust(new Vector2(rect.X, rect.Y), rect.Width, rect.Height, 21);
			}
		}
	}
}