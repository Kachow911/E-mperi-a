using Terraria;
using Terraria.ModLoader;

namespace Emperia.Buffs
{
	public class CarMount : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[this.Type] = "OOF o";
			Main.buffTip[this.Type] = "Leather seats, 4 cupholders";
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(mod.MountType<Mounts.BetterUfo>(), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}
