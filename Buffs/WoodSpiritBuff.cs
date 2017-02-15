using Terraria;
using Terraria.ModLoader;

namespace Emperia.Buffs
{
	public class WoodSpiritBuff : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Tree Spirit";
			Main.buffTip[Type] = "The tree spirit will protect you";
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("WoodSpirit")] > 0)
			{
				modPlayer.wSpirit = true;
			}
			if (!modPlayer.wSpirit)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}